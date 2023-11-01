using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class PermissionXRoleDataController: BaseDataController, IPermissionXRoleDataController 
    {
        public PermissionXRoleDataController(IDataController dataController): base(dataController) { }

        public async Task<PermissionXRole> Get(int id)
        {
            return await this.GetEntity<PermissionXRole>().Where(pero=> pero.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PermissionXRole>> GetByRoleId(int id)
        {
            return await this.GetEntity<PermissionXRole>().Where(pero => pero.role_id == id).ToListAsync();
        }

        public async Task<List<PermissionXRole>> GetByPermissionId(int id)
        {
            return await this.GetEntity<PermissionXRole>().Where(pero => pero.perm_id == id).ToListAsync();
        }

        public async Task<List<PermissionXRole>> GetByPermissionAndRoleId(int perm_id, int role_id)
        {
            return await this.GetEntity<PermissionXRole>().Where(pero => pero.role_id == role_id && pero.perm_id == perm_id).ToListAsync();
        }
    }
}
