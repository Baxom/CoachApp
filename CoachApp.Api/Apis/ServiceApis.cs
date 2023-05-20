﻿using CoachApp.Application.Domain.Services.Commands;
using CoachApp.Application.Domain.Services.Models.Mappers;
using CoachApp.Application.Domain.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoachApp.Api.Apis;

public static class ServiceApis
{
    private const string RouteBase = "service";
    private const string GroupName = "Services";

    public static void RegisterServiceApis(this RouteGroupBuilder routeGroupBuilder)
    {
        var serviceGroupBuilder = routeGroupBuilder.MapGroup(RouteBase).WithTags(GroupName);

        serviceGroupBuilder.MapPost("", async ([FromBody] CreateService createService, [FromServices] ISender sender) =>
        {
            return Results.Ok((await sender.Send(createService)).MapToServiceModel());
        });

        serviceGroupBuilder.MapGet("{serviceId}", async ([FromRoute] Guid serviceId, [FromServices] ISender sender) =>
        {
            return Results.Ok(await sender.Send(new GetServiceById(serviceId)));
        });

        serviceGroupBuilder.MapGet("", ([FromServices] ISender sender) =>
        {
            return Results.Ok(sender.CreateStream(new GetAllServices()));
        });

        serviceGroupBuilder.MapPut("", async ([FromBody] UpdateService updateService, [FromServices] ISender sender) =>
        {
            return Results.Ok((await sender.Send(updateService)).MapToServiceModel());
        });
    }
}