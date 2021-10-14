using AzureZumoApp.Models;
using AzureZumoApp.Persistence;
using AzureZumoApp.Services;
using AzureZumoApp.ViewModels;
using AzureZumoApp.Views;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace AzureZumoApp
{
    //https://entityframeworkcore.com/knowledge-base/43797126/can-azure-mobile-services-offline-sync-be-used-with-entity-framework-core-
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage").OnNavigationError(HandleError);
        }

        private void HandleError(Exception ex)
        {
#if DEBUG
            Debugger.Break();
#endif
            Debug.Fail(ex.Message);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.Register(typeof(IRepository<>), typeof(Repository<>));
            containerRegistry.Register<ITodoItemService, TodoItemService>();
            containerRegistry.Register<Synchronizer>();

            containerRegistry.Register<IMobileServiceSyncTable<TodoItem>>(m => m.Resolve<IMobileServiceClient>().GetSyncTable<TodoItem>());

            containerRegistry.RegisterSingleton<IMobileServiceClient>(m => new CustomMobileServiceClient(Constant.AzureUrl, new LoggingHandler()));

            //containerRegistry.RegisterSingleton<MobileServiceSQLiteStore>(m => new MobileServiceSQLiteStore(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "ZumoLocal.db")));
        }
    }
}
