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
    [Produces("application/json")]
    [Route("api/Modules")]
    public class ModulesController : Controller
    {
        private readonly IModuleService _moduleService;

        public ModulesController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        // GET: api/Modules
        [HttpGet]
        public IEnumerable<Module> GetModules()
        {
            return _moduleService.GetAll();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var module = _moduleService.FindBy(m => m.ModuleId == id);

            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        // PUT: api/Modules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule([FromRoute] int id, [FromBody] Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @module.ModuleId)
            {
                return BadRequest();
            }

            try
            {
                _moduleService.Update(module);
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
        [HttpPost]
        public async Task<IActionResult> PostModule([FromBody] Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _moduleService.Create(module);

            return CreatedAtAction("GetModule", new { id = @module.ModuleId }, @module);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var module = _moduleService.FindBy(m => m.ModuleId == id);
            if (module == null)
            {
                return NotFound();
            }

            _moduleService.Delete(module);

            return Ok(@module);
        }

        private bool ModuleExists(int id)
        {
            return _moduleService.Exists(module => module.ModuleId == id);
        }
    }
}