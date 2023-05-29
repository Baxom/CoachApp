namespace CoachApp.Application.Core.Security;
internal interface IManagePassword
{
    string Encrypt(string password);

    bool Compare(string password, string encryptedPassword);
}
