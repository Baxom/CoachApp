﻿using CoachApp.Application.Domain.Services.Queries;
using CoachApp.CQRS.Results;
using CoachApp.Domain._Common;
using CoachApp.Domain.Clients;
using FluentValidation;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Commands;
public record AddPackToClient(Guid ClientId, Guid serviceId, DateTime? paymentDate, Price price, int numberOfSessions) : IRequest<ValidateExistingResult<Client>>;

public class AddPackToClientValidator : AbstractValidator<AddPackToClient>
{
    public AddPackToClientValidator(ISender sender)
    {
        RuleFor(b => b.serviceId)
            .MustAsync((id, ct) => sender.Send(new GetServiceExistsById(id)))
            .WithMessage("Service not found");
    }
}