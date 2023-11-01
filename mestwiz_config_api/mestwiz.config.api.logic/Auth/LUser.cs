
using mestwiz.config.api.entities;
using mestwiz.config.api.entities.Auth;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.api.logic.Users;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using mestwiz.config.data.entities.Functions;

namespace mestwiz.config.api.logic.Auth
{
    public class LUser : BaseLogic<IUserDataController>, ILUser
    {
        private readonly ILEmailXUser lEmailXUser;
        private readonly ILSessionXUser lSessionXUser;
        private readonly ILRoleXUser lgRoleXUser;
        private readonly ILMenu lgMenu;
        private readonly ILMenuXRole lgMenuXRole;

        public LUser(IUserDataController dataController, 
                    ILEmailXUser lEmailXUser, 
                    ILSessionXUser lSessionXUser,
                    ILRoleXUser lgRoleXUser,
                    ILMenu lgMenu,
                    ILMenuXRole lgMenuXRole) : base(dataController) {
            this.lEmailXUser = lEmailXUser;
            this.lSessionXUser = lSessionXUser;
            this.lgRoleXUser = lgRoleXUser;
            this.lgMenu = lgMenu;
            this.lgMenuXRole = lgMenuXRole;
        }

        public async Task<Response<User>> GetByName(string Name)
        {
            Response<User> response = new();
            response.data = await this.dataController.GetByName(Name);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El usuario no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<User>> Get(string Id)
        {
            Response<User> response = new();
            response.data = await this.dataController.Get(Id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El usuario no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<User>>> Get()
        {
            Response<List<User>> response = new();
            response.data = await this.dataController.Get();

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "No hay usuarios Registrados", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<User>> Add(User user)
        {
            Response<User> response = new();

            response.message = await ValidateNew(user);

            if (response.message.status != ResponseStatus.Success)
                return response;

            response.data = await this.dataController.Add(user);
            response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<User>> Login(UserLogin userLogin, string Userhost = "")
        {
            Response<User> response = new();
            Response<EmailXUser> existEmailXUser = new();

            try
            {
                response.message = await ValidateLogin(userLogin);

                if (response.message.status != ResponseStatus.Success)
                    return response;

                userLogin.password = await userLogin.password.SimpleDecrypt();
                userLogin.password = await userLogin.password.MD5Encrypt();

                if (!await userLogin.email.IsNullString())
                {
                    existEmailXUser = await lEmailXUser.Get(userLogin.email);

                    if (existEmailXUser.message.status == ResponseStatus.Success)
                        response = await Get(existEmailXUser.data.user_id);
                    else
                        throw new Exception("El usuario no existe.");
                }
                else
                {
                    response = await GetByName(userLogin.name);
                }

                if (response.message.status != ResponseStatus.Success)
                    return response;

                if (userLogin.password != response.data.password)
                    throw new Exception("Contraseña incorrecta");

                Response<SessionXUser> responseSessionXUser = new();

                SessionXUser sessionXUser = new()
                {
                    user_id = response.data.id,
                    access_date = DateTime.UtcNow,
                    close_date = DateTime.UtcNow.AddDays(3),
                    id = await new SessionXUser().GetNewId(),
                    status = "AC",
                    host = Userhost
                };

                sessionXUser.data = await sessionXUser.ToJsonString();
                sessionXUser.data = await sessionXUser.data.SimpleEncrypt();
             
                responseSessionXUser = await lSessionXUser.Add(sessionXUser);

                if (responseSessionXUser.message.status != ResponseStatus.Success)
                {
                    response.message = responseSessionXUser.message;
                    return response;
                }

                await this.dataController.CommitAsync();

                response.message.status = ResponseStatus.Success;

            } catch(Exception e)
            {
                response.message.AddError(new MessageError() { Error = e.Message });
            }
            return response;
        }

        public async Task<Response<User>> Register(UserRegister userRegister, string Userhost = "")
        {
            
            Response<User> response = new();          
            Response<EmailXUser> responseEmailxUser = new();
            Response<SessionXUser> responseSessionXUser = new();

            try
            {
                User user = new() 
                {
                    id = await new User().GetNewId(),
                    status = "AC",
                    cipher_type = "md5",
                    cipher_secret = "",
                    created_date = DateTime.Now,
                    name = userRegister.name,
                    full_name = userRegister.fullname,
                    password = await userRegister.password.SimpleDecrypt()
                };

                user.password = await user.password.MD5Encrypt();

                response.data = await dataController.Add(user);

                if (response.message.status != ResponseStatus.Success)
                {
                    return response;
                };

                EmailXUser emailXUser = new() { 
                    user_id = user.id, 
                    status = "AC", 
                    _default = true, 
                    id = userRegister.email,
                    created_date = DateTime.Now
                };

                responseEmailxUser = await lEmailXUser.Add(emailXUser);

                if (responseEmailxUser.message.status != ResponseStatus.Success)
                {
                    response.message = responseEmailxUser.message;
                    return response;
                };

                SessionXUser sessionXUser = new()
                {
                    user_id = user.id,
                    access_date = DateTime.UtcNow,
                    close_date = DateTime.UtcNow.AddDays(3),
                    id = await new SessionXUser().GetNewId(),
                    status = "AC",
                    host = Userhost
                };

                sessionXUser.data = await sessionXUser.ToJsonString();
                sessionXUser.data = await sessionXUser.data.SimpleEncrypt();

                responseSessionXUser = await lSessionXUser.Add(sessionXUser);

                if (responseSessionXUser.message.status != ResponseStatus.Success)
                {
                    response.message = responseSessionXUser.message;
                    return response;
                }

                await this.dataController.CommitAsync();

                response.message.status = ResponseStatus.Success;
            }
            catch (Exception e)
            {
                await this.dataController.RollbackAsync();
                response.message.AddError(new MessageError() { Error  = e.Message });
            }

            return response;
        }


        public async Task<Message> ValidateNew(User User)
        {
            Message _Message = new Message();

            if (User == null)
            {
                _Message.AddError(new MessageError() { Error = "Usuario no valido" });
                return _Message;
            }

            if (await User.name.IsNullString())
                _Message.AddError(new MessageError() { Error = "UserName no valido" }); 
            else
            {
                User _existUser = await dataController.GetByName(User.name);
                if (_existUser != null)
                    _Message.AddError(new MessageError() { Error = "El Usuario ya existe" });
            }
            
            if (await User.password.IsNullString())
                _Message.AddError(new MessageError() { Error = "Usuario no valido" });

            if (await User.full_name.IsNullString())
                _Message.AddError(new MessageError() { Error = "Usuario no valido" });
                  
            return _Message;
        }

        public async Task<Message> ValidateLogin(UserLogin User)
        {
            Message _Message = new Message();

            if (User == null)
            {
                _Message.AddError(new MessageError() { Error = "Usuario no valido" });
                return _Message;
            }

            if (await User.name.IsNullString() && await User.email.IsNullString())
                _Message.AddError(new MessageError() { Error = "UserName no valido" });
            else
            {
                if (!await User.name.IsNullString() && await User.email.IsNullString())
                {
                    Response<User> userExists = await GetByName(User.name);
                    if (userExists.message.status != ResponseStatus.Success)
                        _Message = userExists.message;
                }
            }

            if (await User.password.IsNullString())
                _Message.AddError(new MessageError() { Error = "Usuario no valido" });

            return _Message;
        }

        public async Task<Response<List<UserMenu>>> GetMenu(string user_id)
        {
            
            Response<List<UserMenu>> responseUserMenu = new();

            Response<User> responseUser = new();
            Response<List<RoleXUser>> responseRolexuser = new();
            Response<List<Menu>> responseMenu = new();
            List<Response<List<MenuXRole>>> responseMenuxrole = new();

            try
            {
                responseUser = await Get(user_id);
                responseUserMenu.message = responseUser.message;

                if (responseUserMenu.message.status != ResponseStatus.Success)
                {
                    return responseUserMenu;
                };

                responseRolexuser = await lgRoleXUser.GetByUserId(user_id);

                responseUserMenu.message = responseRolexuser.message;

                if (responseUserMenu.message.status != ResponseStatus.Success)
                {
                    return responseUserMenu;
                };

                responseMenu = await lgMenu.Get();

                responseUserMenu.message = responseMenu.message;

                if (responseUserMenu.message.status != ResponseStatus.Success)
                {
                    return responseUserMenu;
                };

                responseRolexuser.data.ForEach(async rxu =>
                     {
                         responseMenuxrole.Add(await lgMenuXRole.GetByRoleId(rxu.role_id));
                     });

                List < MenuXRole> tmpMenu = new();

                responseMenuxrole.ForEach(rmxr =>
                {
                    if (rmxr.message.status != ResponseStatus.Success)
                        return;

                    rmxr.data.ForEach(mxr =>
                    {
                        tmpMenu.Add(mxr);
                    });
                });

                responseUserMenu.data = GetUserMenu(responseMenu.data, tmpMenu, null);

            }
            catch (System.Exception e)
            {
                responseUserMenu.message.AddError(new MessageError() { Error = e.Message });

            }

            return responseUserMenu;
        }

        public List<UserMenu> GetUserMenu(List<Menu> Menus, List<MenuXRole> menuXRoles, List<UserMenu> userMenus = null)
        {
            List<Menu> parentMenus = Menus.Where(m => m.parent_id == 0 && menuXRoles.Any(mxrl=>mxrl.id == m.id)).ToList();
            List<Menu> childMenus = Menus.Where(m => m.parent_id != 0 && menuXRoles.Any(mxrl => mxrl.id == m.id)).ToList();

            if(parentMenus != null ? parentMenus.Count > 0 : false)
            {
                if(userMenus !=null ? userMenus.Count == 0 : true)
                {
                    userMenus = new();
                    parentMenus.ForEach(pm =>
                    {
                        if(!userMenus.Any(usm=>usm.Id == pm.id))
                            userMenus.Add(new UserMenu() { Id= pm.id, Description = pm.description, Route = pm.route });
                    });
                }
            }

            if(childMenus != null? childMenus.Count > 0 : false)
            {
                userMenus.ForEach(usm =>
                {
                    if (usm.SubMenus != null ? usm.SubMenus.Count == 0 : true)
                    {
                        usm.SubMenus = new();
                        childMenus.Where(chlM => chlM.parent_id == usm.Id).ToList().ForEach(pm =>
                        {
                            if (!usm.SubMenus.Any(usm => usm.Id == pm.id))
                                usm.SubMenus.Add(new UserMenu() { Id = pm.id, Description = pm.description, Route = pm.route });
                        });
                    }

                    if (usm.SubMenus != null ? usm.SubMenus.Count > 0 : false)
                    {
                        var chlsms = childMenus.Where(chlm => usm.SubMenus.Any(sbms => chlm.parent_id == sbms.Id)).ToList();
                        if (chlsms != null ? chlsms.Count > 0 : false)
                            usm.SubMenus = GetUserMenu(chlsms, menuXRoles, usm.SubMenus);
                    }
                        
                });
               
            }

            return userMenus;
        }
    }
}