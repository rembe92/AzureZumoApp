using AzureZumoApp.ViewModels;
using AzureZumoApp.Views;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Prism;
using Prism.Ioc;
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

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            //containerRegistry.RegisterSingleton<MobileServiceClient>(m => new MobileServiceClient(Constant.AzureUrl, new LoggingHandler()));

            //containerRegistry.RegisterSingleton<MobileServiceSQLiteStore>(m => new MobileServiceSQLiteStore(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "ZumoLocal.db")));
        }
    }
}
