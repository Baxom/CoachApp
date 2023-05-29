namespace CoachApp.Application.Domain.Users.Context;
public class UserContext : IUserContext
{
    public UserContext(Guid id, string email)
    {
        Id = id;
        Email = email;
    }

    public Guid Id { get; init; }
    public string Email { get; init; }
}
