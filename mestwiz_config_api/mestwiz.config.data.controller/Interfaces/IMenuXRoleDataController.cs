

using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IMenuXRoleDataController: IBaseDataController
    {
        public Task<MenuXRole> Get(int id);

        public Task<List<MenuXRole>> GetByRoleId(int role_id);

        public Task<List<MenuXRole>> GetByMenuId(int menu_id);

        public Task<MenuXRole> GetByRoleAndMenuId(int menu_id, int role_id);

    }
}
