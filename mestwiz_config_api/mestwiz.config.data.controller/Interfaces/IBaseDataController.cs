using mestwiz.config.data.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace mestwiz.config.data.controller.Interfaces
{
    public interface IBaseDataController : IDisposable
    {
        public DbSet<T> GetEntity<T>() where T : class;
        public IDbContextTransaction GetDbTransaction();
        public Task SavepointAsync(string puntoSalvado);
        public Task CommitAsync();
        public Task RollbackAsync();
        public Task RollbackToSavepointAsync(string puntoSalvado);
        public Task SaveChangesAsync();
    }
}
