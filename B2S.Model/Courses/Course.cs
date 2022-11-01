using B2S.Infrastructure.Domain;
using B2S.Model.StudentCourses;

namespace B2S.Model.Courses
{
    public class Course : AuditEntity
    {

        public string Name { get; set; }

        public long Code { get; set; }

        public string? Tag { get; set; }

        public virtual ICollection<StudentCourse> Students { get; set; } = new HashSet<StudentCourse>();
    }
}
