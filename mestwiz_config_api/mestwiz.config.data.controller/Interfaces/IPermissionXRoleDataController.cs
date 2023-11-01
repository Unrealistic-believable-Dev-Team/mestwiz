using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IPermissionXRoleDataController : IBaseDataController
    {
        public Task<PermissionXRole> Get(int id);

        public Task<List<PermissionXRole>> GetByRoleId(int id);

        public Task<List<PermissionXRole>> GetByPermissionId(int id);

        public Task<List<PermissionXRole>> GetByPermissionAndRoleId(int perm_id, int role_id);
    }
}
