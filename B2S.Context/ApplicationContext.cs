using B2S.Infrastructure.Domain;
using B2S.Infrastructure.EntityFrameworkCore;
using B2S.Model.Courses;
using B2S.Model.StudentCourses;
using B2S.Model.Students;
using Microsoft.EntityFrameworkCore;

namespace B2S.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
                                   .Where(x => x.State == EntityState.Added)
                                   .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                var auditableEntity = insertedEntry as AuditEntity;
                //If the inserted object is an AuditEntity. 
                if (auditableEntity != null)
                {
                    auditableEntity.Create();
                }
            }

            var modifiedEntries = this.ChangeTracker.Entries()
                       .Where(x => x.State == EntityState.Modified)
                       .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                //If the inserted object is an AuditEntity. 
                var auditableEntity = modifiedEntry as AuditEntity;
                if (auditableEntity != null)
                {
                    auditableEntity.Update();
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAuditEntityConfiguration();

            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });            
        }
    }
}
