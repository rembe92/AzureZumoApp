using AzureZumoApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.IO;
using System.Net.Http;

namespace AzureZumoApp.Persistence
{
    class CustomMobileServiceClient : MobileServiceClient
    {
        public CustomMobileServiceClient(string mobileAppUri, params HttpMessageHandler[] handlers) : base(mobileAppUri, handlers)
        {
            MobileServiceSQLiteStore mStore = new MobileServiceSQLiteStore(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "ZumoLocal.db"));

            mStore.DefineTable<TodoItem>();
            SyncContext.InitializeAsync(mStore);
        }
    }
}
