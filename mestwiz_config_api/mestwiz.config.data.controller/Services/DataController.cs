using mestwiz.config.data.access;
using mestwiz.config.data.access.Services;
using mestwiz.config.data.controller.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace mestwiz.config.data.controller.Services
{
    public class DataController : IDataController
    {
        private readonly DataContext DataContext;
        private IDbContextTransaction Transaction;

        public void Dispose()
        {
            this.DataContext?.Dispose();
            this.Transaction?.Dispose();
        }

        public DataController(DataContext dataContext)
        {
            this.DataContext = dataContext;

            this.Transaction = this.DataContext.Database.CurrentTransaction == null ? this.DataContext.Database.BeginTransaction() : this.DataContext.Database.CurrentTransaction;
        }

        public string GetBDConnectionString()
        {
            return Settings.DBConnectionString;
        }

        public DbSet<T> GetEntity<T>() where T : class
        {
            return this.DataContext.Set<T>();
        }

        public async Task<DataController> SetTransaction(IDbContextTransaction Transaction)
        {
            this.Transaction = await this.DataContext.Database.UseTransactionAsync(Transaction.GetDbTransaction());

            return this;
        }

        public IDbContextTransaction GetDbTransaction()
        {
            return this.Transaction;
        }

        public async Task SavepointAsync(string puntoSalvado)
        {
            await this.Transaction.CreateSavepointAsync(puntoSalvado);
        }

        public async Task SaveChangesAsync()
        {
            await this.DataContext.SaveChangesAsync();
        }

        public async Task CommitAsync()
        {
            await this.Transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await this.Transaction.RollbackAsync();
        }

        public async Task RollbackToSavepointAsync(string puntoSalvado)
        {
            await this.Transaction.RollbackToSavepointAsync(puntoSalvado);
        }

    }
}
