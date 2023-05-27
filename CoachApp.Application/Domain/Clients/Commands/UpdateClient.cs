using CoachApp.CQRS.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Models;
using FluentValidation;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Commands;
public record UpdateClient(Guid Id, string Lastname, string Firstname, DateTime BirthDate, ContactDetails ContactDetails, Adress Adress) : ICommand<ValidateExistingResult<Client>>;

public class UpdateClientValidator : AbstractValidator<UpdateClient>
{
    public UpdateClientValidator()
    {
        RuleFor(b => b.Lastname).NotEmpty();
        RuleFor(b => b.Firstname).NotEmpty();
        RuleFor(b => b.BirthDate).LessThanOrEqualTo(DateTime.Today.AddYears(-18)).WithMessage("You must be at least 18 year old");
    }
}