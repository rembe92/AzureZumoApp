using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureZumoApp.Persistence
{
    interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        Task RemoveAsync(string id);

        Task RemoveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetDirectory();

        Task<TEntity> GetById(string id);
    }
}
