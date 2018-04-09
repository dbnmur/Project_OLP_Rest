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
            // Hello World
            new BotRule(
                Name: "selecthelloworldexcersice",
                Weight: 10,
                MessagePattern: new Regex("(hello world|(give me hello world|hw) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Write a program that prints the text \"Hello World\" to the console (stdout).";
                }
            ),

            new BotRule(
                Name: "helloworldexcersicehint",
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
            //Baby-Steps 
                new BotRule(
                Name: "selectbabystepsexcersice",
                Weight: 10,
                MessagePattern: new Regex("(baby-steps|baby steps|(give me baby steps|bs|give me baby-steps) task)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "Write a program that accepts one or more numbers as command-line arguments " +
                    "and prints the sum of those numbers to the console (stdout).";
                }
            ),

            new BotRule(
                Name: "babystepsexcersicehint",
                Weight: 10,
                MessagePattern: new Regex("(baby-steps hint|baby steps hint|(give me baby steps|bs|give me baby-steps) hint)", RegexOptions.IgnoreCase),
                Process: delegate(Match match, ChatSessionInterface session) {
                    return "HINTS:\n" +
                    "You can access command-line arguments via the global $argv array.\n" +
                    "To get started, write a program that simply contains:\n" +
                    "\nvar_dump($argv);\n\n" +
                    "Run it with php program.php and some numbers as arguments. e.g:\n\n" +
                    "$ php program.php 1 2 3\n\n" +
                    "You'll need to think about how to loop through the number of arguments so you can output just their sum. " +
                    "The first element of the $argv array is always the name of your script. eg program.php, " +
                    "so you need to start at the 2nd element (index 1), adding each item to the total until you reach the end of the array.";
                }
            ),
            //
        };
    }
}
