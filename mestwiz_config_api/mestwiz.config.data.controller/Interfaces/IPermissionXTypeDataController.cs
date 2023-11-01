
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IPermissionXTypeDataController: IBaseDataController
    {
        public Task<PermissionXType> Get(int id);

        public Task<List<PermissionXType>> GetByPermissionId(int id);

        public  Task<List<PermissionXType>> GetByPermissionTypeId(int id);

        public Task<List<PermissionXType>> GetByPermissionTypeAndPermissionId(int permt_id, int perm_id);
    }
}
