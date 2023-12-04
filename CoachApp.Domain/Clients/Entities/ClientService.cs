using CoachApp.CQRS.Aggregates;
using CoachApp.Domain._Common;
#pragma warning disable CS8618

namespace CoachApp.Domain.Clients.Entities;
public class ClientService : Entity
{
    public ClientService()
    {
        
    }

    public Guid ServiceId { get; set; }
    public Price Price { get; set; }
    
    public ClientService(Guid serviceId, Price price)
    {
        ServiceId = serviceId;
        Price = price;
    }
}
