using QXS.ChatBot.RulesSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.RuleSet
{
    public class JokeRulesSet : IRuleSet
    {
        public IEnumerable<BotRule> Rules { get { return _rules; } }

        public static List<string> jokeList;

        private IEnumerable<BotRule> _rules = new List<BotRule>()
        {
            new RandomAnswersBotRule("getjoke", 40, new Regex("tell me (.*) |(joke|jokes)|(more jokes)|(I want (.*) (hilarous|funny|silly) joke)|(joke)", RegexOptions.IgnoreCase),  getJokeList()),
        };

        private static string[] getJokeList()
        {
            string[] jokes = new string[]{
                "Lightning doesn't mean to shock people, it just doesn't know how to conduct itself.",
                "Why couldn't the bicycle stand? Because it was two tired.",
                "My jokes are still in alpha, hope they get beta soon.",
                "I don't have a big ego. I'm way too cool for that.",
                "If swimming is so good for your figure, how do you explain whales?",
                "Always remember that you are unique; just like everyone else.",
                "Worrying works! 90% of the things I worry about never happen.",
                "My first job was working in an orange juice factory, but I got canned because I couldn't concentrate.",
                "A bus station is where a bus stops. A train station is where a train stops. On my desk, I have a work station."
            };

            jokeList = new List<string>(jokes);

            return jokes;
        }
    }
}
