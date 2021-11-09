using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;

namespace BreeditApp.Synchronization
{
    class CancelAndDiscardStrategy : IResolvingStrategy
    {
        public Task ResolveAsync(MobileServiceTableOperationError syncError)
        {
            return syncError.CancelAndDiscardItemAsync();
        }
    }
}
