namespace CoachApp.Application.Domain.Users.Context;

public interface IUserContext
{
    Guid Id { get; }
    string Email { get; init; }
}