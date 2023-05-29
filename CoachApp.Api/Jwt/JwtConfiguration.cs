﻿namespace CoachApp.Api.Jwt;
public class JwtConfiguration
{
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required string SecretKey { get; set; }
}
