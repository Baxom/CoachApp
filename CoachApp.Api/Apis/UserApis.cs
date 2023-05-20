using CoachApp.Application.Domain.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoachApp.Api.Apis;

public static class UserApis
{
    private const string RouteBase = "user";
    private const string GroupName = "Users";

    public static void RegisterUserApis(this RouteGroupBuilder routeGroupBuilder)
    {
        var userGroupBuilder = routeGroupBuilder.MapGroup(RouteBase).WithTags(GroupName);

        userGroupBuilder.MapPost($"", async ([FromBody] CreateUserAccount createUserAccount, [FromServices] ISender sender, [FromServices] ILogger<Program> logger) =>
        {
            await sender.Send(createUserAccount);
            return Results.Ok();
        });

    }
}