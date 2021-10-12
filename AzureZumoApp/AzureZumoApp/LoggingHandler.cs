using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureZumoApp
{
    class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler() : base() { }
        public LoggingHandler(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
        {
            Debug.WriteLine($"[HTTP] >>> {request}");
            if (request.Content != null)
            {
                Debug.WriteLine($"[HTTP] >>> {await request.Content.ReadAsStringAsync().ConfigureAwait(false)}");
            }

            HttpResponseMessage response = await base.SendAsync(request, token).ConfigureAwait(false);

            Debug.WriteLine($"[HTTP] <<< {response}");
            if (response.Content != null)
            {
                Debug.WriteLine($"[HTTP] <<< {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");
            }

            return response;
        }
    }
}
