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

namespace Project_OLP_Rest.Controllers.ModelControllers
{
    [Produces("application/json")]
    [Route("api/Exercises")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<IEnumerable<Exercise>> GetExercises()
        {
            return await _exerciseService.GetAll();
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercise = await _exerciseService.FindBy(m => m.RecordId == id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // PUT: api/Exercises/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise([FromRoute] int id, [FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.RecordId)
            {
                return BadRequest();
            }

            try
            {
                await _exerciseService.Update(exercise);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await ExerciseExists(id)))
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

        // POST: api/Exercises
        [HttpPost]
        public async Task<IActionResult> PostExercise([FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _exerciseService.Create(exercise);

            return CreatedAtAction("GetExercise", new { id = exercise.RecordId }, exercise);
        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercise = await _exerciseService.FindBy(m => m.RecordId == id);
            if (exercise == null)
            {
                return NotFound();
            }

            await _exerciseService.Delete(exercise);

            return Ok(exercise);
        }

        private async Task<bool> ExerciseExists(int id)
        {
            return await _exerciseService.Exists(ex => ex.RecordId == id);
        }
    }
}