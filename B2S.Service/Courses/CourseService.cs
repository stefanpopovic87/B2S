using B2S.Contract.Client;
using B2S.Contract.Courses;
using B2S.Infrastructure.Domain;
using B2S.Infrastructure.Pagination;
using B2S.Model.Courses;
using B2S.Model.Students;

namespace B2S.Service.Courses
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseQuery _courseQuery;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExternalApiClient _externalApiClient;


        public CourseService(ICourseRepository courseRepository,
            IUnitOfWork unitOfWork,
            IStudentRepository studentRepository,
            ICourseQuery courseQuery,
            IExternalApiClient externalApiClient)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
            _courseQuery = courseQuery;
            _externalApiClient = externalApiClient;
        }


        public async Task CreateCourseAsync(CreateCourseDto createCourse)
        {
            var course = new Course
            {
                Name = createCourse.Name,
                Code = createCourse.Code               
            };

            await _courseRepository.InsertAsync(course);

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCourseAsync(UpdateCourseDto updateCourse)
        {
            var course = await _courseRepository.GetByIdAsync(updateCourse.Id);

            if (course != null)
            {
                course.Name = updateCourse.Name;
                course.Code = updateCourse.Code;

                await _courseRepository.UpdateAsync(course);

                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course != null)
            {
                course.Delete();

                await _courseRepository.UpdateAsync(course);

                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteCoursesByStudentIdAsync(DeleteCourseDto deleteCourse)
        {
            var student = await _studentRepository.GetByIdAsync(deleteCourse.StudentId);

            if (student != null)
            {
                foreach (var item in student.Courses?.Where(x => x.Course.IsActive && x.Course.Tag == deleteCourse.Tag).ToList())
                {
                    item.Course.Delete();
                }
            }

            await _unitOfWork.CommitAsync();

        }

        public async Task<PagedResult<CourseDto>> SearchCoursesAsync(SearchCourseDto searchCourse)
        {
            return await _courseQuery.SearchCoursesAsync(searchCourse);
        }

        public async Task<GetCourseDetailsResponse> GetExternalCourseDetailsAsync(long code)
        {
            return await _externalApiClient.GetCourseDetailsAsync(code);
        }
    }
}
