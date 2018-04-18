using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.RequestModels;
using QXS.ChatBot;
using QXS.ChatBot.ChatSessions;
using QXS.ChatBot.RuleSet;
using QXS.ChatBot.RulesSets;

namespace Project_OLP_Rest.Controllers.ChatbotControllers
{
    public abstract class GenericBotController<TRestChatBot, TRuleSet> : Controller
        where TRestChatBot : RestChatBot
        where TRuleSet : IRuleSet
    {
        private readonly IChatBotService _chatBotService;
        private readonly IChatSessionService _chatSessionService;

        protected RestChatBot _chatBot;
        protected IRuleSet _ruleSet;

        protected string _chatBotName = null;

        [HttpPost]
        public async Task<JsonResult> ChatAsync([FromBody]ChatRequestBody body, [FromHeader]string sessionId)
        {
            IRestChatSession currentChatSession = null;
            Domain.ChatBot chatBot = await GetChatBotAsync();
            Domain.ChatSession chatSession = null;
            if (String.IsNullOrEmpty(sessionId))
            {
                chatSession = await _chatSessionService.Create(new Domain.ChatSession() { ChatBotId = chatBot.ChatBotId });
                currentChatSession = new RestChatSession();
            }
            else
            {
                if (await _chatSessionService.Exists(session => session.ChatSessionId == Int32.Parse(sessionId)))
                    chatSession = await _chatSessionService.FindBy(session => session.ChatSessionId == Int32.Parse(sessionId));
                else
                    chatSession = await _chatSessionService.Create(new Domain.ChatSession() { ChatBotId = chatBot.ChatBotId });

                Dictionary<string, string> sessionData = null;
                if (String.IsNullOrEmpty(chatSession.Data))
                    sessionData = new Dictionary<string, string>();
                else
                    sessionData = JsonConvert.DeserializeObject<Dictionary<string, string>>(chatSession.Data);

                currentChatSession = new RestChatSession(chatSession.ChatSessionId, sessionData);
            }
            string chatbotResponse = _chatBot.FindAnswer(currentChatSession, body.Message);
            await SaveSessionDataAsync(currentChatSession);

            sessionId = chatSession.ChatSessionId.ToString();

            return Json(new { sessionId = sessionId, chatbotResponse = chatbotResponse });
        }

        public GenericBotController(IChatBotService chatBotService, IChatSessionService chatSessionService)
        {
            _ruleSet = (IRuleSet)Activator.CreateInstance(typeof(TRuleSet));
            _chatBot = (RestChatBot)Activator.CreateInstance(typeof(TRestChatBot), new object[] { _ruleSet.Rules });

            _chatBotService = chatBotService;
            _chatSessionService = chatSessionService;

            OnBotCreate();
        }

        private async Task SaveSessionDataAsync(IRestChatSession session)
        {
            if (await _chatSessionService.Exists(s => s.ChatSessionId == session.Id))
            {
                Domain.ChatSession dbChatSession = await _chatSessionService.FindBy(s => s.ChatSessionId == session.Id);
                dbChatSession.Data = JsonConvert.SerializeObject(session.SessionStorage.Values);
                await _chatSessionService.Update(dbChatSession);
            }
        }

        /// <summary>
        /// Fetches chatbot or creates if it doesn't exist
        /// </summary>
        /// <returns></returns>
        private async Task<Domain.ChatBot> GetChatBotAsync()
        {
            Domain.ChatBot chatBotModel = null;
            if (await _chatBotService.Exists(cb => cb.Name == this._chatBotName))
                chatBotModel = await _chatBotService.FindBy(cb => cb.Name == this._chatBotName);
            else
                chatBotModel = await _chatBotService.Create(new Domain.ChatBot { Name = this._chatBotName });

            return chatBotModel;
        }

        /// <summary>
        /// Requires: bot name, ruleset
        /// </summary>
        protected abstract void OnBotCreate();
    }

    [Route("api/php-bot")]
    public class PhpBotController : GenericBotController<RestChatBot, ErrorRuleSet>
    {
        public PhpBotController(IChatBotService chatBotService, IChatSessionService chatSessionService) : base(chatBotService, chatSessionService) { }

        protected override void OnBotCreate()
        {
            _chatBotName = "PhpChatBot";
        }
    }
}