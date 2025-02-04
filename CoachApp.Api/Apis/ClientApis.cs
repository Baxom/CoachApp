﻿using CoachApp.Api.Extentions;
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
            return (await sender.Send(createClient)).ToOkResult(client => client.MapToClientModel());
        });

        clientGroupBuilder.MapGet("{clientId}", async ([FromRoute] Guid clientId, [FromServices] ISender sender) =>
        {
            return (await sender.Send(new GetClientById(clientId))).ToOkResult(client => client.MapToClientModel());
        });

        clientGroupBuilder.MapGet("", ([FromServices] ISender sender) =>
        {
            return Results.Ok(sender.CreateStream(new GetClientIdentities()));
        });

        clientGroupBuilder.MapPut("", async ([FromBody] UpdateClient updateClient, [FromServices] ISender sender) =>
        {
            return (await sender.Send(updateClient)).ToOkResult(client => client.MapToClientModel());
        });

        clientGroupBuilder.MapPost("add-pack", async ([FromBody] AddPackToClient addPackToClient, [FromServices] ISender sender) =>
        {
            return (await sender.Send(addPackToClient)).ToOkResult(client => client.MapToClientModel());
        });
    }
}