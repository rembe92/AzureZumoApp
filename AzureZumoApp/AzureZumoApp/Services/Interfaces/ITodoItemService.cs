using AzureZumoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureZumoApp.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetDirectoryAsync();

        Task DeleteAsync(TodoItem item);

        Task UpdateAsync(TodoItem item);

        Task RefreshAsync(TodoItem item);
    }
}
