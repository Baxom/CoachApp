using CoachApp.Api.Jwt;
using Microsoft.Extensions.Options;

namespace CoachApp.Api.OptionsSetup;

public class JwtConfigurationSetup : IConfigureOptions<JwtConfiguration>
{
    private const string JwtSectionName = "Jwt";
    private readonly IConfiguration _configuration;

    //public void Configure(string? name, JwtConfiguration options)
    //{
    //    throw new NotImplementedException();
    //}

    public JwtConfigurationSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtConfiguration options)
    {
        _configuration.GetSection(JwtSectionName).Bind(options);
    }
}
