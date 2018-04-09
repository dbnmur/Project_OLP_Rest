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
        private readonly IChatSessionService _chatSessionService;

        public ChatSessionsController(IChatSessionService chatSessionService)
        {
            _chatSessionService = chatSessionService;
        }

        // GET: api/ChatSessions
        [HttpGet]
        public IEnumerable<ChatSession> GetChatSessions()
        {
            return _chatSessionService.GetAll();
        }

        // GET: api/ChatSessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChatSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatSession = _chatSessionService.FindBy(m => m.ChatSessionId == id);

            if (chatSession == null)
            {
                return NotFound();
            }

            return Ok(chatSession);
        }

        // PUT: api/ChatSessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChatSession([FromRoute] int id, [FromBody] ChatSession chatSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatSession.ChatSessionId)
            {
                return BadRequest();
            }

            try
            {
                _chatSessionService.Update(chatSession);
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

            _chatSessionService.Create(chatSession);

            return CreatedAtAction("GetChatSession", new { id = chatSession.ChatSessionId }, chatSession);
        }

        // DELETE: api/ChatSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChatSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatSession = _chatSessionService.FindBy(m => m.ChatSessionId == id);
            if (chatSession == null)
            {
                return NotFound();
            }

            _chatSessionService.Delete(chatSession);

            return Ok(chatSession);
        }

        private bool ChatSessionExists(int id)
        {
            return _chatSessionService.Exists(e => e.ChatSessionId == id);
        }
    }
}