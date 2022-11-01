using B2S.Context;
using B2S.Contract.Students;
using B2S.Model.StudentCourses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2S.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        public ApplicationContext applicationContext;

        private readonly IStudentService _studentService;


        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // this method is responsible for add student
        [HttpPost("/createStudent")]
        public async Task CreateStudentAsync(CreateStudentDto createStudent)
        {
            await _studentService.CreateStudentAsync(createStudent);
        }

        [HttpPut("/updateStudent")]
        public async Task UpdateStudentAsync(UpdateStudentDto updateStudent)
        {
            await _studentService.UpdateStudentAsync(updateStudent);
        }

        [HttpDelete("/deleteStudent")]
        public async Task DeleteStudentAsync(int id)
        {
            await _studentService.DeleteStudentAsync(id);
        }

        // this method is responsible for get all students
        [HttpGet("/getAllStudents")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetAllStudentsAsync([FromQuery] StudentSearchDto studentSearch)
        {
            return (await _studentService.GetAllStudentsAsync(studentSearch)).ToList();
        }

        
    }
}
