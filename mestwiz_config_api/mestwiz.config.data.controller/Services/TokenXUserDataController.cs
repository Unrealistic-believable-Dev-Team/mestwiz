
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class TokenXUserDataController : BaseDataController, ITokenXUserDataController
    {
        public TokenXUserDataController(IDataController dataController): base(dataController) { }

        public async Task<TokenXUser> Get(string id)
        {
            return await this.GetEntity<TokenXUser>().Where(token => token.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TokenXUser>> GetByUserId(string id)
        {
            return await this.GetEntity<TokenXUser>().Where(token => token.user_id == id).ToListAsync();
        }

    }
}
