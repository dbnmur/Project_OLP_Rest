using ChatBot.Rest.Rules;
using Project_OLP_Rest.Data.Interfaces;
using QXS.ChatBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBot.Rest
{
    /// <summary>
    /// ChatBot class for REST services
    /// </summary>
    public class RestChatBot
    {
        private IExerciseService _exerciseService;

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
                    if (rule.GetType() == typeof(ExerciseBotRule))
                    {
                        if ((rule as ExerciseBotRule).ProcessSpecial == null)
                        {
                            throw new ArgumentException("Process is null.", "Rules");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Process is null.", "Rules");
                    }
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

        public RestChatBot(IEnumerable<BotRule> Rules, IExerciseService exerciseService) : this(Rules)
        {
            _exerciseService = exerciseService;
        }

        public void AddExerciseService(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public Tuple<string, object> FindAnswer(ChatSessionInterface session, string messageIn)
        {
            foreach (List<BotRule> rules in this._botRules.Values)
            {
                foreach (BotRule rule in rules)
                {
                    Match match = rule.MessagePattern.Match(messageIn);
                    if (match.Success)
                    {
                        Tuple<string, object> res;
                        if (rule.GetType() == typeof(ExerciseBotRule))
                        {
                            ExerciseBotRule exerciseBotRule = rule as ExerciseBotRule;
                            res = exerciseBotRule.ProcessSpecial(match, session, _exerciseService);
                        }
                        else
                        {
                            res = new Tuple<string, object>(rule.Process(match, session), null);
                        }

                        if (res != null)
                        {
                            //session.AddResponseToHistory(new BotResponse(rule.Name, messageIn, msg));
                            return res;
                        }
                    }
                }
            }
            return null;
        }
    }
}