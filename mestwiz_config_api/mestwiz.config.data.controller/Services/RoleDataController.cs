
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class RoleDataController : BaseDataController, IRoleDataController
    {
        
        public RoleDataController(IDataController dataController): base(dataController) { }

        public async Task<Role> Get(int id)
        {
            return await this.GetEntity<Role>().Where(role => role.id == id).FirstOrDefaultAsync();
        }

        public async Task<Role> GetByName(string name)
        {
            return await this.GetEntity<Role>().Where(role => role.name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Role>> Get()
        {
            return await this.GetEntity<Role>().ToListAsync();
        }
    }
}
