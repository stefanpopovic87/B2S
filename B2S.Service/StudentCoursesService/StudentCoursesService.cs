using B2S.Contract.StudentCourses;
using B2S.Infrastructure.Domain;
using B2S.Model.Courses;
using B2S.Model.StudentCourses;

namespace B2S.Service.StudentCoursesService
{
    public class StudentCoursesService : IStudentCoursesService
    {
        private readonly IStudentCoursesRepository _studentCoursesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StudentCoursesService(IStudentCoursesRepository studentCoursesRepository, IUnitOfWork unitOfWork)
        {
            _studentCoursesRepository = studentCoursesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateStudentCourseAsync(CreateUpdateStudentCourseDto studentCourseDto)
        {
            var studentCourse = new StudentCourse
            {
                StudentId = studentCourseDto.StudentId,
                CourseId = studentCourseDto.CourseId,
                Grade = studentCourseDto.Grade
            };

            studentCourse.Create();

            await _studentCoursesRepository.InsertAsync(studentCourse);

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateStudentCourseAsync(CreateUpdateStudentCourseDto studentCourseDto)
        {
            var studentCourse = await _studentCoursesRepository.GetByStudentIdAndCourseIdAsync(studentCourseDto.StudentId, studentCourseDto.CourseId);

            studentCourse.Grade = studentCourseDto.Grade;

            await _studentCoursesRepository.UpdateAsync(studentCourse);

            await _unitOfWork.CommitAsync();
        }
    }
}
