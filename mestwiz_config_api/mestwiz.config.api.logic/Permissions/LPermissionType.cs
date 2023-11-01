
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Permissions
{
    public class LPermissionType : BaseLogic<IPermissionTypeDataController>, ILPermissionType
    {
        public LPermissionType(IPermissionTypeDataController dataController) : base(dataController) { }

        public async Task<Response<PermissionType>> Get(int id)
        {
            Response<PermissionType> response = new()
            {
                data = await dataController.Get(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El tipo de Permiso no existe.", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<PermissionType>>> Get()
        {
            Response<List<PermissionType>> response = new()
            {
                data = await dataController.Get()
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "No hay Tipos de Permisos", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
