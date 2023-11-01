
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.api.logic.Interfaces;

namespace mestwiz.config.api.logic.Users
{
    public class LPhoneXUser : BaseLogic<IPhoneXUserDataController>, ILPhoneXUser
    {
        public LPhoneXUser(IPhoneXUserDataController dataController) : base(dataController) { }

        public async Task<Response<PhoneXUser>> Get(string id)
        {
            Response<PhoneXUser> response = new()
            {
                data = await dataController.Get(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El telefono no existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<List<PhoneXUser>>> GetByUserId(string id)
        {
            Response<List<PhoneXUser>> response = new()
            {
                data = await dataController.GetByUserId(id)
            };

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El telefono no existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }
    }
}
