using System.Collections.ObjectModel;
using CoachApp.Domain._Common;
using CoachApp.Domain.Clients.Entities;
using CoachApp.Domain.Clients.Models;

namespace CoachApp.Domain.Clients;
public class Client : AggregateRootPerTenant
{
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    private Client() : base()
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    {

    }

    private Client(string lastname, string firstname, DateTime birthDate, ContactDetails contactDetails, Adress adress) : base(true)
    {
        Lastname = lastname;
        Firstname = firstname;
        BirthDate = birthDate;
        ContactDetails = contactDetails;
        Adress = adress;
        Packs = new List<Pack>();
    }

    public static Client Create(string lastname, string firstname, DateTime birthDate, ContactDetails contactDetails, Adress adress) => new(lastname, firstname, birthDate, contactDetails, adress);

    public string Lastname { get; private set; }
    public string Firstname { get; private set; }
    public DateTime BirthDate { get; private set; }
    public ContactDetails ContactDetails { get; private set; }
    public Adress Adress { get; private set; }
    public ICollection<Pack> Packs { get; private set; }

    public void Update(string lastname, string firstname, DateTime birthDate, ContactDetails contactDetails, Adress adress)
    {
        Lastname = lastname;
        Firstname = firstname;
        BirthDate = birthDate;
        ContactDetails = contactDetails;
        Adress = adress;
    }

    public void AddPack(Pack newPack)
    {
        Packs.Add(newPack);
    }
}
