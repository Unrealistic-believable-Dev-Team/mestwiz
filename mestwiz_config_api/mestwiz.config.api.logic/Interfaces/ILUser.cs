
using mestwiz.config.api.entities;
using mestwiz.config.api.entities.Auth;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILUser : IDisposable, IBaseLogic<IUserDataController>
    {

        public Task<Response<User>> GetByName(string Name);

        public Task<Response<User>> Get(string Id);

        public Task<Response<List<User>>> Get();

        public Task<Response<User>> Add(User user);

        public Task<Response<User>> Login(UserLogin userLogin, string Userhost = "");

        public Task<Response<User>> Register(UserRegister userRegister, string Userhost = "");

        public Task<Message> ValidateNew(User User);

        public Task<Message> ValidateLogin(UserLogin User);

        public Task<Response<List<UserMenu>>> GetMenu(string user_id);

        public List<UserMenu> GetUserMenu(List<Menu> Menus, List<MenuXRole> menuXRoles, List<UserMenu> userMenus = null);
    }
}