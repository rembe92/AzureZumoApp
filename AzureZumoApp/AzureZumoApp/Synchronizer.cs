using AzureZumoApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureZumoApp
{
    public class Synchronizer
    {
        IMobileServiceClient _client;

        IMobileServiceSyncTable<TodoItem> _todoTable;

        public Synchronizer(IMobileServiceClient client, IMobileServiceSyncTable<TodoItem> todoTable)
        {
            _client = client;
            _todoTable = todoTable;
        }
        public async Task SynchronizeAsync()
        {
            IReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                await _client.SyncContext.PushAsync().ConfigureAwait(false);
                await _todoTable.PullAsync("todoitems", _todoTable.CreateQuery()).ConfigureAwait(false);
            }
            catch (MobileServicePushFailedException error)
            {
                if (error.PushResult != null)
                {
                    syncErrors = error.PushResult.Errors;
                }
            }

            if (syncErrors != null)
            {
                foreach (var syncError in syncErrors)
                {
                    if (syncError.OperationKind == MobileServiceTableOperationKind.Update && syncError.Result != null)
                    {
                        // Prefer server copy
                        await syncError.CancelAndUpdateItemAsync(syncError.Result).ConfigureAwait(false);
                    }
                    else
                    {
                        // Discard local copy
                        await syncError.CancelAndDiscardItemAsync().ConfigureAwait(false);
                    }
                }
            }
        }
    }
}
