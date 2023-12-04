using CoachApp.CQRS.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Models;
using FluentValidation;

namespace CoachApp.Application.Domain.Clients.Commands;
public record struct UpdateClient(Guid Id, string Lastname, string Firstname, DateTime BirthDate, ContactDetails ContactDetails, Address Address) : ICommand<ValidateExistingResult<Client>>;

public class UpdateClientValidator : AbstractValidator<UpdateClient>
{
    public UpdateClientValidator()
    {
        RuleFor(b => b.Lastname).NotEmpty();
        RuleFor(b => b.Firstname).NotEmpty();
    }
}