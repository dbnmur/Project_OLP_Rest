using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.Rules
{
    public class GoodbyeRules
    {
        public static List<BotRule> rules = new List<BotRule>()
        {
               
                // greet
                new BotRule(
                    Name: "goodbye",
                    Weight: 2,
                    MessagePattern: new Regex("(goodbye|bye|iki|ate)", RegexOptions.IgnoreCase),
                    Process: delegate (Match match, ChatSessionInterface session) {
                        string answer = "bye bye";

                        if (session.SessionStorage.Values.ContainsKey("UserName"))
                        {
                            answer += " " + session.SessionStorage.Values["UserName"];
                        }
                        
                       
                        return answer;
                    }
                ),
                // greet
                new BotRule(
                    Name: "default",
                    Weight: 1,
                    MessagePattern: new Regex(".*", RegexOptions.IgnoreCase),
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
