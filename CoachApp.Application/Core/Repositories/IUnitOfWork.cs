using CoachApp.Domain.Clients;
using CoachApp.Domain.Services;
using CoachApp.Domain.Users;

namespace CoachApp.Application.Core.Repositories;
public interface IUnitOfWork
{
    IRepository<Client> Clients { get; }
    IRepository<Service> Services { get; }
    IRepository<User> Users { get; }

    Task SaveChangesAsync();

    Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
