using CoachApp.Api.Jwt;
using CoachApp.CQRS.Results;
using CoachApp.DDD.Results;

namespace CoachApp.Api.Services;
public interface IAuthenticateUser
{
    Task<ValidateResult<JsonWebToken>> Authenticate(AuthenticationModel authenticationModel);
}
