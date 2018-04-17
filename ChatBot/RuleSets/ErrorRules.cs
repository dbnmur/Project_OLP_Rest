using QXS.ChatBot.RulesSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.RuleSet
{
    public class ErrorRuleSet : IRuleSet
    {
        public IEnumerable<BotRule> Rules { get { return _rules; } }
        private IEnumerable<BotRule> _rules = new List<BotRule>()
        {
            new RandomAnswersBotRule("geterror", 40, new Regex("i have (error|exception)", RegexOptions.IgnoreCase), new string[] {"what kind of error ?", "whats wrong pal ?", "whats seems to be a problem ?"}),
            new BotRule(
                Name: "error",
                Weight: 41,
                MessagePattern: new Regex("(I have (error|exception))", RegexOptions.IgnoreCase),
                Process: delegate (Match match, ChatSessionInterface session) {
                    string answer = "Whats the problem ?";

                    if (session.SessionStorage.Values.ContainsKey("UserName"))
                    {
                        answer += ", " + session.SessionStorage.Values["UserName"];
                    }
                    return answer;
                }
            ),
            new BotRule(
                Name: "search",
                Weight: 41,
                MessagePattern: new Regex("(find the (solution|answer|how to| anything|about)(.*) this (error|exception))", RegexOptions.IgnoreCase),
                Process: delegate (Match match, ChatSessionInterface session) {
                    string answer = "try this. "+" google.com";

                    if (session.SessionStorage.Values.ContainsKey("UserName"))
                    {
                        answer += ", " + session.SessionStorage.Values["UserName"];
                    }

                    return answer;
                }
            )
        };
    }
}
