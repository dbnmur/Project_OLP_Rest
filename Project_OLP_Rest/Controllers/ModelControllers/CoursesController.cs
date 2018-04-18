using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Controllers
{
    //[Produces("application/json")]
    [Produces("application/json+hateoas")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/Courses
        [HttpGet(Name = "get-courses")]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseService.GetAll();
        }

        // GET: api/Courses/5
        [HttpGet("{id}", Name = "get-course")]
        public async Task<IActionResult> GetCourse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseService.FindBy(m => m.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}", Name = "edit-course")]
        public async Task<IActionResult> PutCourse([FromRoute] int id, [FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.CourseId)
            {
                return BadRequest();
            }

            try
            {
                await _courseService.Update(course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await CourseExists(id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses
        [HttpPost(Name = "add-course")]
        public async Task<IActionResult> PostCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _courseService.Create(course);

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}", Name = "delete-course")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseService.FindBy(c => c.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.Delete(course);

            return Ok(course);
        }

        private async Task<bool> CourseExists(int id)
        {
            return await _courseService.Exists(e => e.CourseId == id);
        }
    }
}