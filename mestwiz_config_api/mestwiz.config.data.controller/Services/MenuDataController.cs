

using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class MenuDataController: BaseDataController, IMenuDataController
    {
        public MenuDataController(IDataController dataController): base(dataController) { }

        public async Task<Menu> Get(int id)
        {
            return await this.GetEntity<Menu>().Where(menu => menu.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Menu>> Get()
        {
            return await this.GetEntity<Menu>().ToListAsync();
        }

    }
}
