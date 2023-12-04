using CoachApp.DDD.Aggregates;
using CoachApp.Domain._Common;
#pragma warning disable CS8618

namespace CoachApp.Domain.Clients.Entities;
public class Pack : Entity
{
    private Pack() : base()
    {

    }

    private Pack(Guid serviceId, DateTime? paymentDate, Price price, int numberOfSessions) : base(true)
    {
        ServiceId = serviceId;
        PaymentDate = paymentDate;
        Price = price;
        NumberOfSessions = numberOfSessions;
        RemainingSessions = numberOfSessions;
    }

    public static Pack Create(Guid serviceId, DateTime? paymentDate, Price price, int numberOfSessions) => new(serviceId, paymentDate, price, numberOfSessions);
    public Guid ServiceId { get; private set; }
    public DateTime? PaymentDate { get; private set; }
    public Price Price { get; private set; }
    public int NumberOfSessions { get; private set; }
    public int RemainingSessions { get; private set; }
}
