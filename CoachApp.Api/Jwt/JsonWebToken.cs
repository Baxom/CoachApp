namespace CoachApp.Api.Jwt;
public record struct JsonWebToken(string Value)
{
    public override string ToString() => Value;
}
