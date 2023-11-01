
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILPermissionXType : IBaseLogic<IPermissionXTypeDataController>, IDisposable
    {
        public Task<Response<PermissionXType>> Get(int id);

        public Task<Response<List<PermissionXType>>> GetByPermissionId(int id);

        public Task<Response<List<PermissionXType>>> GetByPermissionTypeId(int id);

        public Task<Response<List<PermissionXType>>> GetByPermissionTypeAndPermissionId(int permt_id, int perm_id);

    }
}
