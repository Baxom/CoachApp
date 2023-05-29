namespace CoachApp.Application.Domain.Users.Context;

public interface IUserContextProvider
{
    IUserContext UserContext { get; set; }
}

internal class UserContextProvider : IUserContextProvider
{
    private IUserContext? _userContext;

    public IUserContext UserContext 
    { 
        get => _userContext ?? throw new InvalidOperationException("Usercontext not set"); 
        set {
            if (_userContext is not null) throw new InvalidOperationException("Usercontext already set");
            _userContext = value; 
        } 
    }
}