using B2S.Context;
using B2S.Contract.StudentCourses;
using B2S.Contract.Students;
using Microsoft.EntityFrameworkCore;

namespace B2S.Query.Students
{
    public class StudentQuery : IStudentQuery
    {

        private readonly ApplicationContext _ctx;

        public StudentQuery(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync(StudentSearchDto studentSearch)
        {
            var students = await _ctx.Students
                .Where(x => x.IsActive)
                .Select(x => new StudentDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    DateCreated = x.DateCreated,
                    Courses = x.Courses
                        .Where(x => x.IsActive)
                        .Select(x => new StudentCourseDto()
                        {
                            Id = x.Course.Id,
                            Name = x.Course.Name,
                            Code = x.Course.Code,
                            Tag = x.Course.Tag

                        })
                        .ToList()
                })
                .ToListAsync();

            if (!string.IsNullOrEmpty(studentSearch.FirstName))
            {
                students = students.Where(s => s.FirstName.ToLower().Contains(studentSearch.FirstName.Trim().ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(studentSearch.LastName))
            {
                students = students.Where(s => s.LastName.ToLower().Contains(studentSearch.LastName.Trim().ToLower())).ToList();
            }

            return students;
        }
    }
}
