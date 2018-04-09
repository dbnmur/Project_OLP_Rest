using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.Rules
{
    public class ErrorRules
    {
        public static List<BotRule> rules = new List<BotRule>()
        {
                new PowershellBotRule("pstest", 10, new Regex("powershell"), @" ( ""Hi from PowerShell "" + $PSVersionTable.PSVersion) "),
                // chatbot specific behaviour
                new ConditionBotRule(
                    "conditionBot",
                    50,
                    new Tuple<string, ConditionBotRule.Operator, string>[] {
                        new Tuple<string, ConditionBotRule.Operator, string>("BotName", ConditionBotRule.Operator.EqualIgnoreCase, "chatbot")
                    },
                    new BotRule[] {
                        // chatbot just knows positive feelings...
                        new RandomAnswersBotRule("getfeeling2", 40, new Regex("how (are you|do you feel)", RegexOptions.IgnoreCase), new string[] {"i feel super", "i feel perfect", "i feel happy"}),
                    }
                ),
                // repet the last known sentence
                new ReplacementBotRule("repeatLast", 41, new Regex("(please )?repeat the last sentence", RegexOptions.IgnoreCase), new string[] { "i repeat your last sentence:$s$sentence$", "$s$BotName$ repeats your last sentence:$s$sentence$"}),
                // repet a sentence
                new ReplacementBotRule("repeat", 40, new Regex("(please )?repeat(?<sentence> .*)", RegexOptions.IgnoreCase), new string[] { "i repeat your sentence:$r$sentence$", "$s$BotName$ repeats your sentence:$r$sentence$"}, new Dictionary<string, string>() { {"sentence", "$r$sentence$"} }),
                // reports your feelings
                new RandomAnswersBotRule("getfeeling", 40, new Regex("how (are you|do you feel)", RegexOptions.IgnoreCase), new string[] {"i feel great", "i feel tired", "i feel bored"}),
                // reports your feelings
                new RandomAnswersBotRule("geterror", 40, new Regex("i have (error|exception)", RegexOptions.IgnoreCase), new string[] {"what kind of error ?", "whats wrong pal ?", "whats seems to be a problem ?"}),

                new BotRule(
                    Name: "error",
                    Weight: 1,
                    MessagePattern: new Regex("(I have )", RegexOptions.IgnoreCase),
                    Process: delegate (Match match, ChatSessionInterface session) {
                        string answer = "well, i have to think about that";

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
