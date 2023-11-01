
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILPermissionXRole : IBaseLogic<IPermissionXRoleDataController>, IDisposable
    {

        public Task<Response<PermissionXRole>> Get(int id);

        public Task<Response<List<PermissionXRole>>> GetByRoleId(int id);

        public Task<Response<List<PermissionXRole>>> GetByPermissionId(int id);

        public Task<Response<List<PermissionXRole>>> GetByPermissionAndRoleId(int perm_id, int role_id);

    }
}
