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
    [Produces("application/json")]
    [Route("api/ChatBots")]
    public class ChatBotsController : Controller
    {
        private readonly OLP_Context _context;

        public ChatBotsController(OLP_Context context)
        {
            _context = context;
        }

        // GET: api/ChatBots
        [HttpGet]
        public IEnumerable<ChatBot> GetChatBots()
        {
            return _context.ChatBots;
        }

        // GET: api/ChatBots/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatBot([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatBot = await _context.ChatBots.SingleOrDefaultAsync(m => m.ChatBotId == id);

            if (chatBot == null)
            {
                return NotFound();
            }

            return Ok(chatBot);
        }

        // PUT: api/ChatBots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatBot([FromRoute] int id, [FromBody] ChatBot chatBot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatBot.ChatBotId)
            {
                return BadRequest();
            }

            _context.Entry(chatBot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatBotExists(id))
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

        // POST: api/ChatBots
        [HttpPost]
        public async Task<IActionResult> PostChatBot([FromBody] ChatBot chatBot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ChatBots.Add(chatBot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChatBot", new { id = chatBot.ChatBotId }, chatBot);
        }

        // DELETE: api/ChatBots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatBot([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatBot = await _context.ChatBots.SingleOrDefaultAsync(m => m.ChatBotId == id);
            if (chatBot == null)
            {
                return NotFound();
            }

            _context.ChatBots.Remove(chatBot);
            await _context.SaveChangesAsync();

            return Ok(chatBot);
        }

        private bool ChatBotExists(int id)
        {
            return _context.ChatBots.Any(e => e.ChatBotId == id);
        }
    }
}