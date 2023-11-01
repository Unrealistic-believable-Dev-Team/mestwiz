using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILSessionXUser : IBaseLogic<ISessionXUserDataController>, IDisposable
    {

        public Task<Response<SessionXUser>> Get(string Id);

        public Task<Response<SessionXUser>> GetForLogin(string id, string user_host);

        public Task<Response<SessionXUser>> GetByUserId(string user_id, string user_host);

        public Task<Response<SessionXUser>> Add(SessionXUser sessionXUser);

        public Task<Response<bool>> Delete(string id);

        public Task<Response<bool>> DeleteFromUser(string user_id);

        public Task<Response<bool>> DeleteFromUser(string user_id, string host);

    }
}
