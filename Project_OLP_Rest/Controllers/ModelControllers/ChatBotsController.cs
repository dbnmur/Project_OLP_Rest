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
    //[Produces("application/json")]
    [Produces("application/json+hateoas")]
    [Route("api/ChatBots")]
    public class ChatBotsController : Controller
    {
        private readonly IChatBotService _chatBotService;

        public ChatBotsController(IChatBotService chatBotService)
        {
            _chatBotService = chatBotService;
        }

        // GET: api/ChatBots
        [HttpGet(Name = "get-chatbots")]
        public async Task<IEnumerable<ChatBot>> GetChatBots()
        {
            return await _chatBotService.GetAllAsync();
        }

        // GET: api/ChatBots/5
        [HttpGet("{id}",Name = "get-chatbot")]
        public async Task<IActionResult> GetChatBot([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatBot = await _chatBotService.FindBy(m => m.ChatBotId == id);

            if (chatBot == null)
            {
                return NotFound();
            }

            return Ok(chatBot);
        }

        // PUT: api/ChatBots/5
        [HttpPut("{id}", Name = "edit-chatbot")]
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
                await _chatBotService.Update(chatBot);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await ChatBotExists(id)))
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
        [HttpPost(Name = "add-chatbot")]
        public async Task<IActionResult> PostChatBot([FromBody] ChatBot chatBot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _chatBotService.Create(chatBot);

            return CreatedAtAction("GetChatBot", new { id = chatBot.ChatBotId }, chatBot);
        }

        // DELETE: api/ChatBots/5
        [HttpDelete("{id}", Name = "delete-chatbot")]
        public async Task<IActionResult> DeleteChatBot([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chatBot = await _chatBotService.FindBy(m => m.ChatBotId == id);
            if (chatBot == null)
            {
                return NotFound();
            }

            await _chatBotService.Delete(chatBot);

            return Ok(chatBot);
        }

        private async Task<bool> ChatBotExists(int id)
        {
            return await _chatBotService.Exists(e => e.ChatBotId == id);
        }
    }
}