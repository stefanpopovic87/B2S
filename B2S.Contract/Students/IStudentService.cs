using B2S.Contract.Courses;

namespace B2S.Contract.Students
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllStudentsAsync(StudentSearchDto studentSearch);
        Task CreateStudentAsync(CreateStudentDto createStudent);
    }
}
