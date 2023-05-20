using CoachApp.CQRS.Aggregates;

namespace CoachApp.Application.Core.Repositories;
public interface IRepository<TAggregate> where TAggregate : class, IAggregate
{
    Task<TAggregate?> Get(Guid id, CancellationToken? cancellationToken = null);
    Task<TAggregate> Add(TAggregate entity);
    Task Update(TAggregate entity);
}
