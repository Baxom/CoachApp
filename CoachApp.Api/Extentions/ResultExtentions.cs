using CoachApp.CQRS.Results;

namespace CoachApp.Api.Extentions;

public static class ResultExtentions
{
    public static IResult ToOkResult(this ValidateWithoutResult that) => that.Match(validationErrors => validationErrors.IsValid ? Results.Ok() : Results.BadRequest(validationErrors.Errors));

    public static IResult ToOkResult<T>(this ExistingResult<T> that, Func<T, object>? action = null) => that.Match(ok => action == null ? Results.Ok(ok) : Results.Ok(action!(ok)),
                    _ => Results.NotFound());

    public static IResult ToOkResult<T>(this ValidateResult<T> that, Func<T, object>? action = null) => that.Match(ok => action == null ? Results.Ok(ok) : Results.Ok(action!(ok)),
                    validationErrors => Results.BadRequest(validationErrors.Errors));

    public static IResult ToOkResult<T>(this ValidateExistingResult<T> that, Func<T, object>? action = null) => that.Match(ok => action == null ? Results.Ok(ok) : Results.Ok(action!(ok)),
                    _ => Results.NotFound(),
                    validationErrors => Results.BadRequest(validationErrors.Errors));
}
