using AzureZumoApp.Extensions;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Net.Http;

namespace AzureZumoApp.Persistence
{
    class CustomMobileServiceClient : MobileServiceClient
    {
        public CustomMobileServiceClient(string offlineDatabasePath, string mobileAppUri, params HttpMessageHandler[] handlers) : base(mobileAppUri, handlers)
        {
            MobileServiceSQLiteStore mStore = new MobileServiceSQLiteStore(offlineDatabasePath);

            mStore.DefineOfflineSyncTables();

            SyncContext.InitializeAsync(mStore);
        }
    }
}
