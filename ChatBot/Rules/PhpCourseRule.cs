using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QXS.ChatBot.Rules
{
    public class PHPCourseRule
    {
        public List<BotRule> CourseRule = new List<BotRule>()
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
                    return "You are in " + session.SessionStorage.Values["CourseName"];
                }
            ),

            new BotRule(
                Name: "showexcersices",
                Weight: 10,
                MessagePattern: new Regex("(show excersices|(teach me|give me tasks) php)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    if (match.Value.ToLower() == "teach me php")
                        {
                            return "Choose excersise from list bellow\n\n" +
                            "PHP EXCERCISES: \n" + "-------------------\n" + "Hello World\n" + "Baby Steps\n" +
                            "My First IO\n" + "Filtered LS\n" + "Concerned about Separation?\n" + "Array We Go!\n" +
                            "Exceptional Coding\n" + "Database Read\n" + "Time server\n" + "HTTP JSON API\n" +
                            "Dependency Heaven\n";
                        }
                    return "PHP EXCERCISES: \n" + "-------------------\n" + "Hello World\n" + "Baby Steps\n" +
                        "My First IO\n" + "Filtered LS\n" + "Concerned about Separation?\n" + "Array We Go!\n" +
                        "Exceptional Coding\n" + "Database Read\n" + "Time server\n" + "HTTP JSON API\n" +
                        "Dependency Heaven\n";
                }
            ),

            new BotRule(
                Name: "selecthelloworldexcersice",
                Weight: 10,
                MessagePattern: new Regex("(hello world|(give me hello world|hw) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Write a program that prints the text \"Hello World\" to the console (stdout).";
                }
            ),

            new BotRule(
                Name: "selecthelloworldexcersicehint",
                Weight: 10,
                MessagePattern: new Regex("(hello world hint|(give me hello world|hw) hint)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "HINTS:\n" +
                    "To make a PHP program, create a new file with a .php extension and start writing PHP! " +
                    "Execute your program by running it with the php command. e.g.:\n" +
                    "\n$ php program.php\n\n" +
                    "You can write to the console from a PHP program with the following code" +
                    "\n\n<?php \n echo \"text\"\n" +
                    "\n The first line tells the PHP to interpret the code following it. It is required before any PHP code is written." +
                    "Read more here: http://php.net/manual/en/language.basic-syntax.phptags.php The second line is the instruction to print out some text.";
                }
            ),
        };
    }
}
