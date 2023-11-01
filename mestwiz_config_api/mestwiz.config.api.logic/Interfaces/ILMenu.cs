using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILMenu : IBaseLogic<IMenuDataController>, IDisposable
    {
        public Task<Response<Menu>> Get(int id);

        public Task<Response<List<Menu>>> Get();
    }
}
