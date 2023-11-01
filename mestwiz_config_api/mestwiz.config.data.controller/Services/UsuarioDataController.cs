using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class UsuarioDataController : BaseDataController, IUsuarioDataController
    {
        public UsuarioDataController(IDataController dataController): base(dataController) { }

        public async Task<User> Get(string id)
        {
            return await this.GetEntity<User>().Where(u => u.id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
