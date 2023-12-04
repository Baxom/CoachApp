using CoachApp.Application.Core.Repositories;
using CoachApp.DDD.Commands;
using MediatR;

namespace CoachApp.Application.Core.Mediatr;
public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand 
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                var result = await next();
                await transaction.CommitAsync(cancellationToken);

                return result;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }

    }

}

