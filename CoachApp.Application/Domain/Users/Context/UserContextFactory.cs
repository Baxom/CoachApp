using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CoachApp.Application.Domain.Users.Context;
public class UserContextFactory : IUserContextFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextFactory(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IUserContext Get() => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IUserContext>();
}
