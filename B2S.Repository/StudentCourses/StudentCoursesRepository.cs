using B2S.Context;
using B2S.Infrastructure.EntityFrameworkCore;
using B2S.Model.Courses;
using B2S.Model.StudentCourses;
using Microsoft.EntityFrameworkCore;

namespace B2S.Repository.StudentCourses
{
    public class StudentCoursesRepository : EntityFrameworkCoreRepository<ApplicationContext, StudentCourse>, IStudentCoursesRepository
    {
        public StudentCoursesRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<StudentCourse> GetByStudentIdAndCourseIdAsync(int studentId, int courseId)
        {
            return await Context.StudentCourses.Where(x => x.StudentId == studentId && x.CourseId == courseId)
                .FirstOrDefaultAsync();
        }
    }
}
