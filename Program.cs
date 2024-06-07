using HomeMinimalApi.Common.Auth.Extensions;
using HomeMinimalApi.Common.Middlewares;
using HomeMinimalApi.Data.Extensions;
using HomeMinimalApi.ListingsModule.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRespositories(builder.Configuration);
builder.Services.AddAuthentication().AddBearerToken();
builder.Services.AddListingsAuthorization();
builder.Services.AddApiVersioning();

var app = builder.Build();
app.UseExceptionHandler(appBuilder => appBuilder.ConfigureExceptionHandler());
app.MapListings();

app.Run();
