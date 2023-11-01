
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IUsuarioDataController: IBaseDataController
    {
        public Task<User> Get(string id);
    }
}
