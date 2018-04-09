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
                        "Dependency Heaven\n");

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
                            "Dependency Heaven\n");

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }

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
                    "Read more here: http://php.net/manual/en/language.basic-syntax.phptags.php The second line is the instruction to print out some text.");

            Console.WriteLine(PHPChatBot.FindAnswer(session, Message));
        }
    }
}
