using CoachApp.Domain._Common;

namespace CoachApp.Domain.Services;
public class Service : AggregateRootPerTenant
{
    public string Name { get; private set; }
    public bool IsPersonalServices { get; private set; }

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    private Service() : base()
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    {

    }

    private Service(string serviceName, bool isPersonalServices) : base(true)
    {
        Name = serviceName;
        IsPersonalServices = isPersonalServices;
    }

    public static Service Create(string serviceName, bool isPersonalServices) => new(serviceName, isPersonalServices);

    public void Update(string serviceName, bool isPersonalServices)
    {
        Name = serviceName;
        IsPersonalServices = isPersonalServices;
    }
}
