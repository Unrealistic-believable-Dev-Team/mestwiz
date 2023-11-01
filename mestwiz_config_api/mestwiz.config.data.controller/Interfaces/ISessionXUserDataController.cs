
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface ISessionXUserDataController: IBaseDataController
    {
        public Task<SessionXUser> Get(string Id);

        public Task<SessionXUser> GetForLogin(string id, string user_host);

        public Task<SessionXUser> GetByUserId(string user_id, string user_host);

        public Task<List<SessionXUser>> GetAllByUserId(string user_id, string user_host);

        public Task<List<SessionXUser>> GetAllByUserId(string user_id);

        public Task<SessionXUser> Update(SessionXUser sessionXUser);

        public Task<bool> Delete(string id);

        public Task<bool> DeleteFromUser(string user_id);

        public Task<bool> DeleteFromUser(string user_id, string host);

        public Task<SessionXUser> Add(SessionXUser sessionXUser);

    }
}
