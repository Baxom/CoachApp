using CoachApp.Application.Domain.Users.Context;

namespace CoachApp.Api.Jwt;
internal interface IProvideJwt
{
    JsonWebToken Generate(IUserContext userContext);
}
