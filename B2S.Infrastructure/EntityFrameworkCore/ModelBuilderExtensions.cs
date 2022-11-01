using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace B2S.Infrastructure.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder ApplyAuditEntityConfiguration(this ModelBuilder modelBuilder)
        {
            var configureMethod = typeof(AuditEntityConfiguration)
                .GetTypeInfo()
                .DeclaredMethods
                .Single(m => m.Name == nameof(AuditEntityConfiguration.Configure));

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.IsAuditEntity(out var T))
                {
                    configureMethod.MakeGenericMethod(entityType.ClrType, T).Invoke(null, new[] { modelBuilder });
                }
            }

            return modelBuilder;
        }
    }
}
