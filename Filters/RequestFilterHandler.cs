using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace MessagehandlerWithWebAPI.Filters
{
    public class RequestFilterHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!ValidateKey(request))
            {
                var res = request.CreateResponse(System.Net.HttpStatusCode.Forbidden,
                    new
                    {
                        error = true,
                        message = "Access Denied, Invalid request",
                    });

                var tsk = new TaskCompletionSource<HttpResponseMessage>();
                tsk.SetResult(res);
                return tsk.Task;
            }
            return base.SendAsync(request, cancellationToken);
        }
        private bool ValidateKey(HttpRequestMessage request)
        {
            if (!request.Headers.Contains("X-AUTH-KEY")) return false;
            return request.Headers.GetValues("X-AUTH-KEY").FirstOrDefault()=="QHU7V2K0=YWQ";
        }
    }
}