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
       // get => _userContext ?? throw new InvalidOperationException("Usercontext not set"); 
       get => new UserContext(Guid.Parse("71baf505-67d4-4e83-bb41-4658955d3163"), "");

        set {
            if (_userContext is not null) throw new InvalidOperationException("Usercontext already set");
            _userContext = value; 
        } 
    }
}