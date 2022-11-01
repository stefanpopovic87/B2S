using B2S.Contract.Courses;

namespace B2S.Contract.Students
{
    public interface IStudentService
    {
        Task CreateStudentAsync(CreateStudentDto createStudent);
        Task UpdateStudentAsync(UpdateStudentDto updateStudent);
        Task DeleteStudentAsync(int id);

        Task<IEnumerable<StudentDto>> GetAllStudentsAsync(StudentSearchDto studentSearch);
    }
}
