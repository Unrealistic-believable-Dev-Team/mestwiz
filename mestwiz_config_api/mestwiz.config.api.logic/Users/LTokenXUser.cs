
using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Users
{
    public class LTokenXUser: BaseLogic<ITokenXUserDataController>, ILTokenXUser
    {
        public LTokenXUser(ITokenXUserDataController dataController): base(dataController) { }

        public async Task<Response<TokenXUser>> Get(string id)
        {
            Response<TokenXUser> response = new()
            {
                data = await dataController.Get(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Token no pertenece al Usuario", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<TokenXUser>>> GetByUserId(string id)
        {
            Response<List<TokenXUser>> response = new()
            {
                data = await dataController.GetByUserId(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Token no pertenece al Usuario", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
