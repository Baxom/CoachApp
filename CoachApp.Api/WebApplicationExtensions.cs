//using CoachApp.Api.Apis;
using CoachApp.Api.Apis;
using CoachApp.Api.Filters;
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
        apiRoot.AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory);

        app.UseHttpsRedirection();

        apiRoot.RegisterUserApis();
        apiRoot.RegisterClientApis();
        apiRoot.RegisterServiceApis();
        apiRoot.RegisterPackApis();

        return app;
    }
}