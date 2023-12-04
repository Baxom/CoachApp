using CoachApp.DDD.Aggregates;
using CoachApp.EFCore.Database;
using Microsoft.EntityFrameworkCore;

namespace CoachApp.EFCore.Core.Readers;
internal abstract class EFCoreReader<T> where T : class, IAggregateRoot
{
    private readonly CoachAppContext _coachAppContext;

    protected DbSet<T> _set => _coachAppContext.CreateContextForQuery().Set<T>();

    protected EFCoreReader(CoachAppContext coachAppContext)
    {
        _coachAppContext = coachAppContext;
    }
}
