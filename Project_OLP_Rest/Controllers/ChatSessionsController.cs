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
    [Route("api/ChatSessions")]
    public class ChatSessionsController : Controller
    {
        private readonly OLP_Context _context;

        public ChatSessionsController(OLP_Context context)
        {
            _context = context;
        }

        // GET: api/ChatSessions
        [HttpGet]
        public IEnumerable<ChatSession> GetChatSessions()
        {
            return _context.ChatSessions;
        }

        // GET: api/ChatSessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatSession([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatSession = await _context.ChatSessions.SingleOrDefaultAsync(m => m.ChatSessionId == id);

            if (chatSession == null)
            {
                return NotFound();
            }

            return Ok(chatSession);
        }

        // PUT: api/ChatSessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatSession([FromRoute] Guid id, [FromBody] ChatSession chatSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatSession.ChatSessionId)
            {
                return BadRequest();
            }

            _context.Entry(chatSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatSessionExists(id))
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

        // POST: api/ChatSessions
        [HttpPost]
        public async Task<IActionResult> PostChatSession([FromBody] ChatSession chatSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ChatSessions.Add(chatSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatSession", new { id = chatSession.ChatSessionId }, chatSession);
        }

        // DELETE: api/ChatSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatSession([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatSession = await _context.ChatSessions.SingleOrDefaultAsync(m => m.ChatSessionId == id);
            if (chatSession == null)
            {
                return NotFound();
            }

            _context.ChatSessions.Remove(chatSession);
            await _context.SaveChangesAsync();

            return Ok(chatSession);
        }

        private bool ChatSessionExists(Guid id)
        {
            return _context.ChatSessions.Any(e => e.ChatSessionId == id);
        }
    }
}