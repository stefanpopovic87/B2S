using B2S.Contract.Client;
using B2S.Contract.Courses;
using B2S.Contract.Students;
using B2S.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        // this method is responsible for delete course
        [HttpDelete("/deleteCourse")]
        public async Task DeleteCourseAsync(DeleteCourseDto deleteCourse)
        {
            await _courseService.DeleteCourseAsync(deleteCourse);
        }


        /* Assignment 1
        * 
        * Implement API endpoint which returns list of the all active courses with following fields: Id, Name, Code, Average Grade.
        * The endpoint should support paging - it accepts page number and page size and based on parameters returns list of the courses.
        * The returned list of courses should be sorted by Name in ascending order.
        * The endpoint should support partial search - it accept search term and returns only courses which Name contains search term.
        */
        [HttpGet("/getAllCourses")]
        public async Task<ActionResult<PagedResult<CourseDto>>> GetAllCoursesAsync([FromQuery] SearchCourseDto searchCourse)
        {
            return (await _courseService.GetAllCoursesAsync(searchCourse));
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
