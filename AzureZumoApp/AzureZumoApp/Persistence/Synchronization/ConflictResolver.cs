using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreeditApp.Synchronization
{
    class ConflictResolver
    {
        public static IResolvingStrategy ResolvingStrategy { get; set; } = new CancelAndUpdateStrategy();

        public static Task ResolveAsync(IEnumerable<MobileServiceTableOperationError> syncErrors, IResolvingStrategy resolvingStrategy = null)
        {
            if (resolvingStrategy is null)
                resolvingStrategy = ResolvingStrategy;

            ICollection<Task> tasks = new HashSet<Task>();

            foreach (var syncError in syncErrors)
            {
                tasks.Add(resolvingStrategy.ResolveAsync(syncError));
            }

            return Task.WhenAll(tasks);
        }
    }
}
