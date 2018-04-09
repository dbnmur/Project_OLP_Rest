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
    }
}
