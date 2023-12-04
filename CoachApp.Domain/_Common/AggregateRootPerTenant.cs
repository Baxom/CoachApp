using CoachApp.DDD.Aggregates;

namespace CoachApp.Domain._Common;
public abstract class AggregateRootPerTenant : AggregateRoot
{
    public Guid OwnerUserId { get; private set; }

    protected AggregateRootPerTenant(bool initId = false) : base(initId)
    {
    }
}
