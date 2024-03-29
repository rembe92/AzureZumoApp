using AzureZumoApp.Configurations;
using AzureZumoApp.Logging;
using AzureZumoApp.Persistence;
using AzureZumoApp.Services;
using AzureZumoApp.ViewModels;
using AzureZumoApp.Views;
using DryIoc;
using Microsoft.WindowsAzure.MobileServices;
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
            containerRegistry.Register(typeof(ISynchronizer<>), typeof(Synchronizer<>));

            //containerRegistry.Register<IMobileServiceSyncTable<TodoItem>>(m => m.Resolve<IMobileServiceClient>().GetSyncTable<TodoItem>());

            containerRegistry.Register(typeof(IMobileServiceSyncTable<>), typeof(MobileServiceSyncTableWrapper<>));
            containerRegistry.Register(typeof(IMobileServiceTable<>), typeof(MobileServiceTableWrapper<>));

            containerRegistry.RegisterSingleton<IMobileServiceClient>(
                m => new CustomMobileServiceClient(
                    Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, AppSettingsManager.Settings["OfflineDatabaseName"]),
                    AppSettingsManager.Settings["MobileBackendURL"],
                    //new UriPathHandler(),
                    new LoggingHandler())
                ); ;


            //containerRegistry.RegisterSingleton<MobileServiceSQLiteStore>(m => new MobileServiceSQLiteStore(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "ZumoLocal.db")));
        }
    }
}
