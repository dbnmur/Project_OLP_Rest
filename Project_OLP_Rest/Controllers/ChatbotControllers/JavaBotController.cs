using System;
using System.Threading.Tasks;
using ChatBot.Rest;
using ChatBot.Rest.Factories;
using ChatBot.Rest.RuleSets;
using Microsoft.AspNetCore.Mvc;
using Project_OLP_Rest.Data.Interfaces;

namespace Project_OLP_Rest.Controllers.ChatbotControllers
{
    [Route("api/java-bot")]
    public class JavaBotController : GenericBotController<RestChatBot>
    {
        private readonly IExerciseService _exerciseService;

        public JavaBotController(IChatBotService chatBotService, IChatSessionService chatSessionService, IExerciseService exerciseService) : base(chatBotService, chatSessionService)
        {
            _ruleSet = RuleSetFactory.GetRuleSet("javaCourseRuleSet");

            _chatBotName = "JavaChatBot";
            _relativeRoute = "/api/java-bot";
            _exerciseService = exerciseService;

            AddRuleSet(RuleSetFactory.GetRuleSet("jokeRuleSet"));
            AddRuleSet(RuleSetFactory.GetRuleSet("greetingsRuleSet"));
            AddRuleSet(RuleSetFactory.GetRuleSet("goodbyeRuleSet"));

            _chatBot = new RestChatBot(_ruleSet.Rules);
            _chatBot.AddExerciseService(_exerciseService);
        }

        /// <summary>
        /// Fetches chatbot or creates if it doesn't exist
        /// </summary>
        /// <returns></returns>
        protected override async Task<Domain.ChatBot> GetChatBotAsync()
        {
            Domain.ChatBot chatBot = await base.GetChatBotAsync();
            if (String.IsNullOrEmpty(chatBot.Link) || chatBot.Link != _relativeRoute)
            {
                chatBot.Link = _relativeRoute;
                await _chatBotService.Update(chatBot);
            }
            return chatBot;
        }
    }
}