using mestwiz.config.data.controller.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace mestwiz.config.data.controller.Services
{
    public class BaseDataController :  IBaseDataController
    {
        private readonly IDataController dataController;

        public void Dispose()
        {
            this.dataController?.Dispose();
        }

        public BaseDataController(IDataController dataController)
        {
            this.dataController = dataController;
        }

        public IDbContextTransaction GetDbTransaction()
        {
            return dataController.GetDbTransaction();
        }
      
        public async Task SavepointAsync(string puntoSalvado)
        {
           await this.dataController.SavepointAsync(puntoSalvado);
        }

        public async Task CommitAsync()
        {
            await this.dataController.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await this.dataController.RollbackAsync();
        }

        public async Task RollbackToSavepointAsync(string puntoSalvado)
        {
            await this.dataController.RollbackToSavepointAsync(puntoSalvado);
        }

        public async Task SaveChangesAsync()
        {
            await this.dataController.SaveChangesAsync();
        }

        public DbSet<T> GetEntity<T>() where T : class 
        {
            return this.dataController.GetEntity<T>();
        }
    }
}
