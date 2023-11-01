
using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class EmailXUserDataController : BaseDataController, IEmailXUserDataController
    {

        public EmailXUserDataController(IDataController dataController): base(dataController) { }

        public async Task<EmailXUser> Get(string id)
        {
            return await this.GetEntity<EmailXUser>().Where(exu => exu.id == id).FirstOrDefaultAsync();
        }

        public async Task<EmailXUser> Add(EmailXUser email)
        {

            await this.GetEntity<EmailXUser>().AddAsync(email);

            await this.SaveChangesAsync();

            return email;
        }
    }
}
