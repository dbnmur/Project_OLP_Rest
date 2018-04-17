using QXS.ChatBot.RulesSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.RuleSet
{
    public class JavaCourseRules : IRuleSet
    {
        public IEnumerable<BotRule> Rules { get { return _createJavaCourseRules; } }

        private IEnumerable<BotRule> _createJavaCourseRules = new List<BotRule>()
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
                MessagePattern: new Regex("(show me java|( tasks|exercises) )", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Java Courses: \n" + "-------------------\n" + "1.Knowing Java\n" + "2.Classes\n" +
                        "3.Pro tips Java\n" + "4.Collections and Generics\n" + "5.Reflection & Persistence\n" + "6.Threads\n";
                }
            ),

                 new BotRule(
                    Name: "getcoursename",
                    Weight: 15,
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
                    MessagePattern: new Regex("(suggest me java|( learning sites|studies sites) )", RegexOptions.IgnoreCase),
                    Process: delegate(Match match, ChatSessionInterface session)
                    {
                        return "Pluralsight \n Udemy \n CodeAcademy ....";
                    }
                    ),
                new BotRule(
                    Name: "",
                    Weight:10 ,
                    MessagePattern: new Regex("", RegexOptions.IgnoreCase),
                    Process: delegate(Match match, ChatSessionInterface session)
                    {
                        return"";
                    }
                    ),
                 new RandomAnswersBotRule(
                       "javafact", 10, new Regex("tell|show|(me|(interesting fact| fact)|about java)tell|show|(me|(interesting fact| fact)|about java)",
                           RegexOptions.IgnoreCase),

                       new string[] {
                           "Java was called Oak at the beginning \n" +
                           "Original name for Java was Oak. Java legend has it that a big oak tree that grew outside the developer James Gosling’s window. It was eventually changed to Java by Sun’s marketing department when Sun lawyers found that there was already a computer company registered as Oak.",
                           "Java was invented by accident\n" +
                           "James Gosling was working at Sun Labs, around 1992. Gosling and his team was building a set-top box and started by “cleaning up” C++ and wound up with a new language and runtime. Thus Java or Oak came into being",
                           "Its pays to learn Java \n" +
                           "The median salary of a Java developer is $83,975.00. Yes, it pays to be a Java developer and programmers are milking it. There are about 9 million Java developers in the world.",
                           "Java is second most popular language after C \n" +
                           "Though many would argue that Java is all time favourite among developers, it is second most popular programming language after C. Java is ranked #2 in popularity among programming languages, according to the programming languages popularity tracking website, tiobe.com",
                           "JUnit Testing Framework\n" +
                           "The JUnit Testing Framework is currently the top used Java technology. Its stability and popularity can be deduced from the fact that almost 4 out of 5 Java developers or 70 % developers out there used JUnit Testing Framework.",
                           "Java is the go to tool for enterprises\n" +
                           "95 percent of enterprises use Java for programming. That is hell lot more than C and other languages put together.",
                           "Current Java version\n" +
                           "Java’s latest major release is the Platform Standard Edition 8. Its features include improved developer productivity and app performance through reduced boilerplate code, improved collections and annotations.",
                           "The Duke\n" +
                           "The Java mascot, ‘The Duke’ was created by Joe Palrang. Palrang is the same guy who has worked on the Hollywood blockbuster, Shrek.",
                           "Java and Android\n" +
                           "Java practically runs on 1billion plus smartphones today because Google’s Android operating system uses Java APIs.",
                           "Final is not final in Java\n" +
                           "Final actually has four different meanings in Java.\n"+
                           "1) final class- The class cannot be extended"+
                           "2) Final method- the method cannot be overridden"+
                           "3) final field- The field is a constant"+
                           "4)final variable- the value of the variable cannot be changed once assigned"
                       }
                       ),




            };

    }
}

