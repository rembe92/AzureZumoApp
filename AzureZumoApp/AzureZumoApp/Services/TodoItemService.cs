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

        public Task<IEnumerable<TodoItem>> GetDirectory()
        {
            return todoItemRepository.GetDirectory();
        }
    }
}
