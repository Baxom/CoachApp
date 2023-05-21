namespace CoachApp.CQRS.Aggregates;
public abstract class Entity : IEntity
{
    public Guid Id { get; private set; }

    protected Entity(bool initId = false)
    {
        if (initId)
            Id = Guid.NewGuid();
    }
}
