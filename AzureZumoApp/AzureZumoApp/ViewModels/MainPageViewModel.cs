using Prism.Navigation;
using System;
using System.Linq;
using System.Diagnostics;
using AzureZumoApp.Services;
using AzureZumoApp.Models;
using BreeditApp.Synchronization;

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

                var items = await _todoItemService.GetDirectoryAsync();

                var item = items.ToList()[0];

                item.Version = new byte[] { 1,1,1,1,1};

                item.Text = "new item text from client";

                await _todoItemService.UpdateAsync(item);

                var qq = _todoItemSynchronizer.GetPendingOperations();

                await ConflictResolver.ResolveAsync(await _todoItemSynchronizer.PushAsync(), new CancelAndUpdateStrategy());

                await _todoItemService.RefreshAsync(item);

                var q = _todoItemSynchronizer.GetPendingOperations();    

                base.OnNavigatedTo(parameters);

            }
            catch (Exception e)
            {
                Debugger.Break();
            }
        }


    }

}
