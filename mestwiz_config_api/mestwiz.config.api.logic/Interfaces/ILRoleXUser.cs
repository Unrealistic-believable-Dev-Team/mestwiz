
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILRoleXUser : IBaseLogic<IRoleXUserDataController>, IDisposable
    {
        public Task<Response<RoleXUser>> Get(int id);

        public Task<Response<List<RoleXUser>>> GetByUserId(string id);

        public Task<Response<List<RoleXUser>>> GetByRoleId(int id);

        public Task<Response<RoleXUser>> GetByRoleAndUserId(int role_id, string user_id);
    }
}
