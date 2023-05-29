using FluentValidation;
using MediatR;

namespace CoachApp.CQRS.Mediatr;
public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IBuildValidationResult<TRequest, TResponse> _buildValidationResult;
  
    public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IBuildValidationResult<TRequest, TResponse> buildValidationResult)
    {
        _validators = validators;
        _buildValidationResult = buildValidationResult;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return _buildValidationResult.ValidateAndExecuteNext(request, next, cancellationToken, _validators);
    }
}

