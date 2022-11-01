using B2S.Infrastructure.Dtos;

namespace B2S.Contract.Courses
{
    public class UpdateCourseDto : EntityDto
    {
        public string Name { get; set; }

        public long Code { get; set; }
    }
}
