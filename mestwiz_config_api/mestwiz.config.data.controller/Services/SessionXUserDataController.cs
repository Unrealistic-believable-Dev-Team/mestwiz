
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class SessionXUserDataController: BaseDataController, ISessionXUserDataController
    {
        public SessionXUserDataController(IDataController dataController): base(dataController) { }

        public async Task<SessionXUser> Get(string Id)
        {
            return await this.GetEntity<SessionXUser>().Where(s => s.id == Id).FirstOrDefaultAsync();
        }

        public async Task<SessionXUser> GetForLogin(string id, string user_host)
        {
            return await this.GetEntity<SessionXUser>().OrderByDescending(s => s.access_date).Where(s => s.id == id && s.host == user_host && s.status == "AC").FirstOrDefaultAsync();
        }

        public async Task<SessionXUser> GetByUserId(string user_id, string user_host)
        {
            return await this.GetEntity<SessionXUser>().OrderByDescending(s => s.access_date).Where(s => s.user_id == user_id && s.host == user_host && s.status == "AC").FirstOrDefaultAsync();
        }

        public async Task<List<SessionXUser>> GetAllByUserId(string user_id, string user_host)
        {
            return await this.GetEntity<SessionXUser>().OrderByDescending(s => s.access_date).Where(s => s.user_id == user_id && s.host == user_host).ToListAsync();
        }

        public async Task<List<SessionXUser>> GetAllByUserId(string user_id)
        {
            return await this.GetEntity<SessionXUser>().OrderByDescending(s => s.access_date).Where(s => s.user_id == user_id).ToListAsync();
        }

        public async Task<SessionXUser> Update(SessionXUser sessionXUser){
            SessionXUser sessionXUserU = await Get(sessionXUser.id);

            sessionXUserU.status = sessionXUser.status;
            sessionXUserU.access_date = sessionXUser.access_date;
            sessionXUserU.close_date = sessionXUser.close_date;
            
            await this.SaveChangesAsync();

            return sessionXUser;
        }

        public async Task<bool> Delete(string id)
        {
            SessionXUser sessionXUser = await Get(id);
            this.GetEntity<SessionXUser>().Remove(sessionXUser);
            await this.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFromUser(string user_id)
        {
            List<SessionXUser> sessionXUser = await GetAllByUserId(user_id);

            this.GetEntity<SessionXUser>().RemoveRange(sessionXUser);
            await this.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFromUser(string user_id, string host)
        {
            List<SessionXUser> sessionXUser = await GetAllByUserId(user_id, host);

            this.GetEntity<SessionXUser>().RemoveRange(sessionXUser);
            await this.SaveChangesAsync();

            return true;
        }

        public async Task<SessionXUser> Add(SessionXUser sessionXUser)
        {
            await this.GetEntity<SessionXUser>().AddAsync(sessionXUser);
            await this.SaveChangesAsync();
            return sessionXUser;
        }

    }
}
