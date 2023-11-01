
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class PhoneXUserDataController: BaseDataController, IPhoneXUserDataController
    {
        public PhoneXUserDataController(IDataController dataController): base(dataController) { }

        public async Task<PhoneXUser> Get(string id)
        {
            return await this.GetEntity<PhoneXUser>().Where(phone => phone.id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PhoneXUser>> GetByUserId(string id)
        {
            return await this.GetEntity<PhoneXUser>().Where(phone => phone.user_id == id).ToListAsync();
        }

    }
}
