using mestwiz.config.api.entities;
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;

namespace mestwiz.config.api.logic.Interfaces
{
    public interface ILEmailXUser : IBaseLogic<IEmailXUserDataController>, IDisposable
    {
        public Task<Response<EmailXUser>> Add(EmailXUser emailXUser);

        public Task<Response<EmailXUser>> Get(string id);

        public Task<Message> ValidateNew(EmailXUser emailXUser);
    }
}
