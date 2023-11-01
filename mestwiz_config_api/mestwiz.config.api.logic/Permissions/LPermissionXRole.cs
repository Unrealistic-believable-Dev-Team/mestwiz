
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.api.logic.Interfaces;

namespace mestwiz.config.api.logic.Permissions
{
    public class LPermissionXRole : BaseLogic<IPermissionXRoleDataController>, ILPermissionXRole
    {
        public LPermissionXRole(IPermissionXRoleDataController dataController) : base(dataController) { }

        public async Task<Response<PermissionXRole>> Get(int id)
        {
            Response<PermissionXRole> response = new() 
            { 
                data = await dataController.Get(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no pertenece al Rol", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<PermissionXRole>>> GetByRoleId(int id)
        {
            Response<List<PermissionXRole>> response = new()
            {
                data = await dataController.GetByRoleId(id)
            };
            
            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no pertenece al Rol", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<PermissionXRole>>> GetByPermissionId(int id)
        {
            Response<List<PermissionXRole>> response = new()
            {
                data = await dataController.GetByPermissionId(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no pertenece al Rol", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<PermissionXRole>>> GetByPermissionAndRoleId(int perm_id, int role_id)
        {
            Response<List<PermissionXRole>> response = new()
            {
                data = await dataController.GetByPermissionAndRoleId(perm_id, role_id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no pertenece al Rol", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

    }
}
