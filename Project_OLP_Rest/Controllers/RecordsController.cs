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
    [Route("api/Records")]
    public class RecordsController : Controller
    {
        private readonly IRecordService _recordService;

        public RecordsController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        // GET: api/Records
        [HttpGet]
        public IEnumerable<Record> GetRecords()
        {
            return _recordService.GetAll();
        }

        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = _recordService.FindBy(m => m.RecordId == id);

            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

        // PUT: api/Records/5
        [HttpPut("{id}")]
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
                _recordService.Update(record);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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
        [HttpPost]
        public async Task<IActionResult> PostRecord([FromBody] Record record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _recordService.Create(record);

            return CreatedAtAction("GetRecord", new { id = record.RecordId }, record);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var record = _recordService.FindBy(m => m.RecordId == id);
            if (record == null)
            {
                return NotFound();
            }

            _recordService.Delete(record);

            return Ok(record);
        }

        private bool RecordExists(int id)
        {
            return _recordService.Exists(e => e.RecordId == id);
        }
    }
}