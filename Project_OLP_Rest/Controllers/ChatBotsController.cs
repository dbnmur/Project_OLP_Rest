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
using RiskFirst.Hateoas;

namespace Project_OLP_Rest.Controllers
{

    [Route("api/ChatBots")]
    [Produces("application/json+hateoas")]
    public class ChatBotsController : Controller
    {
        private readonly IChatBotService _chatBotService;

        public ChatBotsController(IChatBotService chatBotService)
        {
            _chatBotService = chatBotService;
        }

        // GET: api/ChatBots
        [HttpGet]
        public IEnumerable<ChatBot> GetChatBots()
        {
            return _chatBotService.GetAll();
        }

        // GET: api/ChatBots/5
        [HttpGet("{id}", Name = "getchatBot")]
        public async Task<IActionResult> GetChatBot([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            var chatBot = _chatBotService.FindBy(m => m.ChatBotId == id);

            if (chatBot == null)
            {
                return NotFound();
            }
            return Ok(chatBot);
        }

        // PUT: api/ChatBots/5
        [HttpPut("{id}", Name = "edit-chatBot")]
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

            try
            {
                _chatBotService.Update(chatBot);
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
        [HttpPost(Name = "add-chatBot")]
        public async Task<IActionResult> PostChatBot([FromBody] ChatBot chatBot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _chatBotService.Create(chatBot);

            return CreatedAtAction("GetChatBot", new { id = chatBot.ChatBotId }, chatBot);
        }

        // DELETE: api/ChatBots/5
        [HttpDelete("{id}", Name = "delete-chatBot")]
        public async Task<IActionResult> DeleteChatBot([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatBot = _chatBotService.FindBy(m => m.ChatBotId == id);
            if (chatBot == null)
            {
                return NotFound();
            }

            _chatBotService.Delete(chatBot);

            return Ok(chatBot);
        }

        private bool ChatBotExists(int id)
        {
            return _chatBotService.Exists(e => e.ChatBotId == id);
        }
    }
}