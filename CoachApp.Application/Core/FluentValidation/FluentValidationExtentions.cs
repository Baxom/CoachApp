using FluentValidation.Results;

namespace CoachApp.Application.Core.FluentValidation;
internal class FluentValidationHelpers
{
    internal static ValidationResult CreateDomainFailure(string error) => new ValidationResult(new[] { new ValidationFailure("DomainError", error) });
}
