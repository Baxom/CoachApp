using CoachApp.CQRS.Aggregates;
using CoachApp.Domain.Users.Models;

namespace CoachApp.Domain.Users;
public class User : AggregateRoot
{
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    private User() : base()
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    {

    }

    private User(string login, string password) : base(true)
    {
        Login = login;
        Password = password;
    }

    public static User Create(string login, string password) => new(login, password);

    public string Login { get; private set; }
    public string Password { get; private set; }
    public string? Lastname { get; private set; }
    public string? Firstname { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public ContactDetails? ContactDetails { get; private set; }
    public CompanyInformation? CompanyInformation { get; private set; }
}
