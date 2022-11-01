using B2S.Contract.StudentCourses;
using B2S.Infrastructure.Dtos;

namespace B2S.Contract.Students
{
    public class StudentDto : EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<StudentCourseDto> Courses { get; set; } = new HashSet<StudentCourseDto>();
    }
}
