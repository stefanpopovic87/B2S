using B2S.Contract.StudentCourses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace B2S.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentCoursesController : Controller
    {
        private readonly IStudentCoursesService _studentCoursesService;

        public StudentCoursesController(IStudentCoursesService studentCoursesService)
        {
            _studentCoursesService = studentCoursesService;
        }

        // this method is responsible for add new grade
        [HttpPost("/createStudentCourse")]
        public async Task CreateStudentCourseAsync(CreateUpdateStudentCourseDto createStudentCourse)
        {
            await _studentCoursesService.CreateStudentCourseAsync(createStudentCourse);
        }

        /* Assignment 3
         * 
         * Implement API endpoint which set grade for student for particular course.
         * The endpoint should receive course ID, student ID and grade.
         */
        [HttpPut("/updateStudentCourse")]
        public async Task UpdateStudentCourseAsync(CreateUpdateStudentCourseDto updateStudentCourse)
        {
            await _studentCoursesService.UpdateStudentCourseAsync(updateStudentCourse);
        }
    }
}
