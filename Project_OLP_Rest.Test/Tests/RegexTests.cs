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
    public class RegexTests
    {
        
        private List<BotRule> GreetingBotRules = GreetingsRules.rules;
        private List<BotRule> GoodByeBotRules = GoodbyeRules.rules;
        private List<BotRule> ErrorBotRules = ErrorRules.rules;



        private RestChatBot chatBot;

        
        [TestMethod]
        public void BotGreetCMD_Test()
        {
            chatBot = new RestChatBot(GreetingBotRules);
            string Message = "hi";
            
            ChatSessionInterface session = new RestChatSession();
            string answer = chatBot.FindAnswer(session, Message);
           
            Assert.AreEqual(answer,"Hi!");

            //#2
            Message = "hello";

            session = new RestChatSession();
            answer = chatBot.FindAnswer(session, Message);

            Assert.AreEqual(answer, "Hi!");
            //#3
            Message = "labas";

            session = new RestChatSession();
            answer = chatBot.FindAnswer(session, Message);

            Assert.AreEqual(answer, "Hi!");
            //#4
            Message = "sveikas";

            session = new RestChatSession();
            answer = chatBot.FindAnswer(session, Message);

            Assert.AreEqual(answer, "Hi!");
            //#5
            Message = "jfdbkfdkjldf";

            session = new RestChatSession();
            answer = chatBot.FindAnswer(session, Message);

            Assert.AreEqual(answer, "sorry what ?");

        }

        [TestMethod]
        public void BotGoodByeCMD_Test()
        {
            chatBot = new RestChatBot(GoodByeBotRules);
            string Message = "ate";

            ChatSessionInterface session = new RestChatSession();
            string answer = chatBot.FindAnswer(session, Message);

            Assert.AreEqual(answer, "bye bye");

        }

        [TestMethod]
        public void BotErrorCMD_Test()
        {
            chatBot = new RestChatBot(ErrorBotRules);
            string Message = "I have exception";

            ChatSessionInterface session = new RestChatSession();
            string answer = chatBot.FindAnswer(session, Message);

            Assert.AreEqual(answer, "Whats the problem ?");
        }

    }
}
