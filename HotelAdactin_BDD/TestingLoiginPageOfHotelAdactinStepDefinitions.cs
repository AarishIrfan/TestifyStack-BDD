using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;

namespace HotelAdactin_BDD
{
    [Binding]
    public class TestingLoiginPageOfHotelAdactinStepDefinitions
    {
        public static IWebDriver driver;
        [Given(@"I am on Url of HotelAdaction working and on login page")]
        public void GivenIAmOnUrlOfHotelAdactionWorkingAndOnLoginPage()
        {
            driver = new EdgeDriver();
            driver.Url = "https://adactinhotelapp.com/";
        }

        [When(@"I am typing valid username and password")]
        public void WhenIAmTypingValidUsernameAndPassword(Table table)
        {
            driver.FindElement(By.Id("username")).SendKeys("AmirImam");
            driver.FindElement(By.Id("password")).SendKeys("AmirImam");
            driver.FindElement(By.Id("login")).Click();

        }

        [Then(@"Website will go to search page")]
        public void ThenWebsiteWillGoToSearchPage()
        {
            driver.Close();
            throw new PendingStepException();
        }
    }
}
