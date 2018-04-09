using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QXS.ChatBot;
using QXS.ChatBot.ChatSessions;
using QXS.ChatBot.Rules;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class PHPCourseRegexTest
    {
        private RestChatBot PHPChatBot;

        PHPCourseRule phpCourseRule = new PHPCourseRule();

        [TestMethod]
        public void CreatePHPBot() => PHPChatBot = new RestChatBot(phpCourseRule.CourseRule);

        [TestMethod]
        public void PHPCourseNameTest()
        {
            CreatePHPBot();
            string Message = "What course name";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "I do not know course name");

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }
        
        [TestMethod]
        public void PHPgetExercisesListTest()
        {
            CreatePHPBot();
            string Message = "show excersices";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "PHP EXCERCISES: \n" + "-------------------\n" + "Hello World\n" + "Baby Steps\n" +
                    "My First IO\n" + "Filtered LS\n" + "Concerned about Separation?\n" + "Array We Go!\n" +
                    "Exceptional Coding\n" + "Database Read\n" + "Time server\n" + "HTTP JSON API\n" +
                    "Dependency Heaven\n"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetExercisesListWithTeachMePHPMessageTest()
        {
            CreatePHPBot();
            string Message = "teach me php";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "Choose excersise from list bellow\n\n" +
                    "PHP EXCERCISES: \n" + "-------------------\n" + "Hello World\n" + "Baby Steps\n" +
                    "My First IO\n" + "Filtered LS\n" + "Concerned about Separation?\n" + "Array We Go!\n" +
                    "Exceptional Coding\n" + "Database Read\n" + "Time server\n" + "HTTP JSON API\n" +
                    "Dependency Heaven\n"
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // Hello World

        [TestMethod]
        public void PHPgetHelloWorldTask()
        {
            CreatePHPBot();
            string Message = "give me hello world task";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                "Write a program that prints the text \"Hello World\" to the console (stdout).");

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetHelloWorldTaskHint()
        {
            CreatePHPBot();
            string Message = "hw hint";
            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "To make a PHP program, create a new file with a .php extension and start writing PHP! " +
                    "Execute your program by running it with the php command. e.g.:\n" +
                    "\n$ php program.php\n\n" +
                    "You can write to the console from a PHP program with the following code" +
                    "\n\n<?php \n echo \"text\"\n" +
                    "\n The first line tells the PHP to interpret the code following it. It is required before any PHP code is written." +
                    "Read more here: http://php.net/manual/en/language.basic-syntax.phptags.php The second line is the instruction to print out some text."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        //Baby-Steps

        [TestMethod]
        public void PHPgetBabyStepsTask()
        {
            CreatePHPBot();
            string Message = "give me baby steps task";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write a program that accepts one or more numbers as command-line arguments " +
                    "and prints the sum of those numbers to the console (stdout)."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetBabyStepsTaskHint()
        {
            CreatePHPBot();
            string Message = "bs hint";
            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "You can access command-line arguments via the global $argv array.\n" +
                    "To get started, write a program that simply contains:\n" +
                    "\nvar_dump($argv);\n\n" +
                    "Run it with php program.php and some numbers as arguments. e.g:\n\n" +
                    "$ php program.php 1 2 3\n\n" +
                    "You'll need to think about how to loop through the number of arguments so you can output just their sum. " +
                    "The first element of the $argv array is always the name of your script. eg program.php, " +
                    "so you need to start at the 2nd element (index 1), adding each item to the total until you reach the end of the array."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        // My First IO

        [TestMethod]
        public void PHPgetMyFirstIOTask()
        {
            CreatePHPBot();
            string Message = "my-first-io";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message),
                    "Write a program that uses a single filesystem operation to read a file and print the number of newlines (\\n) " +
                    "it contains to the console (stdout), similar to running cat file | wc -l.\n" +
                    "The full path to the file to read will be provided as the first command-line argument. You do not need to make your own test file."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

        [TestMethod]
        public void PHPgetMyFirstiIOTaskHint()
        {
            CreatePHPBot();
            string Message = "mfio hint";
            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(PHPChatBot.FindAnswer(session, Message), "HINTS:\n" +
                    "To perform a filesystem operation you can use the global PHP functions.\n\n" +
                    "To read a file, you'll need to use file_get_contents('/path/to/file'). This method will return" +
                    " a string containing the complete contents of the file.\n\n" +
                    "Documentation on the file_get_contents function can be found by pointing your browser " +
                    "here: http://php.net/manual/en/function.file-get-contents.php \n\n" +
                    "If you're looking for an easy way to count the number of newlines in a string, recall the PHP " +
                    "function substr_count can be used to count the number of substring occurrences."
                );

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }
    }
}
