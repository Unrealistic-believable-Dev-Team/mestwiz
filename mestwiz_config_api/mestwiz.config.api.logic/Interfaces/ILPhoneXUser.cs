
using mestwiz.config.data.entities;
using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILPhoneXUser : IBaseLogic<IPhoneXUserDataController>, IDisposable
    {
        public Task<Response<PhoneXUser>> Get(string id);

        public Task<Response<List<PhoneXUser>>> GetByUserId(string id);
    }
}
