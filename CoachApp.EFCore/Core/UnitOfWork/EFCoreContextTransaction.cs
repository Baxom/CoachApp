using System.Threading;
using CoachApp.Application.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoachApp.EFCore.Core.UnitOfWork;
internal class EFCoreContextTransaction : IUnitOfWorkTransaction
{
    private bool _rollbacked = false;
    private readonly IDbContextTransaction _dbContextTransaction;
    private readonly DbContext _dbContext;
    private int _commitHolders;
    private int _disposeHolders;

    public EFCoreContextTransaction(IDbContextTransaction dbContextTransaction, DbContext dbContext)
    {
        _dbContextTransaction = dbContextTransaction;
        _dbContext = dbContext;
        _commitHolders = 0;
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_rollbacked) return;

        Interlocked.Decrement(ref _commitHolders);

        if(Interlocked.CompareExchange(ref _commitHolders, 0, 0) == 0)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
            await _dbContextTransaction.CommitAsync(cancellationToken);
        }
    }

    public void Dispose()
    {
        Interlocked.Decrement(ref _disposeHolders);

        if (Interlocked.CompareExchange(ref _disposeHolders, 0, 0) == 0)
            _dbContextTransaction.Dispose();

    }

    public Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        if(_rollbacked) return Task.CompletedTask;
        _rollbacked = true;
        return _dbContextTransaction.RollbackAsync(cancellationToken);
    }

    internal void IncrementHolder()
    {
        Interlocked.Increment(ref _commitHolders);
        Interlocked.Increment(ref _disposeHolders);
    }
}
