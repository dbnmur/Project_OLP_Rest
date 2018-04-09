using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.Rules
{
    public class PhpCourseRule
    {
        public List<BotRule> PHPCourseRule = new List<BotRule>()
        {
            new BotRule(
                Name: "setcoursename",
                Weight: 10,
                MessagePattern: new Regex("(course name is|course is) (now )?(.*)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    session.SessionStorage.Values["CourseName"] = match.Groups[3].Value;
                    return "Course name now is " + session.SessionStorage.Values["CourseName"];
                }
            ),

            new BotRule(
                Name: "getcoursename",
                Weight: 10,
                MessagePattern: new Regex("(what course name|(what is|say) course name)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    if (!session.SessionStorage.Values.ContainsKey("CourseName"))
                    {
                        return "I do not know course name";
                    }
                    if (match.Value.ToLower() == "what course")
                    {
                        return "course is " + session.SessionStorage.Values["CourseName"];
                    }
                    return "Youre in " + session.SessionStorage.Values["CourseName"];
                }
            ),
        };
    }
}
