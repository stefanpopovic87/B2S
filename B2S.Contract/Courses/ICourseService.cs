using B2S.Contract.Client;
using B2S.Infrastructure.Pagination;

namespace B2S.Contract.Courses
{
    public interface ICourseService
    {
        Task CreateCourseAsync(CreateCourseDto createCourse);
        Task UpdateCourseAsync(UpdateCourseDto updateCourse);
        Task DeleteCourseAsync(int id);
        Task DeleteCoursesByStudentIdAsync(DeleteCourseDto deleteCourse);
        Task<PagedResult<CourseDto>> SearchCoursesAsync(SearchCourseDto searchCourse);
        Task<GetCourseDetailsResponse> GetExternalCourseDetailsAsync(long code);

    }
}
