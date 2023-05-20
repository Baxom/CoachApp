namespace CoachApp.CQRS.Aggregates;
public abstract class BaseAggregate : IAggregate
{
    public Guid Id { get; private set; }

    protected BaseAggregate(bool initId = false)
    {
        if (initId)
            Id = Guid.NewGuid();
    }
}
