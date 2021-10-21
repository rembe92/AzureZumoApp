using Prism.Navigation;
using System;
using System.Diagnostics;
using AzureZumoApp.Services;
using AzureZumoApp.Models;

namespace AzureZumoApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        ISynchronizer<TodoItem> _todoItemSynchronizer;
        ITodoItemService _todoItemService;

        public MainPageViewModel(INavigationService navigationService, ITodoItemService todoItemService, ISynchronizer<TodoItem> todoItemSynchronizer)
            : base(navigationService)
        {
            Title = "Main Page";
            _todoItemService = todoItemService;
            _todoItemSynchronizer = todoItemSynchronizer;
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                await _todoItemSynchronizer.SynchronizeAbsolutAsync();

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
