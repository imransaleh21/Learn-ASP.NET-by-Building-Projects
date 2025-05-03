/*
 * Run this program using postman.
 * this is a simple login middleware example, using extension method.
*/

using Login_Using_Middleware;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    (HttpContext context) => context.Request.Method.Equals("POST"),
    app => app.UseMiddleware()
);

app.Run(async (HttpContext context) => // run is also known as terminal middleware
{
   context.Response.StatusCode = 200;
});
app.Run();
