using CoachApp.Application.Core.Repositories;
using CoachApp.Domain.Users;

namespace CoachApp.Application.Domain.Users;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmail(string email);
}
