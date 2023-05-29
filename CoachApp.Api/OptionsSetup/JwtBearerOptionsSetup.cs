using System.Text;
using CoachApp.Api.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CoachApp.Api.OptionsSetup;

public class JwtBearerOptionsSetup : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtConfiguration _jwtConfiguration;

    public JwtBearerOptionsSetup(JwtConfiguration jwtConfiguration)
    {
        _jwtConfiguration = jwtConfiguration;
    }

    public void Configure(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtConfiguration.Issuer,
            ValidAudience = _jwtConfiguration.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.SecretKey)),
        };

    }

    public void Configure(string? name, JwtBearerOptions options)
    {
        Configure(options);
    }
}
