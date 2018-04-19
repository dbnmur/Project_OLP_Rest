using NFluent;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;

namespace Test.Cucumber
{
    [Binding]
    public class AddRecordSteps
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

        [Given(@"Im on the course page")]
        public void GivenImOnTheCoursePage()
        {
            webDriver.Navigate().GoToUrl("http://localhost:3000/courses/1");
        }
        
        [Then(@"I press plus button")]
        public void ThenIPressPlusButton()
        {
           // webDriver.FindElement(By.ClassName("MuiExpansionPanelDetails-root-678")).FindElement().Click();
        }
        
        [Then(@"I enter name")]
        public void ThenIEnterName()
        {
            
            webDriver.FindElement(By.Id("title")).GetAttribute("value");
            
        }

        [Then(@"I enter description")]
        public void ThenIEnterDescription()
        {
            webDriver.FindElement(By.ClassName("MuiInput-input-1076 MuiInput-inputMultiline-1079 MuiInput-inputMarginDense-1077")).GetAttribute("value");
        }
        
        [Then(@"I press add")]
        public void ThenIPressAdd()
        {
            webDriver.FindElement(By.ClassName("MuiButtonBase-root-49 MuiButton-root-102 MuiButton-flatPrimary-104 MuiDialogActions-action-1430")).Click();

        }

        [Then(@"I should see new record")]
        public void ThenIShouldSeeNewRecord()
        {
            bool exists = false;
            if(webDriver.FindElement(By.ClassName("MuiTypography-root-78 MuiTypography-body1-87")).FindElement(By.LinkText("value")) != null)
            {
                exists = true;
            }
            Check.That(exists).Equals(true);
        }
    }
}
