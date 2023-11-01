
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IMenuDataController: IBaseDataController
    {
        public Task<Menu> Get(int id);

        public Task<List<Menu>> Get();

    }
}
