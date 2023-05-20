namespace CoachApp.EFCore.Database;
internal static class CoachAppDbInitializer
{
    internal static void Initialize(this CoachAppContext context)
    {
        context.Database.EnsureCreated();
    }
}
