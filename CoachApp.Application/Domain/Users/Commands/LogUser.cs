using CoachApp.CQRS.Results;
using CoachApp.DDD.Commands;
using CoachApp.DDD.Results;
using CoachApp.Domain.Users;
using MediatR;

namespace CoachApp.Application.Domain.Users.Commands;
public record struct LogUser(string Email, string Password) : ICommand<ValidateResult<User>>;
