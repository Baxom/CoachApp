namespace CoachApp.CQRS.Exceptions;
public class AggregateNotFoundException : Exception
{
	public AggregateNotFoundException(Type aggregateType, Guid aggregateId) : base($"Cound not load aggregate {aggregateType} with id {aggregateId}")
	{

	}
}
