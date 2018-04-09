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
    public class JavaCourseRegexTest
    {
       
        private RestChatBot javaChatBot;
        JavaCourseRules javaCourseRules = new JavaCourseRules();

        [TestMethod]
        public void CreateJavaBot() => javaChatBot = new RestChatBot(javaCourseRules.createJavaCourseRules);


        [TestMethod]
        public void JavaCourseAskTest()
        {
            CreateJavaBot();
            string Message = "What course name";

            ChatSessionInterface session = new RestChatSession();
            Assert.AreEqual(javaChatBot.FindAnswer(session, Message), "I do not know course name");

            Console.WriteLine(javaChatBot.FindAnswer(session, Message));

        }
    }
}
