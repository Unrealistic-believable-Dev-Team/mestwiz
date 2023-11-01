using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IPermissionDataController : IBaseDataController
    {
        public Task<Permission> Get(int id);

        public Task<List<Permission>> Get();
    }
}
