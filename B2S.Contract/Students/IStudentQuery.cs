namespace B2S.Contract.Students
{
    public interface IStudentQuery
    {
        Task<IEnumerable<StudentDto>> GetAllAsync(StudentSearchDto studentSearch);
    }
}
