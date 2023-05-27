namespace CoachApp.Application.Core.Repositories;
public interface IUnitOfWorkTransaction : IDisposable
{
    Task CommitAsync(CancellationToken cancellationToken = default);
    Task RollbackAsync(CancellationToken cancellationToken = default);
}
