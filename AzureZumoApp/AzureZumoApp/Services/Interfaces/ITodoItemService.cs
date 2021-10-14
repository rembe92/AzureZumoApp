using AzureZumoApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureZumoApp.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetDirectory();
    }
}
