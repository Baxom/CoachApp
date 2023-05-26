using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CoachApp.CQRS.Mediatr;
public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly Type _validationResultType = typeof(ValidationResult);
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    Dictionary<Type, Func<ValidationResult, TResponse>> _responsefactories = new Dictionary<Type, Func<ValidationResult, TResponse>>();

    public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var responseType = typeof(TResponse);
 
        if(responseType.BaseType?.FullName?.StartsWith("OneOf.OneOfBase") ?? false
            && responseType.BaseType.GenericTypeArguments.Contains(_validationResultType) )
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.Where(f => !f.IsValid).SelectMany(v => v.Errors).ToList();

                if (failures.Count != 0)
                {
                    var factory = GetTResponseFactory();
                    return factory(new ValidationResult(failures));
                }
            }
        }

        return await next();

    }

    private Func<ValidationResult, TResponse> GetTResponseFactory()
    {
        var responseType = typeof(TResponse);

        if (_responsefactories.TryGetValue(responseType, out var factory)) return factory;

        var implicitOperatorInfo = responseType.GetMethod("op_Implicit", new Type[] {_validationResultType})!;

        factory = (validationResult => (TResponse)implicitOperatorInfo.Invoke(null, new object[] { validationResult })!);

        _responsefactories.Add(responseType, factory);

        return factory;
    }
}

