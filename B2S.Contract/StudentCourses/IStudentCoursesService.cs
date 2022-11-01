using B2S.Contract.Courses;

namespace B2S.Contract.StudentCourses
{
    public interface IStudentCoursesService
    {
        Task CreateStudentCourseAsync(CreateUpdateStudentCourseDto studentCourseDto);
        Task UpdateStudentCourseAsync(CreateUpdateStudentCourseDto studentCourseDto);
    }
}
