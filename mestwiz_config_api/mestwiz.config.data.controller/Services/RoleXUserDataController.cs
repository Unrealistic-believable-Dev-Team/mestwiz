
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class RoleXUserDataController: BaseDataController, IRoleXUserDataController
    {
        public RoleXUserDataController(IDataController dataController): base(dataController) { }

        public async Task<RoleXUser> Get(int id)
        {
            return await this.GetEntity<RoleXUser>().Where(role => role.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<RoleXUser>> GetByUserId(string id)
        {
            return await this.GetEntity<RoleXUser>().Where(role => role.user_id == id).ToListAsync();
        }

        public async Task<List<RoleXUser>> GetByRoleId(int id)
        {
            return await this.GetEntity<RoleXUser>().Where(role => role.role_id == id).ToListAsync();
        }

        public async Task<RoleXUser> GetByRoleAndUserId(int role_id, string user_id)
        {
            return await this.GetEntity<RoleXUser>().Where(role => role.role_id == role_id && role.user_id == user_id).FirstOrDefaultAsync();
        }

    }
}
