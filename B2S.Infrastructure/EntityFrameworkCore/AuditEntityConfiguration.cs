using B2S.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace B2S.Infrastructure.EntityFrameworkCore
{
    internal static class AuditEntityConfiguration
    {
        internal static void Configure<TEntity, T>(ModelBuilder modelBuilder) where TEntity : AuditEntity<T>
        {
            modelBuilder.Entity<TEntity>(builder =>
            {
                builder.HasQueryFilter(b => b.IsActive);
            });
        }

        internal static bool IsAuditEntity(this Type type, out Type T)
        {
            for (var baseType = type.BaseType; baseType != null; baseType = baseType.BaseType)
            {
                if (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == typeof(AuditEntity<>))
                {
                    T = baseType.GetGenericArguments()[0];

                    return true;
                }
            }

            T = null;

            return false;
        }
    }
}
