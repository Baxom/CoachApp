using CoachApp.Application.Core.Repositories;
using CoachApp.CQRS.Aggregates;
using CoachApp.EFCore.Database;

namespace CoachApp.EFCore.Core.UnitOfWork;
internal class EFCoreRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class, IAggregateRoot
{
    protected readonly CoachAppContext _coachAppContext;

    public EFCoreRepository(CoachAppContext coachAppContext)
    {
        _coachAppContext = coachAppContext;
    }

    public Task<TAggregate> Add(TAggregate entity)
    {
        _coachAppContext.Add(entity);
        return Task.FromResult(entity);
    }

    public async Task<TAggregate?> Get(Guid id, CancellationToken? cancellationToken = null)
    {
        cancellationToken ??= CancellationToken.None;
        return await _coachAppContext.FindAsync<TAggregate>(id, cancellationToken);
    }

    public Task Update(TAggregate entity)
    {
        if(_coachAppContext.Entry(entity).State == Microsoft.EntityFrameworkCore.EntityState.Detached) _coachAppContext.Attach(entity);
        return Task.CompletedTask;
    }
}
