using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureZumoApp.Persistence
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        IMobileServiceSyncTable<TEntity> _table;

        public Repository(IMobileServiceSyncTable<TEntity> table)
        {
            _table = table;
        }

        public Task AddAsync(TEntity entity)
        {
            return _table.InsertAsync(entity);
        }

        public Task<TEntity> GetById(string id)
        {
            return _table.LookupAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetDirectory()
        {
            return await _table.ToListAsync();
        }

        public async Task RemoveAsync(string id)
        {
            var entity = await GetById(id);
            await _table.DeleteAsync(entity);
        }

        public Task RemoveAsync(TEntity entity)
        {
            return _table.DeleteAsync(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
