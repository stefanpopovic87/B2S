using B2S.Contract.Client;
using B2S.Contract.Courses;
using B2S.Contract.StudentCourses;
using B2S.Contract.Students;
using B2S.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2S.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // this method is responsible for add course
        [HttpPost("/createCourse")]
        public async Task CreateCourseAsync(CreateCourseDto createCourse)
        {
            await _courseService.CreateCourseAsync(createCourse);
        }

        [HttpPut("/updateCourse")]
        public async Task UpdateCourseAsync(UpdateCourseDto updateCourse)
        {
            await _courseService.UpdateCourseAsync(updateCourse);
        }

        [HttpDelete("/deleteCourse")]
        public async Task DeleteCourseAsync(int id)
        {
            await _courseService.DeleteCourseAsync(id);
        }

        // this method is responsible for delete course
        [HttpDelete("/deleteCoursesByStudentId")]
        public async Task DeleteCoursesByStudentIdAsync(DeleteCourseDto deleteCourse)
        {
            await _courseService.DeleteCoursesByStudentIdAsync(deleteCourse);
        }

        /* Assignment 1
        * 
        * Implement API endpoint which returns list of the all active courses with following fields: Id, Name, Code, Average Grade.
        * The endpoint should support paging - it accepts page number and page size and based on parameters returns list of the courses.
        * The returned list of courses should be sorted by Name in ascending order.
        * The endpoint should support partial search - it accept search term and returns only courses which Name contains search term.
        */
        [HttpGet("/searchCourses")]
        public async Task<ActionResult<PagedResult<CourseDto>>> SearchCoursesAsync([FromQuery] SearchCourseDto searchCourse)
        {
            return (await _courseService.SearchCoursesAsync(searchCourse));
        }


        /* Assignmnet 2
         * 
         * Implement API endpoint which returns course details with following fields: Id, Name, Code, Average Grade, Description, Rating, Level, Lectures.
         * The endpoint should use external API to get additional details for the course based on code.
         * The external API token and Swagger page can be found in README.md file.
         */
        [HttpGet("/getExternalCourseDetails")]
        public async Task<GetCourseDetailsResponse> GetExternalCourseDetailsAsync(long code)
        {
            return await _courseService.GetExternalCourseDetailsAsync(code);
        }
    }
}
