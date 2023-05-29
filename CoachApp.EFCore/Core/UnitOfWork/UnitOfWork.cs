using CoachApp.Application.Core.Repositories;
using CoachApp.Application.Domain.Users;
using CoachApp.Domain.Clients;
using CoachApp.Domain.Services;
using CoachApp.EFCore.Database;

namespace CoachApp.EFCore.Core.UnitOfWork;
internal class UnitOfWork : IUnitOfWork
{
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);
    private EFCoreContextTransaction? _unitOfWorkTransaction;

    public UnitOfWork(CoachAppContext coachAppContext, IRepository<Client> clients, IRepository<Service> services, IUserRepository users)
    {
        _coachAppContext = coachAppContext;
        Clients = clients;
        Services = services;
        Users = users;
    }

    private CoachAppContext _coachAppContext;

    public IRepository<Client> Clients { get; }
    public IRepository<Service> Services { get; }
    public IUserRepository Users { get; }

    public async Task SaveChangesAsync()
    {
        try
        {
            await _semaphore.WaitAsync();
            if (_unitOfWorkTransaction is not null) return;

            await _coachAppContext.SaveChangesAsync();
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task<IUnitOfWorkTransaction> BeginTransactionAsync(CancellationToken cancelationToken)
    {
        try
        {
            await _semaphore.WaitAsync();

            _unitOfWorkTransaction ??= new EFCoreContextTransaction(await _coachAppContext.Database.BeginTransactionAsync(cancelationToken), _coachAppContext);
            _unitOfWorkTransaction.IncrementHolder();
            return _unitOfWorkTransaction;
        }
        finally
        {
            _semaphore.Release();
        }
    }
}
