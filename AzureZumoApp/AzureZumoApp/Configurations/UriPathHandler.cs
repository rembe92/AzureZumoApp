using AzureZumoApp.Extensions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AzureZumoApp.Configurations
{
    class UriPathHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.RequestUri = request.RequestUri.ToPluralCollectionNameUri();
            return base.SendAsync(request, cancellationToken);
        }
    }
}
