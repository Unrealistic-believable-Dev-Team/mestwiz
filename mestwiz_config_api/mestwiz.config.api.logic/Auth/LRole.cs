
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Auth
{
    public class LRole : BaseLogic<IRoleDataController>, ILRole
    {
        public LRole(IRoleDataController dataController) : base(dataController) { }
  
        public async Task<Response<Role>> Get(int id)
        {
            Response<Role> response = new()
            {
                data = await dataController.Get(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Rol no existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<Role>> GetByName(string name)
        {
            Response<Role> response = new()
            {
                data = await dataController.GetByName(name)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Rol no existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<Role>>> Get()
        {
            Response<List<Role>> response = new()
            {
                data = await dataController.Get()
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "No hay Roles registrados", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
