using ChatBot.Rest.RuleSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBot.Rest.Factories
{
    public class RuleSetFactory
    {
        public static IRuleSet GetRuleSet(string type)
        {
            switch (type)
            {
                case "greetingsRuleSet":
                    return new GreetingsRuleSet();
                case "goodbyeRuleSet":
                    return new GoodbyeRuleSet();
                case "jokeRuleSet":
                    return new JokeRuleSet();
                case "phpCourseRuleSet":
                    return new PhpCourseRuleSet();
                case "javaCourseRuleSet":
                    return new JavaCourseRuleSet();
                default:
                    return null;
            }
        }
    }
}
