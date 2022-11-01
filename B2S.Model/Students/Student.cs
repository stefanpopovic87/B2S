using B2S.Infrastructure.Domain;
using B2S.Model.StudentCourses;

namespace B2S.Model.Students
{
    public class Student : AuditEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<StudentCourse> Courses { get; set; } = new HashSet<StudentCourse>();
    }
}
