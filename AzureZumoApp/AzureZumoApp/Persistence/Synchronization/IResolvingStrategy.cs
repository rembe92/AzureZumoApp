using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;

namespace BreeditApp.Synchronization
{
    interface IResolvingStrategy
    {
        Task ResolveAsync(MobileServiceTableOperationError syncError);
    }
}
