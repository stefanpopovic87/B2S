using B2S.Infrastructure.Domain;
using B2S.Model.Courses;
using B2S.Model.Students;

namespace B2S.Model.StudentCourses
{
    public class StudentCourse : AuditEntity
    {
        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public int Grade { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
