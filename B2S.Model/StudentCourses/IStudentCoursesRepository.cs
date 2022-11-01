using B2S.Infrastructure.Domain;

namespace B2S.Model.StudentCourses
{
    public interface IStudentCoursesRepository : IRepository<StudentCourse>
    {
        Task<StudentCourse> GetByStudentIdAndCourseIdAsync(int studentId, int courseId);
    }
}
