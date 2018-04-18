using Project_OLP_Rest.Data.Interfaces;
using QXS.ChatBot;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ChatBot.Rest.Rules
{
    public class ExerciseBotRule : BotRule
    {
        private Func<Match, ChatSessionInterface, IExerciseService, string> _processSpecial;
        public Func<Match, ChatSessionInterface, IExerciseService, string> ProcessSpecial { get { return _processSpecial; } }

        public ExerciseBotRule(string Name, int Weight, Regex MessagePattern, Func<Match, ChatSessionInterface, string> Process) : base(Name, Weight, MessagePattern, Process) { }

        protected ExerciseBotRule(string Name, int Weight) : base(Name, Weight) { }

        protected ExerciseBotRule(string Name, int Weight, Regex MessagePattern) : base(Name, Weight, MessagePattern) { }

        public ExerciseBotRule(string Name, int Weight, Regex MessagePattern, Func<Match, ChatSessionInterface, IExerciseService, string> Process) : base(Name, Weight, MessagePattern)
        {
            _processSpecial = Process;
        }
    }
}
