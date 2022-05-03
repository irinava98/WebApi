using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseService service;

        public CourseController(CourseService service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
             return Ok(await service.GetAllCourses());   
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var result= await service.GetCourseById(id);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Course course)
        {
            if(course==null)
            {
                return BadRequest();
            }
            await service.AddCourse(course);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Course course)
        {
            if (course == null)
            {
                return NotFound();
            }
            await service.UpdateCourse(course);
            return Ok();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            await service.DeleteCourse(id);
            return NoContent();
        }





    }
}
