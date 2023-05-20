using CoachApp.Application.Domain.Clients.Commands;
using CoachApp.Application.Domain.Clients.Models.Mappers;
using CoachApp.Application.Domain.Clients.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoachApp.Api.Apis;

public static class ClientApis
{
    private const string RouteBase = "client";
    private const string GroupName = "Clients";

    public static void RegisterClientApis(this RouteGroupBuilder routeGroupBuilder)
    {
        var clientGroupBuilder = routeGroupBuilder.MapGroup(RouteBase).WithTags(GroupName);

        clientGroupBuilder.MapPost("", async ([FromBody] CreateClient createClient, [FromServices] ISender sender) =>
        {
            return Results.Ok((await sender.Send(createClient)).MapToClientModel());
        });

        clientGroupBuilder.MapGet("{clientId}", async ([FromRoute] Guid clientId, [FromServices] ISender sender) =>
        {
            return Results.Ok(await sender.Send(new GetClientById(clientId)));
        });

        clientGroupBuilder.MapGet("", ([FromServices] ISender sender) =>
        {
            return Results.Ok(sender.CreateStream(new GetClientIdentities()));
        });

        clientGroupBuilder.MapPut("", async ([FromBody] UpdateClient updateClient, [FromServices] ISender sender) =>
        {
            return Results.Ok((await sender.Send(updateClient)).MapToClientModel());
        });
    }
}