
using mestwiz.config.data.entities;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IEmailXUserDataController : IBaseDataController
    {
        public Task<EmailXUser> Get(string id);

        public Task<EmailXUser> Add(EmailXUser email);
    }
}
