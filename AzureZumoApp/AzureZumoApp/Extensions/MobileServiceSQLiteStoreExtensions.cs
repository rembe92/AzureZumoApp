using AzureZumoApp.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace AzureZumoApp.Extensions
{
    static class MobileServiceSQLiteStoreExtensions
    {
        public static void DefineOfflineSyncTables(this MobileServiceSQLiteStore store)
        {
            store.DefineTable<TodoItem>();
        }
    }
}
