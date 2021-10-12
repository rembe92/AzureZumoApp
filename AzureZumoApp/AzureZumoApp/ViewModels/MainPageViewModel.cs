using AzureZumoApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureZumoApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        IMobileServiceClient client;
        MobileServiceSQLiteStore mStore;
        IMobileServiceSyncTable<TodoItem> todoTable;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            client = new MobileServiceClient("https://zumo-5nfvbshhcfey2.azurewebsites.net", new LoggingHandler());
            
            mStore = new MobileServiceSQLiteStore("ZumoLocal.db");
            mStore.DefineTable<TodoItem>();
            await client.SyncContext.InitializeAsync(mStore);
            todoTable = client.GetSyncTable<TodoItem>();

            await SynchronizeAsync();


            var items = await todoTable.ToListAsync();
            //await todoTable.InsertAsync(new TodoItem() { Text = "without Completed" });



            base.OnNavigatedTo(parameters);
        }

        public async Task SynchronizeAsync()
        {
            IReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                await client.SyncContext.PushAsync().ConfigureAwait(false);
                await todoTable.PullAsync("todoitems", todoTable.CreateQuery()).ConfigureAwait(false);
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
