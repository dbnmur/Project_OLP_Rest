using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot
{
    public class RestChatBot
    {
        protected Stack<string> _commandHistory = new Stack<string>();
        protected SortedList<int, List<BotRule>> _botRules = new SortedList<int, List<BotRule>>(new DescComparer<int>());

        public Func<string, string> DefaultAnswer;

        public RestChatBot(IEnumerable<BotRule> Rules)
        {
            Dictionary<string, bool> ruleNames = new Dictionary<string, bool>();
            foreach (BotRule rule in Rules)
            {
                if (rule.Process == null)
                {
                    throw new ArgumentException("Process is null.", "Rules");
                }
                if (rule.MessagePattern == null)
                {
                    throw new ArgumentException("MessagePattern is null.", "Rules");
                }
                if (ruleNames.ContainsKey(rule.Name))
                {
                    throw new ArgumentException("Names are not unique. Duplicate key found for rule name \"" + rule.Name + "\".", "Rules");
                }
                ruleNames[rule.Name] = true;
                if (!this._botRules.ContainsKey(rule.Weight))
                {
                    this._botRules[rule.Weight] = new List<BotRule>();
                }
                this._botRules[rule.Weight].Add(rule);
            }
        }

        public string FindAnswer(ChatSessionInterface session, string messageIn)
        {
            foreach (List<BotRule> rules in this._botRules.Values)
            {
                foreach (BotRule rule in rules)
                {
                    Match match = rule.MessagePattern.Match(messageIn);
                    if (match.Success)
                    {
                        string msg = rule.Process(match, session);
                        if (msg != null)
                        {
                            session.AddResponseToHistory(new BotResponse(rule.Name, messageIn, msg));
                            return msg;
                        }
                    }
                }
            }
            return null;
        }

        public bool isGoodBye(string message)
        {
            switch (message.ToLower())
            {
                case "quit": return true;
                case "exit": return true;
                case "goodbye": return true;
                case "good bye": return true;
                case "bye": return true;
            }
            return false;
        }
    }
}
