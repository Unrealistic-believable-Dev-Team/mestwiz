
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILMenuXRole : IBaseLogic<IMenuXRoleDataController>, IDisposable
    {
        public Task<Response<MenuXRole>> Get(int id);

        public Task<Response<List<MenuXRole>>> GetByRoleId(int role_id);

        public Task<Response<List<MenuXRole>>> GetByMenuId(int menu_id);

        public Task<Response<MenuXRole>> GetByRoleAndMenuId(int menu_id, int role_id);
    }
}
