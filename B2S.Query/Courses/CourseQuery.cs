using B2S.Context;
using B2S.Contract.Courses;
using B2S.Infrastructure.EntityFrameworkCore;
using B2S.Infrastructure.Pagination;
using B2S.Model.Courses;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace B2S.Query.Courses
{
    public class CourseQuery : ICourseQuery
    {

        private readonly ApplicationContext _ctx;
        
        public CourseQuery (ApplicationContext ctx)
        {
            _ctx = ctx;
        }
       
        public async Task<PagedResult<CourseDto>> SearchCoursesAsync(SearchCourseDto searchCourse)
        {
            var courses = await _ctx.Courses
                .Include(x => x.Students)
                .Where(x => x.Name.ToLower().Contains(searchCourse.Term.Trim().ToLower()))
                .Select(x => new CourseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    AverageGrade = x.Students.Average(x => x.Grade)
                })
                .OrderBy(x => x.Name)
                .GetPagedResultAsync(searchCourse.Page, searchCourse.PageSize);

            return courses;
        }
    }
}
