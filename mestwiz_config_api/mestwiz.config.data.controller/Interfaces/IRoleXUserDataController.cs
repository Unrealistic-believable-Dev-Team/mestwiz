
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IRoleXUserDataController: IBaseDataController
    {
        public Task<RoleXUser> Get(int id);

        public Task<List<RoleXUser>> GetByUserId(string id);

        public Task<List<RoleXUser>> GetByRoleId(int id);

        public Task<RoleXUser> GetByRoleAndUserId(int role_id, string user_id);
    }
}
