using ServicesBluePrints;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ICityWeathersService, CityWeathersService>();
var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();
