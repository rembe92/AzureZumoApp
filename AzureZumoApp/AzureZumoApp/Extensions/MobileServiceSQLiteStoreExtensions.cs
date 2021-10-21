using AzureZumoApp.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System;
using System.Collections.Generic;
using System.Text;

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
