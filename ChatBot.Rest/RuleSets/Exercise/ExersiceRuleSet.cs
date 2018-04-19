using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using QXS.ChatBot;

namespace ChatBot.Rest.RuleSets
{
    public class ExerciseRuleSet : IRuleSet
    {
        private List<BotRule> _rules;
        public IEnumerable<BotRule> Rules { get { return _rules; } }

        public ExerciseRuleSet()
        {
            _rules = new List<BotRule>()
            {
                new BotRule(
                    Name: "dbexercise",
                    Weight: 10,
                    MessagePattern: new Regex("(give (me )?(a )?(new )?(task|exercise))", RegexOptions.IgnoreCase),
                    Process: delegate(Match match, ChatSessionInterface session)
                    {
                        return "";
                    }
                )
            };
        }
    }
}
