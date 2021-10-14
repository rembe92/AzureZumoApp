using Prism.Navigation;
using System;
using System.Diagnostics;
using AzureZumoApp.Services;

namespace AzureZumoApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        Synchronizer _synchronizer;
        ITodoItemService _todoItemService;

        public MainPageViewModel(INavigationService navigationService, ITodoItemService todoItemService, Synchronizer synchronizer)
            : base(navigationService)
        {
            Title = "Main Page";
            _todoItemService = todoItemService;
            _synchronizer = synchronizer;
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                await _synchronizer.SynchronizeAsync();

                var items = await _todoItemService.GetDirectory();

                //await todoTable.InsertAsync(
                //    new TodoItem()
                //    {
                //        Text = "without bdrtzook"
                //    });

                //await SynchronizeAsync();

                base.OnNavigatedTo(parameters);

            }
            catch (Exception e)
            {
                Debugger.Break();
            }
        }


    }

}
