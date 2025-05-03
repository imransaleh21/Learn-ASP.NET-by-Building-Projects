using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Login_Using_Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Login_Middleware
    {
        private readonly RequestDelegate _next;

        public Login_Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var streamReader = new StreamReader(context.Request.Body);
            var requestBody = await streamReader.ReadToEndAsync();
            Dictionary<string, StringValues> queryString = QueryHelpers.ParseQuery(requestBody);

            bool flag = true;
            List<string> errors = new List<string>();
            if (!queryString.TryGetValue("userName", out StringValues userName))
            {
                flag = false;
                errors.Add("userName is required");
            }
            if (!queryString.TryGetValue("password", out StringValues password))
            {
                flag = false;
                errors.Add("password is required");
            }

            if (!flag)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(string.Join(", ", errors));
            }

            else
            {
                if (queryString["userName"] == "imran@gmail.com" && queryString["password"] == "owner")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Login Successful");
                }
                else if (queryString["userName"] != "imran@gmail.com" || queryString["password"] != "owner")
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Login Failed");

                }
            }
            await _next(context);
        }
    }

        // Extension method used to add the middleware to the HTTP request pipeline.
        // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Login_Middleware>();
        }
    }
}
