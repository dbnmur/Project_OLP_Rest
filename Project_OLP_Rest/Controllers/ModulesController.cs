using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest.Controllers
{
    //[Produces("application/json")]
    [Produces("application/json+hateoas")]
    [Route("api/Modules")]
    public class ModulesController : Controller
    {
        private readonly OLP_Context _context;

        public ModulesController(OLP_Context context)
        {
            _context = context;
        }

        // GET: api/Modules
        [HttpGet(Name = "get-modules")]
        public IEnumerable<Module> GetModules()
        {
            return _context.Modules;
        }

        // GET: api/Modules/5
        [HttpGet("{id}", Name = "get-module")]
        public async Task<IActionResult> GetModule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @module = await _context.Modules.SingleOrDefaultAsync(m => m.ModuleId == id);

            if (@module == null)
            {
                return NotFound();
            }

            return Ok(@module);
        }

        // PUT: api/Modules/5
        [HttpPut("{id}", Name = "edit-modules")]
        public async Task<IActionResult> PutModule([FromRoute] int id, [FromBody] Module @module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @module.ModuleId)
            {
                return BadRequest();
            }

            _context.Entry(@module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // POST: api/Modules
        [HttpPost(Name = "add-modules")]
        public async Task<IActionResult> PostModule([FromBody] Module @module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Modules.Add(@module);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModule", new { id = @module.ModuleId }, @module);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}", Name = "delete-modules")]
        public async Task<IActionResult> DeleteModule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @module = await _context.Modules.SingleOrDefaultAsync(m => m.ModuleId == id);
            if (@module == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(@module);
            await _context.SaveChangesAsync();

            return Ok(@module);
        }

        private bool ModuleExists(int id)
        {
            return _context.Modules.Any(e => e.ModuleId == id);
        }
    }
}