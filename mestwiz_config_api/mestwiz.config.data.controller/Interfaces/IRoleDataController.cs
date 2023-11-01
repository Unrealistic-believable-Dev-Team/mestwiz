
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IRoleDataController: IBaseDataController
    {
        public Task<Role> Get(int id);

        public Task<Role> GetByName(string name);

        public Task<List<Role>> Get();
    }
}
