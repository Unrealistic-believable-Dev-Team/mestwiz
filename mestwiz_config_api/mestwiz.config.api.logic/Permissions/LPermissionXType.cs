
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.api.logic.Interfaces;

namespace mestwiz.config.api.logic.Permissions
{
    public class LPermissionXType : BaseLogic<IPermissionXTypeDataController>, ILPermissionXType
    {
        public LPermissionXType(IPermissionXTypeDataController dataController) : base(dataController) { }
        
        public async Task<Response<PermissionXType>> Get(int id)
        {
            Response<PermissionXType> response = new()
            {
                data = await dataController.Get(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no pertenece al Tipo", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<PermissionXType>>> GetByPermissionId(int id)
        {
            Response<List<PermissionXType>> response = new()
            {
                data = await dataController.GetByPermissionId(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no pertenece al Tipo", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<PermissionXType>>> GetByPermissionTypeId(int id)
        {
            Response<List<PermissionXType>> response = new()
            {
                data = await dataController.GetByPermissionTypeId(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no pertenece al Tipo", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<PermissionXType>>> GetByPermissionTypeAndPermissionId(int permt_id, int perm_id)
        {
            Response<List<PermissionXType>> response = new()
            {
                data = await dataController.GetByPermissionTypeAndPermissionId(permt_id, perm_id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Permiso no pertenece al Tipo", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

    }
}
