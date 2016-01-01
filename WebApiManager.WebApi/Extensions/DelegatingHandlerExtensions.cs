using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApiManager.WebApi.Extensions
{
    public static class DelegatingHandlerExtensions
    {
        public static Task<HttpResponseMessage> InvokeAsync(this DelegatingHandler handler,
            HttpRequestMessage request,
            CancellationToken cancellationToken =
                default(CancellationToken))
        {
            handler.InnerHandler = new DummyHandler();
            var invoker = new HttpMessageInvoker(handler);
            return invoker.SendAsync(request, cancellationToken);
        }

        private class DummyHandler : HttpMessageHandler
        {
            //俄罗斯塔中最后执行的SendAsync
            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
                var response =
                    new HttpResponseMessage(HttpStatusCode.OK);
                return Task.FromResult(response);
            }
        }
    }
}