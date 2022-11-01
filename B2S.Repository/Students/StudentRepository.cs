using B2S.Context;
using B2S.Infrastructure.EntityFrameworkCore;
using B2S.Model.Students;
using Microsoft.EntityFrameworkCore;

namespace B2S.Repository.Students
{
    public class StudentRepository : EntityFrameworkCoreRepository<ApplicationContext, Student>, IStudentRepository
    {
        public StudentRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<Student> GetByIdAsync(int id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await GetQueryable(includeDetails)
                .Include(x => x.Courses)
                .ThenInclude(x => x.Course)
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

    }
}
