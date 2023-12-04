using CoachApp.Application.Domain.Services.Queries;
using CoachApp.CQRS.Results;
using CoachApp.DDD.Commands;
using CoachApp.DDD.Results;
using CoachApp.Domain._Common;
using CoachApp.Domain.Clients;
using FluentValidation;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Commands;
public record struct AddServiceToClient(Guid ServiceId, DateTime? PaymentDate, Price Price, int NumberOfSessions) : ICommand<ValidateExistingResult<Client>>;

public class AddServiceToClientValidator : AbstractValidator<AddServiceToClient>
{
    public AddServiceToClientValidator(ISender sender)
    {
        RuleFor(b => b.ServiceId)
            .MustAsync((id, ct) => sender.Send(new GetServiceExistsById(id)))
            .WithMessage("Service not found");
    }
}