using B2S.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace B2S.Infrastructure.EntityFrameworkCore
{
    public class AuditEntityInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (!(entry.Entity is AuditEntity auditEntity))
                {
                    continue;
                }

                switch (entry.State)
                {
                    case EntityState.Added:                        
                        auditEntity.Create();
                        break;

                    case EntityState.Modified:
                        auditEntity.Update();
                        break;

                    case EntityState.Deleted:                       
                        entry.State = EntityState.Modified;
                        auditEntity.Delete();                        
                        break;

                    default:
                        break;
                }
            }
            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}