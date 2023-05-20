using CoachApp.CQRS.Aggregates;

namespace CoachApp.Domain._Common;
public abstract class BaseAggregatePerTenant : BaseAggregate
{
    public Guid OwnerUserId { get; private set; }

    protected BaseAggregatePerTenant(bool initId = false) : base(initId)
    {
    }
}
