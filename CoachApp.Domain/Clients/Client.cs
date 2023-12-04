using CoachApp.Domain._Common;
using CoachApp.Domain.Clients.Entities;
using CoachApp.Domain.Clients.Events;
using CoachApp.Domain.Clients.Models;

namespace CoachApp.Domain.Clients;
public class Client : AggregateRootPerTenant
{
    private readonly List<Pack> _packs;
    private readonly List<ClientService> _services;

#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    private Client() : base()
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    {

    }

    private Client(string lastname, string firstname, DateTime birthDate, ContactDetails? contactDetails, Address? address) : base(true)
    {
        Lastname = lastname;
        Firstname = firstname;
        BirthDate = birthDate;
        ContactDetails = contactDetails;
        Address = address;
        _packs = new List<Pack>();
        _services = new List<ClientService>();
    }

    public static Client Create(string lastname, string firstname, DateTime birthDate, ContactDetails? contactDetails, Address? address)
    {
        Client client = new(lastname, firstname, birthDate, contactDetails, address);
        client.RaiseEvent(new ClientCreated(client.Id));
        return client;
    }

    public string Lastname { get; private set; }

    public string Firstname { get; private set; }

    public DateTime BirthDate { get; private set; }

    public ContactDetails? ContactDetails { get; private set; }

    public Address? Address { get; private set; }

    public IReadOnlyCollection<Pack> Packs => _packs.AsReadOnly();
    public IReadOnlyCollection<ClientService> Services => _services.AsReadOnly();


    public void Update(string lastname, string firstname, DateTime birthDate, ContactDetails contactDetails, Address address)
    {
        Lastname = lastname;
        Firstname = firstname;
        BirthDate = birthDate;
        ContactDetails = contactDetails;
        Address = address;
    }

    public void AddPack(Pack newPack)
    {
        _packs.Add(newPack);
    }

    public void AddService(ClientService clientService)
    {
        _services.Add(clientService);
    }
}
