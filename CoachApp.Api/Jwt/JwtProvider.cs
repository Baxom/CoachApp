using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoachApp.Application.Domain.Users.Context;
using Microsoft.IdentityModel.Tokens;

namespace CoachApp.Api.Jwt;

internal sealed class JwtProvider : IProvideJwt
{
    private readonly JwtConfiguration _jwtOptions;

    public JwtProvider(JwtConfiguration jwtConfiguration)
    {
        _jwtOptions = jwtConfiguration;
    }

    public JsonWebToken Generate(IUserContext userContext)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, userContext.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, userContext.Email),
        };

        var signincredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                                SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_jwtOptions.Issuer,
                                        _jwtOptions.Audience,
                                        claims,
                                        null,
                                        DateTime.UtcNow.AddDays(1),
                                        signincredentials);

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return new JsonWebToken(tokenValue);
    }
}