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
                MessagePattern: new Regex("(show me |( tasks|exercises) java)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Java Courses: \n" + "-------------------\n" + "1.Knowing Java\n" + "2.Classes\n" +
                        "3.Pro tips Java\n" + "4.Collections and Generics\n" + "5.Reflection & Persistence\n" + "6.Threads\n";
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
                       
                       new string[] {"Check 1.Knowing Java",
                           "Check 1.Knowing Java",
                           "Check 2.Classe",
                           "Check 3.Pro tips Java",
                           "Check 4.Collections and Generics",
                           "Check 5.Reflection & Persistence",
                           "Check 6.Threads"
                       }
                       ),

                new BotRule(
                    Name: "learningmaterial",
                    Weight: 10,
                    MessagePattern: new Regex("where(can i|should i)|learn ", RegexOptions.IgnoreCase),
                    Process: delegate(Match match, ChatSessionInterface session)
                    {
                        return "Pluralsight \n Udemy \n CodeAcademy";
                    }
                    ),




            };
    }
}

