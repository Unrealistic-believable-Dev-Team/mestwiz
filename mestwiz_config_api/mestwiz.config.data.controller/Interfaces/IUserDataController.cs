
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IUserDataController: IBaseDataController
    {
        public Task<User> Get(string id);

        public Task<List<User>> Get();

        public Task<User> GetByName(string name);

        public Task<User> Add(User User);
    }
}