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
        public async Task<PagedResult<CourseDto>> GetAllCoursesAsync2(SearchCourseDto searchCourse)
        {
            var courses =  await _ctx.Courses
                .Include(x => x.Students)
                .Where(x => x.IsActive && x.Name.ToLower().Contains(searchCourse.Term.Trim().ToLower()))
                .Select(x => new CourseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    AverageGrade = x.Students.Average(s => s.Grade)
                })
                .OrderBy(x => x.Name)
                .GetPagedResultAsync(searchCourse.Page, searchCourse.PageSize);            

            return courses;
        }

        public async Task<PagedResult<CourseDto>> GetAllCoursesAsync(SearchCourseDto searchCourse)
        {
            var courses = await _ctx.StudentCourses
                .Include(x => x.Student)
                .Include(x => x.Course)
                .Where(x => x.IsActive && x.Course.Name.ToLower().Contains(searchCourse.Term.Trim().ToLower()))
                //.GroupBy(x => new { x.CourseId, x.Course.Name, x.Course.Code })
                .Select(x => new CourseDto
                {
                    Id = x.Course.Id,
                    Name = x.Course.Name,
                    Code = x.Course.Code,
                    AverageGrade = x.Course.Students.Average(x => x.Grade)
                })
                .OrderBy(x => x.Name)
                .GetPagedResultAsync(searchCourse.Page, searchCourse.PageSize);

            return courses;
        }
    }
}
