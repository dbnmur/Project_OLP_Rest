using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using QXS.ChatBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OLP_Rest.Test.Tests.Serialization
{
    [TestClass]
    public class SessionStorageTest
    {
        [TestMethod]
        public void SerializeSessionStorageValuesPropertyTest()
        {
            SessionStorage sessionStorage = new SessionStorage();
            sessionStorage.Values["TestKey"] = "Test message";
            sessionStorage.Values["TestKey2"] = "Test message2";

            Assert.AreEqual("Test message", sessionStorage.Values["TestKey"]);

            string json = JsonConvert.SerializeObject(sessionStorage.Values);
            Assert.AreEqual(json, "{\"TestKey\":\"Test message\",\"TestKey2\":\"Test message2\"}");
        }
    }
}
