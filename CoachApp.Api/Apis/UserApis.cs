using System.Reflection;
using CoachApp.Api.Extentions;
using CoachApp.Api.Services;
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

        userGroupBuilder.MapPost($"", async ([FromBody] CreateUser createUser, [FromServices] ISender sender) => (await sender.Send(createUser)).ToOkResult())
                        .AllowAnonymous();

        userGroupBuilder.MapPost($"login", async ([FromBody] AuthenticationModel authenticationModel, [FromServices] IAuthenticateUser userAuthenticator) 
                => (await userAuthenticator.Authenticate(authenticationModel)).ToOkResult())
            .AllowAnonymous();

    }
}