using CoachApp.Domain.Clients;
using CoachApp.Domain.Clients.Models;
using FluentValidation;
using MediatR;

namespace CoachApp.Application.Domain.Clients.Commands;
public record CreateClient(string Lastname, string Firstname, DateTime BirthDate, ContactDetails ContactDetails, Adress Adress) : IRequest<Client>;

public class CreateClientValidator : AbstractValidator<CreateClient>
{
	public CreateClientValidator()
	{
		RuleFor(b => b.Lastname).NotEmpty();
		RuleFor(b => b.Firstname).NotEmpty();
        RuleFor(b => b.BirthDate).LessThanOrEqualTo(DateTime.Today.AddYears(-18)).WithMessage("You must be at least 18 year old");
    }    
}