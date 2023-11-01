
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface ITokenXUserDataController: IBaseDataController
    {
        public Task<TokenXUser> Get(string id);

        public Task<List<TokenXUser>> GetByUserId(string id);

    }
}
