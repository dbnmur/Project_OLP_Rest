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
    [Produces("application/json", new string[] { "application/json+hateoas" })]
    [Route("api/Records")]
    public class RecordsController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        // GET: api/Records
        [HttpGet(Name = "get-records")]
        public async Task<IEnumerable<Record>> GetRecords()
        {
            return await _recordService.GetAll();
        }

        // GET: api/Records/5
        [HttpGet("{id}", Name = "get-record")]
        public async Task<IActionResult> GetRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = await _recordService.FindBy(m => m.RecordId == id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

        // PUT: api/Records/5
        [HttpPut("{id}", Name = "edit-record")]
        public async Task<IActionResult> PutRecord([FromRoute] int id, [FromBody] Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != record.RecordId)
            {
                return BadRequest();
            }

            try
            {
                await _recordService.Update(record);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await RecordExists(id)))
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

        // POST: api/Records
        [HttpPost(Name = "add-record")]
        public async Task<IActionResult> PostRecord([FromBody] Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _recordService.Create(record);

            return CreatedAtAction("GetRecord", new { id = record.RecordId }, record);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}", Name = "delete-record")]
        public async Task<IActionResult> DeleteRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = await _recordService.FindBy(m => m.RecordId == id);
            if (record == null)
            {
                return NotFound();
            }

            await _recordService.Delete(record);

            return Ok(record);
        }

        private async Task<bool> RecordExists(int id)
        {
            return await _recordService.Exists(e => e.RecordId == id);
        }
    }
}