using AzureZumoApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using System;
using System.Diagnostics;

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
            try
            {
                client = new MobileServiceClient(Constant.AzureUrl, new LoggingHandler());

                mStore = new MobileServiceSQLiteStore(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "ZumoLocal.db"));
                mStore.DefineTable<TodoItem>();
                await client.SyncContext.InitializeAsync(mStore);
                todoTable = client.GetSyncTable<TodoItem>();

                await SynchronizeAsync();

                //await todoTable.InsertAsync(
                //    new TodoItem()
                //    {
                //        Text = "without bdrtzook"
                //    });

                //await SynchronizeAsync();

                var items = await todoTable.ToListAsync();

                base.OnNavigatedTo(parameters);

            }
            catch (Exception e)
            {
                Debugger.Break();
            }
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
