using CoachApp.DDD.Aggregates;
using CoachApp.Domain.Users.Models;

namespace CoachApp.Domain.Users;
public class User : AggregateRoot
{
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    private User() : base()
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    {

    }

    private User(string email, string encryptedPassword) : base(true)
    {
        Email = email;
        EncrytedPassword = encryptedPassword;
    }

    public static User Create(string login, string encryptedPassword) => new(login, encryptedPassword);

    public string Email { get; private set; }
    public string EncrytedPassword { get; private set; }
    public string? Lastname { get; private set; }
    public string? Firstname { get; private set; }
    public DateTime? BirthDate { get; private set; }
    public ContactDetails? ContactDetails { get; private set; }
    public CompanyInformation? CompanyInformation { get; private set; }
}
