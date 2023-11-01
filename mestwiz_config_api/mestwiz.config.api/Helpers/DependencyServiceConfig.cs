using mestwiz.config.api.entities.Auth;
using mestwiz.config.api.logic.Administration;
using mestwiz.config.api.logic.Auth;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.api.logic.Permissions;
using mestwiz.config.api.logic.Users;
using mestwiz.config.data.access.Interfaces;
using mestwiz.config.data.access.Services;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.controller.Services;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.Helpers
{
    public class DependencyServiceConfig
    {
        private readonly IServiceCollection servicesCollection;

        public DependencyServiceConfig(IServiceCollection services)
        {
            this.servicesCollection = services;
        }

        public void Configure()
        {
            this.servicesCollection
                //Data Context
                .AddTransient<IDataContext, DataContext>()
                //Generic Data Controllers
                .AddTransient<IDataController, DataController>()
                //Data Controllers
                .AddTransient<IUserDataController, UserDataController>()
                .AddTransient<IUsuarioDataController, UsuarioDataController>()
                .AddTransient<IApiEndPointDataController, ApiEndPointDataController>()
                .AddTransient<ITokenXUserDataController, TokenXUserDataController>()
                .AddTransient<ISessionXUserDataController, SessionXUserDataController>()
                .AddTransient<IRoleXUserDataController, RoleXUserDataController>()
                .AddTransient<IRoleDataController, RoleDataController>()
                .AddTransient<IPhoneXUserDataController, PhoneXUserDataController>()
                .AddTransient<IPermissionXTypeDataController, PermissionXTypeDataController>()
                .AddTransient<IPermissionXRoleDataController, PermissionXRoleDataController>()
                .AddTransient<IPermissionTypeDataController, PermissionTypeDataController>()
                .AddTransient<IPermissionDataController, PermissionDataController>()
                .AddTransient<IMenuXRoleDataController, MenuXRoleDataController>()
                .AddTransient<IMenuDataController, MenuDataController>()
                .AddTransient<IEmailXUserDataController, EmailXUserDataController>()
                //Logics
                .AddTransient<ILUser, LUser>()
                .AddTransient<ILUsuario, LUsuario>()
                .AddTransient<ILApiEndPoint, LApiEndPoint>()
                .AddTransient<ILTokenXUser, LTokenXUser>()
                .AddTransient<ILSessionXUser, LSessionXUser>()
                .AddTransient<ILRoleXUser, LRoleXUser>()
                .AddTransient<ILRole, LRole>()
                .AddTransient<ILPhoneXUser, LPhoneXUser>()
                .AddTransient<ILPermissionXType, LPermissionXType>()
                .AddTransient<ILPermissionXRole, LPermissionXRole>()
                .AddTransient<ILPermissionType, LPermissionType>()
                .AddTransient<ILPermission, LPermission>()
                .AddTransient<ILMenuXRole, LMenuXRole>()
                .AddTransient<ILMenu, LMenu>()
                .AddTransient<ILEmailXUser, LEmailXUser>();

        }

    }
}
