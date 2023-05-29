using CoachApp.Application.Domain.Users;
using CoachApp.Domain.Users;
using CoachApp.EFCore.Core.UnitOfWork;
using CoachApp.EFCore.Database;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.EFCore.Domain.Users;
internal class UserRepository : EFCoreRepository<User>, IUserRepository
{
	public UserRepository(CoachAppContext coachAppContext) : base(coachAppContext)
	{

	}

    public Task<User?> GetUserByEmail(string email) => _set.SingleOrDefaultAsync(b => b.Email == email);
}
