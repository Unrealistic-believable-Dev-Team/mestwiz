
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class PermissionTypeDataController: BaseDataController, IPermissionTypeDataController
    {
        public PermissionTypeDataController(IDataController dataController): base(dataController) { }

        public async Task<PermissionType> Get(int id)
        {
            return await this.GetEntity<PermissionType>().Where(permt => permt.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PermissionType>> Get()
        {
            return await this.GetEntity<PermissionType>().ToListAsync();
        }
    }
}
