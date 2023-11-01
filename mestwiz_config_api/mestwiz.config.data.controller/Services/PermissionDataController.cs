using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class PermissionDataController : BaseDataController, IPermissionDataController
    {
        public PermissionDataController(IDataController dataController): base(dataController) { }

        public async Task<Permission> Get(int id)
        {
            return await this.GetEntity<Permission>().Where(perm => perm.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Permission>> Get()
        {
            return await this.GetEntity<Permission>().ToListAsync();
        }
    }
}
