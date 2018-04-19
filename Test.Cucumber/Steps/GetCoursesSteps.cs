using NFluent;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace Test.Cucumber
{
    [Binding]
    public class GetCoursesSteps
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

        [Given(@"Im on home page")]
        public void GivenImOnHomePage()
        {
            webDriver.Navigate().GoToUrl("http://localhost:3000/");
        }
        
        [When(@"I have pressed login button")]
        public void WhenIHavePressedLoginButton()
        {
            webDriver.FindElement(By.ClassName("loginForm")).FindElement(By.TagName("a")).Click();
        }
        
        [Then(@"The result should display all courses")]
        public void ThenTheResultShouldDisplayAllCourses()
        {
            var title = webDriver.Url;
            Check.That(title).Equals("http://localhost:3000/dashboard");
        }
        
        [Then(@"I press desired course")]
        public void ThenIPressDesiredCourse()
        {
            webDriver.FindElement(By.ClassName("MuiGrid-typeItem-118")).FindElement(By.TagName("a")).Click();
        }
        
        [Then(@"I get a course page")]
        public void ThenIGetACoursePage()
        {
            var title = webDriver.Url;
            Check.That(title).Equals("http://localhost:3000/courses/1");
        }
    }
}
