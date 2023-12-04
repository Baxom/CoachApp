using CoachApp.Domain.Clients;

namespace CoachApp.Application.Domain.Clients.Models.Mappers;
public static class ClientModelMapper
{
    public static ClientModel MapToClientModel(this Client client) => new ClientModel(client.Id, client.Lastname, client.Firstname, client.BirthDate, client.ContactDetails, client.Address);
}
