using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChatBot.Rest;
using ChatBot.Rest.ChatSessions;
using ChatBot.Rest.ResponseModels;
using ChatBot.Rest.RuleSets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.RequestModels;

namespace Project_OLP_Rest.Controllers.ChatbotControllers
{
    public abstract class GenericBotController<TRestChatBot, TRuleSet> : Controller
        where TRestChatBot : RestChatBot
        where TRuleSet : IRuleSet
    {
        protected readonly IChatBotService _chatBotService;
        protected readonly IChatSessionService _chatSessionService;

        protected RestChatBot _chatBot;
        protected IRuleSet _ruleSet;

        protected string _relativeRoute = "";
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
            Tuple<string, object> chatBotResponse = _chatBot.FindAnswer(currentChatSession, body.Message);

            string messageResponse = chatBotResponse.Item1;
            object responseObject = chatBotResponse.Item2;

            await SaveSessionDataAsync(currentChatSession);

            sessionId = chatSession.ChatSessionId.ToString();

            if (responseObject.GetType() == typeof(ExerciseResponse))
                return Json(new { sessionId = sessionId, chatbotResponse = messageResponse, exercise = responseObject });
            else
                return Json(new { sessionId = sessionId, chatbotResponse = messageResponse });
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
        protected virtual async Task<Domain.ChatBot> GetChatBotAsync()
        {
            Domain.ChatBot chatBotModel = null;
            if (await _chatBotService.Exists(cb => cb.Name == this._chatBotName))
                chatBotModel = await _chatBotService.FindBy(cb => cb.Name == this._chatBotName);
            else
                chatBotModel = await _chatBotService.Create(new Domain.ChatBot { Name = this._chatBotName });

            return chatBotModel;
        }

        /// <summary>
        /// Requires: bot name
        /// </summary>
        protected virtual void OnBotCreate() { }
    }

    [Route("api/php-bot")]
    public class PhpBotController : GenericBotController<RestChatBot, PhpCourseRuleSet>
    {
        private readonly IExerciseService _exerciseService;

        public PhpBotController(IChatBotService chatBotService, IChatSessionService chatSessionService, IExerciseService exerciseService) : base(chatBotService, chatSessionService)
        {
            _chatBotName = "PhpChatBot";
            _relativeRoute = "/api/php-bot";
            _exerciseService = exerciseService;
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