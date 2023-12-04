using CoachApp.CQRS.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Models;
using FluentValidation;

namespace CoachApp.Application.Domain.Clients.Commands;
public record struct CreateClient(string Lastname, string Firstname, DateTime BirthDate, ContactDetails? ContactDetails, Address? Address) : ICommand<ValidateResult<Client>>;

public class CreateClientValidator : AbstractValidator<CreateClient>
{
	public CreateClientValidator()
	{
		RuleFor(b => b.Lastname).NotEmpty();
		RuleFor(b => b.Firstname).NotEmpty();
        RuleFor(b => b.BirthDate).LessThanOrEqualTo(DateTime.Today.AddYears(-18)).WithMessage("You must be at least 18 year old");
    }    
}