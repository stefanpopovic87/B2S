using B2S.Infrastructure.Pagination;

namespace B2S.Contract.Courses
{
    public interface ICourseQuery
    {
        Task<PagedResult<CourseDto>> SearchCoursesAsync(SearchCourseDto paginationFilter);
    }
}
