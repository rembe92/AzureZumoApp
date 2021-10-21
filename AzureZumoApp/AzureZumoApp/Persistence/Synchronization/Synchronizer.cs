using AzureZumoApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureZumoApp
{
    public class Synchronizer<T> : ISynchronizer<T>
    {
        IMobileServiceSyncTable<T> _mobileServiceSyncTable;
        IMobileServiceClient _client;

        public Synchronizer(IMobileServiceSyncTable<T> mobileServiceSyncTable)
        {
            _mobileServiceSyncTable = mobileServiceSyncTable;
        }

        private async Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeAsync(string queryId, Expression<Func<T, bool>> predicate)
        {
            IReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                //doing a implicit push if there a pending operations in the queue
                if (predicate != null)
                    await _mobileServiceSyncTable.PullAsync(queryId, _mobileServiceSyncTable.CreateQuery().Where(predicate)).ConfigureAwait(false);
                else
                    await _mobileServiceSyncTable.PullAsync(queryId, _mobileServiceSyncTable.CreateQuery()).ConfigureAwait(false);
            }
            catch (MobileServicePushFailedException error)
            {
                if (error.PushResult != null)
                {
                    syncErrors = error.PushResult.Errors;
                }
            }

            return syncErrors;
        }

        public Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeAbsolutAsync()
        {
            return SynchronizeAsync(null, null);
        }

        public Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeAbsolutAsync(Expression<Func<T, bool>> predicate)
        {
            return SynchronizeAsync(null, predicate);
        }

        public Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeIncrementalAsync(string queryId)
        {
            return SynchronizeAsync(queryId, null);
        }

        public Task<IReadOnlyCollection<MobileServiceTableOperationError>> SynchronizeIncrementalAsync(string queryId, Expression<Func<T, bool>> predicate)
        {
            return SynchronizeAsync(queryId, predicate);
        }
    }
}
