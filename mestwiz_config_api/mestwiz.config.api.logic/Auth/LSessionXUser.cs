using mestwiz.config.api.entities;
using mestwiz.config.api.logic.Interfaces;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Auth
{
    public class LSessionXUser : BaseLogic<ISessionXUserDataController>, ILSessionXUser
    {
        public LSessionXUser(ISessionXUserDataController dataController) : base(dataController) { }

        public async Task<Response<SessionXUser>> Get(string Id)
        {

            Response<SessionXUser> response = new Response<SessionXUser>();
            response.data = await dataController.Get(Id);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "La sesión no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<SessionXUser>> GetForLogin(string id, string user_host)
        {

            Response<SessionXUser> response = new Response<SessionXUser>();
            response.data = await dataController.GetForLogin(id, user_host);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "La sesión no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }

        public async Task<Response<SessionXUser>> GetByUserId(string user_id, string user_host)
        {

            Response<SessionXUser> response = new Response<SessionXUser>();
            response.data = await dataController.GetByUserId(user_id, user_host);

            if (response.data == null)
                response.message.AddError(new MessageError() { Error = "La sesión no Existe", TypeMessageError = TypeMessageError.Exception });
            else
                response.message.status = ResponseStatus.Success;

            return response;
        }


        public async Task<Response<SessionXUser>> Add(SessionXUser sessionXUser)
        {

            Response<SessionXUser> response = new();
            response.data = await this.dataController.Add(sessionXUser);

            return response;
        }

        public async Task<Response<bool>> Delete(string id)
        {
            Response<bool> response = new ();
            response.data = await this.dataController.Delete(id);

            if(response.data)
                await this.dataController.CommitAsync();

            return response;
        }

        public async Task<Response<bool>> DeleteFromUser(string user_id)
        {
            Response<bool> response = new();
            response.data = await dataController.DeleteFromUser(user_id);

            if (response.data)
                await dataController.CommitAsync();

            return response;
        }

        public async Task<Response<bool>> DeleteFromUser(string user_id, string host)
        {
            Response<bool> response = new();
            response.data = await dataController.DeleteFromUser(user_id, host);

            if (response.data)
                await this.dataController.CommitAsync();

            return response;
        }

    }
}
