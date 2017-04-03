using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Apress.Recipes.WebApi
{
    public class RequireHttps2Attribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get { return true; }
        }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            if (context.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                context.ErrorResult = new ErrorResult(context.Request, HttpStatusCode.Forbidden, "HTTPS Required");
            }

            return Task.FromResult(true);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
