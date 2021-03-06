﻿using System;
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
    [Route("api/ChatSessions")]
    public class ChatSessionsController : Controller
    {
        private readonly IChatSessionService _chatSessionService;

        public ChatSessionsController(IChatSessionService chatSessionService)
        {
            _chatSessionService = chatSessionService;
        }

        // GET: api/ChatSessions
        [HttpGet(Name = "get-sessions")]
        public async Task<IEnumerable<ChatSession>> GetChatSessions()
        {
            return await _chatSessionService.GetAll();
        }

        // GET: api/ChatSessions/5
        [HttpGet("{id}", Name = "get-session")]
        public async Task<IActionResult> GetChatSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatSession = await _chatSessionService.FindBy(m => m.ChatSessionId == id);

            if (chatSession == null)
            {
                return NotFound();
            }

            return Ok(chatSession);
        }

        // PUT: api/ChatSessions/5
        [HttpPut("{id}",Name ="edit-session")]
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
                await _chatSessionService.Update(chatSession);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await ChatSessionExists(id)))
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
        [HttpPost(Name = "add-session")]
        public async Task<IActionResult> PostChatSession([FromBody] ChatSession chatSession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _chatSessionService.Create(chatSession);

            return CreatedAtAction("GetChatSession", new { id = chatSession.ChatSessionId }, chatSession);
        }

        // DELETE: api/ChatSessions/5
        [HttpDelete("{id}",Name = "delete-session")]
        public async Task<IActionResult> DeleteChatSession([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatSession = await _chatSessionService.FindBy(m => m.ChatSessionId == id);
            if (chatSession == null)
            {
                return NotFound();
            }

            await _chatSessionService.Delete(chatSession);

            return Ok(chatSession);
        }

        private async Task<bool> ChatSessionExists(int id)
        {
            return await _chatSessionService.Exists(e => e.ChatSessionId == id);
        }
    }
}