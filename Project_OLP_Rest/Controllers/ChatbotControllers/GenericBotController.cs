using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_OLP_Rest.Data.Interfaces;
using QXS.ChatBot;
using QXS.ChatBot.RuleSet;

namespace Project_OLP_Rest.Controllers.ChatbotControllers
{
    public abstract class GenericBotController : Controller
    {
        private readonly IChatBotService _chatBotService;
        private readonly IChatSessionService _chatSessionService;

        private RestChatBot _chatBot;



        protected string _chatBotName = null;

        public GenericBotController(IChatBotService chatBotService, IChatSessionService chatSessionService)
        {
            _chatBotService = chatBotService;
            _chatSessionService = chatSessionService;
        }

        /// <summary>
        /// Requires: bot name, ruleset
        /// </summary>
        protected abstract void SetUpBot();
    }

    public class PhpBotController : GenericBotController
    {
        public PhpBotController(IChatBotService chatBotService, IChatSessionService chatSessionService) : base(chatBotService, chatSessionService) { }

        protected override void SetUpBot()
        {
            PHPCourseRuleSet ruleSet = new PHPCourseRuleSet();


            _chatBotName = "PhpChatBot";
        }

    }
}