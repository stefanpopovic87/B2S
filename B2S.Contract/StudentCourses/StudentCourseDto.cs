using B2S.Contract.Students;
using B2S.Infrastructure.Dtos;

namespace B2S.Contract.StudentCourses
{
    public class StudentCourseDto : EntityDto
    {
        public string Name { get; set; }
        public long Code { get; set; }
        public string? Tag { get; set; }

    }
}
