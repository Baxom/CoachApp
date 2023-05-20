using CoachApp.Domain._Common;

namespace CoachApp.Domain.Packs;
public class Pack : BaseAggregatePerTenant
{
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    private Pack() : base()
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    {

    }

    private Pack(Guid clientId, Guid serviceId, DateTime? paymentDate, decimal amount, int numberOfSessions) : base(true)
    {
        ClientId = clientId;
        ServiceId = serviceId;
        PaymentDate = paymentDate;
        Amount = amount;
        NumberOfSessions = numberOfSessions;
        RemainingSessions = numberOfSessions;
    }

    public static Pack Create(Guid clientId, Guid serviceId, DateTime? paymentDate, decimal amount, int numberOfSessions) => new(clientId, serviceId, paymentDate, amount, numberOfSessions);
    public Guid ClientId { get; }
    public Guid ServiceId { get; }
    public DateTime? PaymentDate { get; }
    public decimal Amount { get; }
    public int NumberOfSessions { get; }
    public int RemainingSessions { get; }
}
