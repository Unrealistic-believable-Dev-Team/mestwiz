
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILPermissionType : IBaseLogic<IPermissionTypeDataController>, IDisposable
    {
        public Task<Response<PermissionType>> Get(int id);

        public Task<Response<List<PermissionType>>> Get();
    }
}
