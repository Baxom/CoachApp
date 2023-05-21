namespace CoachApp.CQRS.Aggregates;
public abstract class AggregateRoot : Entity, IAggregateRoot
{
    protected AggregateRoot(bool initId = false) : base(initId)
    {
    }
}
