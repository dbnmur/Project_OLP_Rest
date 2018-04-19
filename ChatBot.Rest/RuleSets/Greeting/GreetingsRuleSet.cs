using QXS.ChatBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot.Rest.RuleSets
{
    public class GreetingsRuleSet : IRuleSet
    {
        public IEnumerable<BotRule> Rules { get { return _rules; } set { _rules = value; } }
        private IEnumerable<BotRule> _rules = new List<BotRule>()
        {
            // reports your feelings
            new RandomAnswersBotRule("getfeeling", 40, new Regex("how (are you|do you feel)", RegexOptions.IgnoreCase), new string[] {"i feel great", "i feel tired", "i feel bored"}),

            // show the bot's name
            new BotRule(
                Name: "getbotname",
                Weight: 10,
                MessagePattern: new Regex("(who are you|(what is|say) your name)", RegexOptions.IgnoreCase),
                Process: delegate (Match match, ChatSessionInterface session) {
                    if (!session.SessionStorage.Values.ContainsKey("BotName"))
                    {
                        return "I do not have a name";
                    }
                    if (match.Value.ToLower() == "who are you")
                    {
                        return "i am " + session.SessionStorage.Values["BotName"];
                    }
                    return "My name is " + session.SessionStorage.Values["BotName"];
                }
            ),

            // set the name of the user
            new BotRule(
                Name: "setusername",
                Weight: 10,
                MessagePattern: new Regex("my name is (now )?(.*)", RegexOptions.IgnoreCase),
                Process: delegate (Match match, ChatSessionInterface session) {
                    session.SessionStorage.Values["UserName"] = match.Groups[2].Value;
                    return "Hi " + session.SessionStorage.Values["UserName"];
                }
            ),
            // show the user's name
            new BotRule(
                Name: "getusername",
                Weight: 20,
                MessagePattern: new Regex("(what is|say) my name", RegexOptions.IgnoreCase),
                Process: delegate (Match match, ChatSessionInterface session) {
                    if (!session.SessionStorage.Values.ContainsKey("UserName"))
                    {
                        return "Sorry, but you have not told my your name";
                    }
                    return "Your name is " + session.SessionStorage.Values["UserName"];
                }
            ),

            // greet
            new BotRule(
                Name: "greet",
                Weight: 2,
                MessagePattern: new Regex("(hi|hello|labas|sveikas)", RegexOptions.IgnoreCase),
                Process: delegate (Match match, ChatSessionInterface session) {
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
            ),
            // greet
            new BotRule(
                Name: "default",
                Weight: 1,
                MessagePattern: new Regex(".*", RegexOptions.IgnoreCase),
                Process: delegate (Match match, ChatSessionInterface session) {
                    string answer = "I don't understand, could you try repeating that?";

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
