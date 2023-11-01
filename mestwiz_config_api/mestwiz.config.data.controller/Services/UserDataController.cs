using mestwiz.config.data.controller.Interfaces;
using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;

namespace mestwiz.config.data.controller.Services
{
    public class UserDataController: BaseDataController, IUserDataController
    {

        public UserDataController(IDataController dataController) : base(dataController) { }

        public async Task<User> Get(string id)
        {
            return await this.GetEntity<User>().Where(u => u.id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<List<User>> Get()
        {
            return await this.GetEntity<User>().ToListAsync();
        }

        public async Task<User> GetByName(string name)
        {
            
            return await this.GetEntity<User>().Where(u => u.name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<User> Add(User User)
        {
            
            await this.GetEntity<User>().AddAsync(User);
            await this.SaveChangesAsync();
            return User;
        }


    }
}