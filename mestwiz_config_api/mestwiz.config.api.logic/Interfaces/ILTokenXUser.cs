
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILTokenXUser : IDisposable, IBaseLogic<ITokenXUserDataController>
    {
        public Task<Response<TokenXUser>> Get(string id);

        public Task<Response<List<TokenXUser>>> GetByUserId(string id);
    }
}
