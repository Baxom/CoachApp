using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CoachApp.CQRS.Mediatr;

public interface IBuildValidationResult<TRequest, TResponse>
{
    Task<TResponse> ValidateAndExecuteNext(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken, IEnumerable<IValidator<TRequest>> validators);
}

public class ValidationResultBuilder<TRequest, TResponse> : IBuildValidationResult<TRequest, TResponse>
{
    private const string OneOfBaseType = "OneOf.OneOfBase";
    private readonly Type _validationResultType = typeof(ValidationResult);
    private readonly bool _shouldValidate;
    private readonly Func<ValidationResult, TResponse> _factory = _ => throw new NotImplementedException();

    public ValidationResultBuilder()
	{
        var responseType = typeof(TResponse);

        _shouldValidate = responseType.BaseType?.FullName?.StartsWith(OneOfBaseType) ?? false
                            && responseType.BaseType.GenericTypeArguments.Contains(_validationResultType);

        if(_shouldValidate)
        {
            var implicitOperatorInfo = responseType.GetMethod("op_Implicit", new Type[] { _validationResultType })!;

            _factory = (validationResult => (TResponse)implicitOperatorInfo.Invoke(null, new object[] { validationResult })!);
        }
    }

    public async Task<TResponse> ValidateAndExecuteNext(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken, IEnumerable<IValidator<TRequest>> validators)
    {
        var responseType = typeof(TResponse);

        if (_shouldValidate)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.Where(f => !f.IsValid).SelectMany(v => v.Errors).ToList();

                if (failures.Count != 0)
                {;
                    return _factory(new ValidationResult(failures));
                }
            }
        }

        return await next();
    }
}