using B2S.Infrastructure.Dtos;

namespace B2S.Contract.Students
{
    public class UpdateStudentDto : EntityDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
