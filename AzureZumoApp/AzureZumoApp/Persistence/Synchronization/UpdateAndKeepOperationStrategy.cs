using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;

namespace BreeditApp.Synchronization
{
    class UpdateAndKeepOperationStrategy : IResolvingStrategy
    {
        public Task ResolveAsync(MobileServiceTableOperationError syncError)
        {
            return syncError.UpdateOperationAsync(syncError.Result);
        }
    }
}
