
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILRole : IBaseLogic<IRoleDataController>, IDisposable
    {
        public Task<Response<Role>> Get(int id);

        public Task<Response<Role>> GetByName(string name);

        public Task<Response<List<Role>>> Get();
    }
}
