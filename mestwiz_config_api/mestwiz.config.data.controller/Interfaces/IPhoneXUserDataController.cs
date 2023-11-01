
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IPhoneXUserDataController: IBaseDataController
    {
        public Task<PhoneXUser> Get(string id);

        public Task<List<PhoneXUser>> GetByUserId(string id);
    }
}
