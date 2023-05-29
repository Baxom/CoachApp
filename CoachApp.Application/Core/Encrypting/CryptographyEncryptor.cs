using System.Text;

namespace CoachApp.Application.Core.Encrypting;

public class CryptographyEncryptor : IEncrypt
{
    public string Sha512Encrypt(string value)
    {
        byte[] data = Encoding.ASCII.GetBytes(value);
        using (var encryptor = System.Security.Cryptography.SHA512.Create())
        {
            data = encryptor.ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}


