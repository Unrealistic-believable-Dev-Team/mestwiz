
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IPermissionTypeDataController: IBaseDataController
    {
        public Task<PermissionType> Get(int id);

        public Task<List<PermissionType>> Get();
    }
}
