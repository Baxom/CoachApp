using CoachApp.Application.Core.Repositories;
using CoachApp.DDD.Aggregates;
using CoachApp.EFCore.Database;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.EFCore.Core.UnitOfWork;
internal class EFCoreRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class, IAggregateRoot
{
    protected readonly DbSet<TAggregate> _set;


    public EFCoreRepository(CoachAppContext coachAppContext)
    {
        _set = coachAppContext.Set<TAggregate>();
    }

    public Task<TAggregate> Add(TAggregate entity)
    {
        _set.Add(entity);
        return Task.FromResult(entity);
    }

    public async Task<TAggregate?> Get(Guid id, CancellationToken? cancellationToken = null)
    {
        cancellationToken ??= CancellationToken.None;
        return await _set.FindAsync(id, cancellationToken);
    }

    public Task Update(TAggregate entity)
    {
        if(_set.Entry(entity).State == Microsoft.EntityFrameworkCore.EntityState.Detached) _set.Attach(entity);
        return Task.CompletedTask;
    }
}
