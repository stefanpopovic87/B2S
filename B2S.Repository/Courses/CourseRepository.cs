using B2S.Context;
using B2S.Infrastructure.EntityFrameworkCore;
using B2S.Model.Courses;

namespace B2S.Repository.Courses
{
    public class CourseRepository : EntityFrameworkCoreRepository<ApplicationContext, Course>, ICourseRepository
    {
        public CourseRepository(ApplicationContext context) : base(context)
        {
        }    
    }
}
