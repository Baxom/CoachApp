using CoachApp.Api;
using CoachApp.Application;
using CoachApp.CQRS;
using CoachApp.EFCore;

try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    builder.Configuration.AddJsonFile("appsettings.json");
    

    builder.Services.AddSwagger()
                    .AddJwtAuthentication()
                    .AddApplication()
                    .AddValidation()
                    .AddUserContext()
                    .AddHttpContextAccessor()
                    .AddEFCore(builder.Configuration);

    IHostBuilderExtensions.ConfigureHostBuilder(builder.Host);

    var app = builder.Build();

    app.Bootstrap();

    await app.RunAsync();
    await app.WaitForShutdownAsync();
}
catch (Exception)
{

    throw;
}
