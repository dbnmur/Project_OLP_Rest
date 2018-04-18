using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ChatBot.Rest;
using ChatBot.Rest.ChatSessions;
using ChatBot.Rest.RuleSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QXS.ChatBot;
using QXS.ChatBot.ChatSessions;

namespace Project_OLP_Rest.Test.Tests
{
    [TestClass]
    public class RegexTests
    {
        private IEnumerable<BotRule> _greetingBotRules;
        private IEnumerable<BotRule> _goodByeBotRules;
        private IEnumerable<BotRule> _errorBotRules;
        private IEnumerable<BotRule> _jokeBotRules;

        private RestChatBot chatBot;

        public RegexTests()
        {
            _greetingBotRules = new GreetingsRuleSet().Rules;
            _goodByeBotRules = new GoodbyeRuleSet().Rules;
            _errorBotRules = new ErrorRuleSet().Rules;
            _jokeBotRules = new JokeRuleSet().Rules;
        }

        [TestMethod]
        public void BotTest_Greeting()
        {
            chatBot = new RestChatBot(_greetingBotRules);
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
        public void BotTest_Goodbye()
        {
            chatBot = new RestChatBot(_goodByeBotRules);
            string Message = "ate";

            ChatSessionInterface session = new RestChatSession();
            string answer = chatBot.FindAnswer(session, Message);

            Assert.AreEqual(answer, "bye bye");

        }

        [TestMethod]
        public void BotTest_HaveError()
        {
            chatBot = new RestChatBot(_errorBotRules);
            string Message = "I have exception";
            ChatSessionInterface session = new RestChatSession();
            string answer = chatBot.FindAnswer(session, Message);
            Assert.AreEqual(answer, "Whats the problem ?");
        }

        [TestMethod]
        public void BotTest_FindSolutionForError()
        {
            chatBot = new RestChatBot(_errorBotRules);
            string Message = "find the solution to this error";
            ChatSessionInterface session = new RestChatSession();
            string answer = chatBot.FindAnswer(session, Message);
            Assert.AreEqual(answer, "try this.  google.com");
        }

        [TestMethod]
        public void BotTest_GetJoke()
        {
            chatBot = new RestChatBot(_jokeBotRules);
            string Message = "tell me a joke";
            List<string> jokes = JokeRuleSet.jokeList;
            ChatSessionInterface session = new RestChatSession();
            string answer = chatBot.FindAnswer(session, Message);
            Console.WriteLine(answer);
            Assert.IsTrue(jokes.Contains(answer));
        }
    }
}
