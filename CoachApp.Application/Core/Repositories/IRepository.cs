using CoachApp.DDD.Aggregates;

namespace CoachApp.Application.Core.Repositories;
public interface IRepository<TAggregate> where TAggregate : class, IAggregateRoot
{
    Task<TAggregate?> Get(Guid id, CancellationToken? cancellationToken = null);
    Task<TAggregate> Add(TAggregate entity);
    Task Update(TAggregate entity);
}
