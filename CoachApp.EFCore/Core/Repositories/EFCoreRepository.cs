using CoachApp.Application.Core.Repositories;
using CoachApp.CQRS.Aggregates;
using CoachApp.EFCore.Database;

namespace CoachApp.EFCore.Core.Repositories;
internal class EFCoreRepository<TAggregate> : IRepository<TAggregate> where TAggregate : class, IAggregateRoot
{
    protected readonly CoachAppContext _coachAppContext;

    public EFCoreRepository(CoachAppContext coachAppContext)
    {
        _coachAppContext = coachAppContext;
    }

    public async Task<TAggregate> Add(TAggregate entity)
    {
        _coachAppContext.Add(entity);

        await _coachAppContext.SaveChangesAsync();

        return entity;
    }

    public async Task<TAggregate?> Get(Guid id, CancellationToken? cancellationToken = null)
    {
        cancellationToken ??= CancellationToken.None;
        return await _coachAppContext.FindAsync<TAggregate>(id, cancellationToken);
    }

    public Task Update(TAggregate entity)
    {
        return _coachAppContext.SaveChangesAsync();
    }
}
