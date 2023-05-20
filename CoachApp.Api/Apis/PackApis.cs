using CoachApp.Application.Domain.Packs.Commands;
using CoachApp.Application.Domain.Packs.Models.Mappers;
using CoachApp.Application.Domain.Packs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoachApp.Api.Apis;

public static class PackApis
{
    private const string RouteBase = "pack";
    private const string GroupName = "Packs";

    public static void RegisterPackApis(this RouteGroupBuilder routeGroupBuilder)
    {
        var packGroupBuilder = routeGroupBuilder.MapGroup(RouteBase).WithTags(GroupName);

        packGroupBuilder.MapPost("", async ([FromBody] CreatePack createPack, [FromServices] ISender sender) =>
        {
            return Results.Ok((await sender.Send(createPack)).MapToPackModel());
        });

        packGroupBuilder.MapGet("{packId}", async ([FromRoute] Guid packId, [FromServices] ISender sender) =>
        {
            return Results.Ok((await sender.Send(new GetPackById(packId))).MapToPackModel());
        });

        packGroupBuilder.MapGet("", ([FromServices] ISender sender) =>
        {
            return Results.Ok(sender.CreateStream(new GetAllPacks()));
        });
    }
}