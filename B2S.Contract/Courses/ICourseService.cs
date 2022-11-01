using B2S.Contract.Client;
using B2S.Infrastructure.Pagination;

namespace B2S.Contract.Courses
{
    public interface ICourseService
    {
        Task CreateCourseAsync(CreateCourseDto createCourse);
        Task DeleteCourseAsync(DeleteCourseDto deleteCourse);
        Task<PagedResult<CourseDto>> GetAllCoursesAsync(SearchCourseDto searchCourse);
        Task<GetCourseDetailsResponse> GetExternalCourseDetailsAsync(long code);

    }
}
