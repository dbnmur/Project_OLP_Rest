using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.Rules
{
    public class JavaCourseRules
    {
        public List<BotRule> createJavaCourseRules = new List<BotRule>()
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
                Name: "showexcersices",
                Weight: 10,
                MessagePattern: new Regex("(show excersices|(show me|give me tasks) java)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Java Courses: \n" + "-------------------\n" + "1. Knowing Java\n" + "Classes\n" +
                        "2.Pro tips Java\n" + "3.Collections and Generics\n" + "Reflection & Persistence\n" + "Threads\n";
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
                            return "Course is " + session.SessionStorage.Values["CourseName"];
                        }
                        return "Youre in " + session.SessionStorage.Values["CourseName"];
                    }
                ),
                   new RandomAnswersBotRule(
                       "gettask", 40, new Regex("give (me task|task)",
                           RegexOptions.IgnoreCase),
                       
                       new string[] {"your task is begginer",
                           "your task is intermediate",
                           "your task is easy" }
                       ),
                //new BotRule(
                //    Name: "bestframeworks",
                //    Weight: 10,
                //    MessagePattern: new Regex("tell(me|)")


                    

            };
    }
}

