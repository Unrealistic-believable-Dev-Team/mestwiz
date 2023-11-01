using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using mestwiz.config.data.entities.Functions;

namespace mestwiz.config.api.logic.Users
{
    public class LEmailXUser : BaseLogic<IEmailXUserDataController>, ILEmailXUser
    {
        public LEmailXUser(IEmailXUserDataController dataController) : base(dataController) { }

        public async Task<Response<EmailXUser>> Add(EmailXUser emailXUser)
        {
            Response<EmailXUser> response = new();

            response.message = await ValidateNew(emailXUser);
            if (response.message.status != ResponseStatus.Success)
            {
                await this.dataController.RollbackAsync();
                return response;
            }
               
            response.data = await dataController.Add(emailXUser);
            response.message.status = ResponseStatus.Success; 

            return response;
        }

        public async Task<Response<EmailXUser>> Get(string id)
        {
            Response<EmailXUser> response = new Response<EmailXUser>();
            response.data = await dataController.Get(id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "El Email no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Message> ValidateNew(EmailXUser emailXUser)
        {
            Message _Message = new Message();

            if (emailXUser == null)
            {
                _Message.AddError(new MessageError() { Error = "Email no valido" });
                return _Message;
            }

            if(await emailXUser.user_id.IsNullString())
                _Message.AddError(new MessageError() { Error = "Email no valido" });

            if (await emailXUser.id.IsNullString() ? true : !await emailXUser.id.IsValidEmail())
                _Message.AddError(new MessageError() { Error = "Email no valido, formato incorrecto" });
            else
            {
                Response<EmailXUser> response = await Get(emailXUser.id);
                if (response.message.status == ResponseStatus.Success)
                    _Message.AddError(new MessageError() { Error = "Email no valido, ya se registró con otro Usuario." });
            }

            return _Message;
        }
    }
}
