using CoachApp.CQRS.Results;
using MediatR;

namespace CoachApp.Application.Domain.Users.Commands;
public record CreateUserAccount(string Login, string Password) : IRequest<ValidateWithoutResult>;
