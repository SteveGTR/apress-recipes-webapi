using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace RequireHttpsRecipe.Attributes
{
    public class ErrorResult : IHttpActionResult
    {
        public ErrorResult(HttpRequestMessage request, HttpStatusCode statusCode, string reasonPhrase = "")
        {
            Request = request;
            Code = statusCode;
            Reason = reasonPhrase;
        }

        public HttpStatusCode Code { get; private set; }

        public string Reason { get; private set; }

        public HttpRequestMessage Request { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(Code)
            {
                RequestMessage = Request,
                ReasonPhrase = Reason
            });
        }
    }
}
