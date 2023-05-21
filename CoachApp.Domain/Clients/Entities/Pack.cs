using CoachApp.CQRS.Aggregates;
using CoachApp.Domain._Common;

namespace CoachApp.Domain.Clients.Entities;
public class Pack : Entity
{
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    private Pack() : base()
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
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
