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
    private int _holders;

    public EFCoreContextTransaction(IDbContextTransaction dbContextTransaction, DbContext dbContext)
    {
        _dbContextTransaction = dbContextTransaction;
        _dbContext = dbContext;
        _holders = 0;
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_rollbacked) return;

        Interlocked.Decrement(ref _holders);

        if(Interlocked.CompareExchange(ref _holders, 0, 0) == 0)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
            await _dbContextTransaction.CommitAsync(cancellationToken);
        }
    }

    public void Dispose()
    {
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
        Interlocked.Increment(ref _holders);
    }
}
