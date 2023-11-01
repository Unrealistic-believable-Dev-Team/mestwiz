
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Permissions
{
    public class LPermission : BaseLogic<IPermissionDataController>, ILPermission
    {
        public LPermission(IPermissionDataController dataController) : base(dataController) { }

        public async Task<Response<Permission>> Get(int id)
        {
            Response<Permission> response = new()
            {
                data = await dataController.Get(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<Permission>>> Get()
        {
            Response<List<Permission>> response = new()
            {
                data = await dataController.Get()
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "No hay Permisos registrados", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
