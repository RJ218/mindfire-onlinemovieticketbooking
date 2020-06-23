using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;

namespace BookMyShowAppp.Filter
{
    public class CustomAuthentication : AuthorizationFilterAttribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get { return false; }
        }
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string authParameter = string.Empty;
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            string[] tokenanduser = null;
            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFaliureResult("Missing Authorization Header", request);
                return;
            }
            if (authorization == null && authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFaliureResult("Invalid Authorization Schema", request);
                return;
            }

            tokenanduser = authorization.Parameter.Split(separator: ':');
            string token = tokenanduser[0];
            string user = tokenanduser[1];
            if (String.IsNullOrEmpty(token))
            {
                context.ErrorResult = new AuthenticationFaliureResult("Missing Token", request);
                return;
            }
            string validusername = TokenManager.ValidateToken(token);
            if(user!=validusername)
            {
                context.ErrorResult = new AuthenticationFaliureResult("Invalid token", request);
                return;
            }
            context.Principal = TokenManager.GetPrincipal(token);

        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);
            if(result.StatusCode == HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(scheme: "Basic", parameter: "realm=localhost"));
            }
            context.Result = new ResponseMessageResult(result);
        }
    }
    public class AuthenticationFaliureResult :IHttpActionResult
    {
        public string ReasonPhrase;
        public HttpRequestMessage Request { get; set; }
        public AuthenticationFaliureResult(string reasonPhrase,HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }
        public HttpResponseMessage Execute()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            responseMessage.RequestMessage = Request;
            responseMessage.ReasonPhrase = ReasonPhrase;
            return responseMessage;
        }
    }
}