//using CoachApp.Api.Apis;
using CoachApp.Api.Apis;
using CoachApp.EFCore;

namespace CoachApp.Api;

internal static class WebApplicationExtensions
{
    public static WebApplication Bootstrap(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseEFCore();

        RouteGroupBuilder apiRoot = app.MapGroup("");

        app.UseHttpsRedirection();

        apiRoot.RegisterUserApis();
        apiRoot.RegisterClientApis();
        apiRoot.RegisterServiceApis();

        return app;
    }
}