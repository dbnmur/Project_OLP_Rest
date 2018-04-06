using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QXS.ChatBot;
using QXS.ChatBot.ChatSessions;

namespace Project_OLP_Rest.Controllers
{
    [Produces("application/json")]
    [Route("api/Bot")]
    public class BotController : Controller
    {
        public static List<BotRule> dummyRules = new List<BotRule>()
        {
            new BotRule(
                Name: "greet",
                Weight: 2,
                MessagePattern: new Regex("(hi|hello)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    string answer = "Hi";
                    if (session.SessionStorage.Values.ContainsKey("UserName"))
                    {
                        answer += " " + session.SessionStorage.Values["UserName"];
                    }
                    answer += "!";
                    if (session.SessionStorage.Values.ContainsKey("BotName"))
                    {
                        answer += " I'm " + session.SessionStorage.Values["BotName"];
                    }
                    return answer;
                }
            )
        };
        private static Dictionary<string, ChatBot> chatBots = new Dictionary<string, ChatBot>();

        [HttpPost]
        public string Chat([FromBody]string message, [FromHeader]string sessionId)
        {
            return $"{message} {sessionId}";
        }

        private void InitializeChatBot(string id)
        {
            new ChatBot(dummyRules).talkWith(new RestChatSession());
        }
    }
}