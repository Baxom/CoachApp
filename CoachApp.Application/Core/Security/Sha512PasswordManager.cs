using CoachApp.Application.Core.Encrypting;

namespace CoachApp.Application.Core.Security;

internal class Sha512PasswordManager : IManagePassword
{
    private readonly IEncrypt _encryptor;

    public Sha512PasswordManager(IEncrypt encryptor)
    {
        _encryptor = encryptor;
    }

    public bool Compare(string password, string encryptedPassword) => string.Equals(Encrypt(password), encryptedPassword);

    public string Encrypt(string password) => _encryptor.Sha512Encrypt(password);
}
