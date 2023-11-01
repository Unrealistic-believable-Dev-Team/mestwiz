

using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class MenuXRoleDataController: BaseDataController, IMenuXRoleDataController
    {

        public MenuXRoleDataController(IDataController dataController): base(dataController) { }

        public async Task<MenuXRole> Get(int id)
        {
            return await this.GetEntity<MenuXRole>().Where(mexu => mexu.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<MenuXRole>> GetByRoleId(int role_id)
        {
            return await this.GetEntity<MenuXRole>().Where(mexu => mexu.role_id == role_id).ToListAsync();
        }

        public async Task<List<MenuXRole>> GetByMenuId(int menu_id)
        {
            return await this.GetEntity<MenuXRole>().Where(mexu => mexu.menu_id == menu_id).ToListAsync();
        }

        public async Task<MenuXRole> GetByRoleAndMenuId(int menu_id, int role_id)
        {
            return await this.GetEntity<MenuXRole>().Where(mexu => mexu.menu_id == menu_id && mexu.role_id == role_id).FirstOrDefaultAsync();
        }
    }
}
