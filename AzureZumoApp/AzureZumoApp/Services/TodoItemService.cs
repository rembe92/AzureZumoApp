using AzureZumoApp.Models;
using AzureZumoApp.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureZumoApp.Services
{
    class TodoItemService : ITodoItemService
    {
        IRepository<TodoItem> todoItemRepository;

        public TodoItemService(IRepository<TodoItem> todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public Task DeleteAsync(TodoItem item)
        {
            return todoItemRepository.RemoveAsync(item);
        }

        public Task<IEnumerable<TodoItem>> GetDirectoryAsync()
        {
            return todoItemRepository.GetDirectory();
        }

        public Task RefreshAsync(TodoItem item)
        {
            return todoItemRepository.RefreshAsync(item);
        }

        public Task UpdateAsync(TodoItem item)
        {
            return todoItemRepository.UpdateAsync(item);
        }
    }
}
