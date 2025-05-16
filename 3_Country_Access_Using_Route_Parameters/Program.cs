var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Dictionary<int, string> country = new Dictionary<int, string>
{
    { 1, "Bangladesh" },
    { 2, "Pakistan" },
    { 3, "Palistan" },
    { 4, "Misar" },
    { 5, "Qatar" }
};
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/countries/{id:range(1, 100)?}", async context =>
    {
        string? id = Convert.ToString(context.Request.RouteValues["id"]);
        if (string.IsNullOrEmpty(id))
        {
            // Print all countries from the dictionary
            await context.Response.WriteAsync("All Countries:\n");
            foreach (var entry in country)
            {
                await context.Response.WriteAsync($"{entry.Key}: {entry.Value}\n");
            }
        }
        else if (int.TryParse(id, out int countryId) && country.ContainsKey(countryId))
        {
            await context.Response.WriteAsync($"{countryId}: {country[countryId]}\n");
        }
        else
        {
            context.Response.StatusCode = 404; // Not Found
            await context.Response.WriteAsync("[Country not found.]\n");
        }
    });

});

app.Run(async context =>
{
    context.Response.StatusCode = 400; // Bad Request
    await context.Response.WriteAsync("The CountryID should be between 1 and 100!");
});

app.Run();
