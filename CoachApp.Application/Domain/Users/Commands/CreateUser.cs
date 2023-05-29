using CoachApp.CQRS.Commands;
using CoachApp.CQRS.Results;
using FluentValidation;
using MediatR;

namespace CoachApp.Application.Domain.Users.Commands;
public record struct CreateUser(string Email, string Password, string ConfirmPassword) : ICommand<ValidateWithoutResult>;

public class CreateUserValidator : AbstractValidator<CreateUser>
{
    public CreateUserValidator()
    {
        RuleFor(b => b.Email).NotNull()
                                .NotEmpty()
                                .WithMessage("Email is required")
                                .EmailAddress()
                                .WithMessage("Invalid email format");

        RuleFor(b => b.Password)
            .Equal(b => b.ConfirmPassword).WithMessage("Password and ConfirmPassword should be the same")
            .NotNull()
            .NotEmpty().WithMessage("Required")
            .MinimumLength(10).WithMessage("Length")
            .Matches("[A-Z]").WithMessage("Uppercase msg")
            .Matches("[a-z]").WithMessage("Lowercase msg")
            .Matches("[0-9]").WithMessage("Digit msg")
            .Matches("[^a-zA-Z0-9]").WithMessage("Sepcial char msg");
    }

}

