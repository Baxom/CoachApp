using CoachApp.Api.Jwt;
using CoachApp.Application.Domain.Users.Commands;
using CoachApp.Application.Domain.Users.Context;
using CoachApp.CQRS.Results;
using CoachApp.DDD.Results;
using CoachApp.Domain.Users;
using MediatR;

namespace CoachApp.Api.Services;
internal class UserAuthenticator : IAuthenticateUser
{
    private readonly ISender _sender;
    private readonly IUserContextProvider _userContextProvider;
    private readonly IProvideJwt _provideJwtToken;

    public UserAuthenticator(ISender sender, IUserContextProvider userContextProvider, IProvideJwt provideJwtToken)
    {
        _sender = sender;
        _userContextProvider = userContextProvider;
        _provideJwtToken = provideJwtToken;
    }

    public async Task<ValidateResult<JsonWebToken>> Authenticate(AuthenticationModel authenticationModel)
    {
        var result = await _sender.Send(new LogUser(authenticationModel.Email, authenticationModel.Password));

        return result.Match<ValidateResult<JsonWebToken>>(user => CreateUserContext(user),
                            failure => failure);
    }

    private JsonWebToken CreateUserContext(User user)
    {
        _userContextProvider.UserContext = new UserContext(user.Id, user.Email);

        return _provideJwtToken.Generate(_userContextProvider.UserContext);
    }
}
