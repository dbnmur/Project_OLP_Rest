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
        GreetingsRules greetingsRules = new GreetingsRules();
        private List<BotRule> botRules = GreetingsRules.rules; 

        private RestChatBot chatBot;

        [TestMethod]
        public void CreateBot() => chatBot = new RestChatBot(botRules);

        [TestMethod]
        public void BotGreetCMD_Test()
        {
            CreateBot();
            string Message = "hi";
            
            ChatSessionInterface session = new RestChatSession();
            string answer = chatBot.FindAnswer(session, Message);
           
            Assert.AreEqual(answer,"Hi!");
            
        }
        

    }
}
