using Microsoft.EntityFrameworkCore;

namespace CoachApp.EFCore.Core.Conventions;
internal static class ModelBuilderExtentions
{
    internal static void RemoveUnderScoreFromPropertyName(this ModelBuilder modelBuilder)
    {
        var modelEntityTypes = modelBuilder.Model.GetEntityTypes();

        foreach (var tableConfiguration in modelEntityTypes)
        {
            // Column Naming
            var columnsProperties = tableConfiguration.GetProperties();

            foreach (var columnsProperty in columnsProperties)
            {
                columnsProperty.SetColumnName(columnsProperty.Name.Replace("_", ""));   
            }
        }
    }
}
