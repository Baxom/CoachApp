namespace CoachApp.Application.Domain.Users.Context;

public interface IUserContextFactory
{
    IUserContext Get();
}