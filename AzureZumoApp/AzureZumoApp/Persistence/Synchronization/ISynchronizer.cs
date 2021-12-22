using System.Threading.Tasks;
using System;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AzureZumoApp
{
    public interface ISynchronizer<T>
    {
        Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeIncrementalAsync(string queryId);
        
        Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeIncrementalAsync(string queryId, Expression<Func<T, bool>> predicate);
        
        Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeAbsolutAsync();

        Task<IReadOnlyCollection<MobileServiceTableOperationError>> PushAsync();

        Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeAbsolutAsync(Expression<Func<T, bool>> predicate);

        long GetPendingOperations();
    }
}
