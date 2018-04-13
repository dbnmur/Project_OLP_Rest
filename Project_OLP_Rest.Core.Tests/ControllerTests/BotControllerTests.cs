using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project_OLP_Rest.Data;
using Project_OLP_Rest.Data.Services;
using Project_OLP_Rest.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project_OLP_Rest.Core.Tests.ControllerTests
{
    public class BotControllerTests
    {
        [Fact (Skip = "Due to changes to regex")]
        public void TestChat()
        {
            var options = new DbContextOptionsBuilder<OLP_Context>()
                .UseInMemoryDatabase(databaseName: "ChatTestDatabase")
                .Options;

            using (var context = new OLP_Context(options))
            {
                ChatBotService chatBotService = new ChatBotService(context);
                ChatSessionService chatSessionService = new ChatSessionService(context);

                ChatBotResponse response = new ChatBotResponse();
                ChatRequestBody request = new ChatRequestBody();

                Controllers.BotController botController = new Controllers.BotController(chatBotService, chatSessionService);

                request.Message = "Hi";
                response = JsonConvert.DeserializeObject<ChatBotResponse>(botController.Chat(request, "").Value.ToString());
                Assert.Contains("Hi!", response.Message.ToLower());

                request.Message = "My name is Sujiren";
                response = JsonConvert.DeserializeObject<ChatBotResponse>(botController.Chat(request, "").Value.ToString());
                Assert.Contains("sujiren", response.Message.ToLower());

                request.Message = "What is my name";
                response = JsonConvert.DeserializeObject<ChatBotResponse>(botController.Chat(request, "").Value.ToString());
                Assert.Contains("your name is", response.Message.ToLower());
            }
        }
    }
}
