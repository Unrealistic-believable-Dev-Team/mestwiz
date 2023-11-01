
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class PermissionXTypeDataController : BaseDataController, IPermissionXTypeDataController
    {

        public PermissionXTypeDataController(IDataController dataController): base(dataController) { }

        public async Task<PermissionXType> Get(int id)
        {
            return await this.GetEntity<PermissionXType>().Where(perxt => perxt.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PermissionXType>> GetByPermissionId(int id)
        {
            return await this.GetEntity<PermissionXType>().Where(perxt => perxt.perm_id == id).ToListAsync();
        }

        public async Task<List<PermissionXType>> GetByPermissionTypeId(int id)
        {
            return await this.GetEntity<PermissionXType>().Where(perxt => perxt.permt_id == id).ToListAsync();
        }

        public async Task<List<PermissionXType>> GetByPermissionTypeAndPermissionId(int permt_id, int perm_id)
        {
            return await this.GetEntity<PermissionXType>().Where(perxt => perxt.permt_id == permt_id && perxt.perm_id == perm_id).ToListAsync();
        }
    }
}
