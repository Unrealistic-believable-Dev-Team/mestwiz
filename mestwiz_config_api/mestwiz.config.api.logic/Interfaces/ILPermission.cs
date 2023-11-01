
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILPermission : IBaseLogic<IPermissionDataController>, IDisposable
    {
        public Task<Response<Permission>> Get(int id);

        public Task<Response<List<Permission>>> Get();
    }
}
