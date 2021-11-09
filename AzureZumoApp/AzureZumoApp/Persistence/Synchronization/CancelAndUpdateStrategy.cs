using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;

namespace BreeditApp.Synchronization
{
    class CancelAndUpdateStrategy : IResolvingStrategy
    {
        public Task ResolveAsync(MobileServiceTableOperationError syncError)
        {
            return syncError.CancelAndUpdateItemAsync(syncError.Result);
        }
    }
}
