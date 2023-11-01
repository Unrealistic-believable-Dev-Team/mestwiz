using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;


namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILUsuario : IBaseLogic<IUsuarioDataController>
    {
        public Task<Response<User>> Get(string Id);
    }
}
