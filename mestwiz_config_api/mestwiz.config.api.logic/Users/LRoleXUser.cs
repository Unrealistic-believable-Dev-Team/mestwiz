
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Users
{
    public class LRoleXUser : BaseLogic<IRoleXUserDataController>, ILRoleXUser
    {
        public LRoleXUser(IRoleXUserDataController dataController): base(dataController) { }

        public async Task<Response<RoleXUser>> Get(int id)
        {
            Response<RoleXUser> response = new()
            {
                data = await dataController.Get(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Rol no pertenece al Usuario", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<RoleXUser>>> GetByUserId(string id)
        {
            Response<List<RoleXUser>> response = new()
            {
                data = await dataController.GetByUserId(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Rol no pertenece al Usuario", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<RoleXUser>>> GetByRoleId(int id)
        {
            Response<List<RoleXUser>> response = new()
            {
                data = await dataController.GetByRoleId(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Rol no pertenece al Usuario", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<RoleXUser>> GetByRoleAndUserId(int role_id, string user_id)
        {
            Response<RoleXUser> response = new()
            {
                data = await dataController.GetByRoleAndUserId(role_id, user_id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Rol no pertenece al Usuario", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
