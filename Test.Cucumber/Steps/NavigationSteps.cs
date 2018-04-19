using NFluent;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace Test.Cucumber.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private IWebDriver webDriver;

        [BeforeScenario]
        public void InitScenario()
        {
            webDriver = new FirefoxDriver();
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            webDriver.Dispose();
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
        }
        
        [When(@"I click on a button in navigation bar")]
        public void WhenIClickOnAInNavigationBar()
        {
            webDriver.FindElement(By.ClassName("loginForm")).FindElement(By.TagName("a")).Click();
        }
        
        [Then(@"I should land on dashboard page")]
        public void ThenIShouldLandOnPage()
        {
            var title = webDriver.Url;
            Check.That(title).Equals("http://localhost:3000/dashboard");

        }
    }
}
