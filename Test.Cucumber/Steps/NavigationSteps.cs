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
            webDriver.Navigate().GoToUrl("");
        }
        
        [When(@"I click on a '(.*)' in navigation bar")]
        public void WhenIClickOnAInNavigationBar(string p0)
        {
            webDriver.FindElement(By.LinkText("Content"));
        }
        
        [Then(@"I should land on '(.*)' page")]
        public void ThenIShouldLandOnPage(string p0)
        {
            var title = webDriver.Title;
            Check.That(title).Equals("");

        }
    }
}
