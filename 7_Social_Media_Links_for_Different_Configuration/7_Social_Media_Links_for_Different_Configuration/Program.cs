using SharedFiles;
using ServiceBluePrints;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
builder.Services.Configure<ConfigurationOptions>(builder.Configuration.GetSection("SocialMediaLinks"));
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();
