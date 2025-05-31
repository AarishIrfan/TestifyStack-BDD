using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace TestifyStack_BDD
{
    [Binding]
    public class LoginStepDefinitions
    {
        private static IWebDriver driver;

        [Given(@"I am on the TestifyStack login page")]
        public void GivenIAmOnTheTestifyStackLoginPage()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://practice.expandtesting.com/login");
        }

        [When(@"I enter the following credentials:")]
        public void WhenIEnterTheFollowingCredentials(Table table)
        {
            var username = table.Rows[0]["username"];
            var password = table.Rows[0]["password"];

            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(username);

            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var loginButton = wait.Until(d =>
            {
                var button = d.FindElement(By.CssSelector("#login > button"));
                return (button.Displayed && button.Enabled) ? button : null;
            });

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", loginButton);
            System.Threading.Thread.Sleep(500);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", loginButton);
        }

        [Then(@"I should be redirected to the secure area")]
        public void ThenIShouldBeRedirectedToTheSecureArea()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            bool urlContainsSecure = wait.Until(d => d.Url.Contains("secure"));
            Assert.IsTrue(urlContainsSecure, $"URL does not contain 'secure'. Actual URL: {driver.Url}");
        }

        [Then(@"I should see a welcome message confirming successful login")]
        public void ThenIShouldSeeAWelcomeMessageConfirmingSuccessfulLogin()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            try
            {
                // Try multiple possible selectors for the success message
                IWebElement alert = null;

                // First try the common flash message selectors
                var selectors = new string[]
                {
                    ".flash.success",
                    ".flash",
                    ".alert.success",
                    ".alert-success",
                    ".alert",
                    "[role='alert']",
                    ".message.success",
                    ".success-message"
                };

                foreach (var selector in selectors)
                {
                    try
                    {
                        alert = wait.Until(d => d.FindElement(By.CssSelector(selector)));
                        if (alert != null && alert.Displayed)
                        {
                            Console.WriteLine($"Success message found with selector: {selector}");
                            Console.WriteLine($"Message text: {alert.Text}");
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        // Continue to next selector
                        continue;
                    }
                }

                // If no element found with CSS selectors, try XPath
                if (alert == null)
                {
                    try
                    {
                        alert = wait.Until(d => d.FindElement(By.XPath("//*[contains(text(), 'logged') or contains(text(), 'success') or contains(text(), 'welcome')]")));
                        Console.WriteLine($"Success message found with XPath");
                        Console.WriteLine($"Message text: {alert.Text}");
                    }
                    catch (Exception)
                    {
                        // Log page source for debugging
                        Console.WriteLine("Page source:");
                        Console.WriteLine(driver.PageSource);
                    }
                }

                Assert.IsNotNull(alert, "Success message element not found on the page");

                // Check if message contains expected text (case insensitive)
                string messageText = alert.Text.ToLower();
                bool containsSuccessMessage = messageText.Contains("logged") ||
                                            messageText.Contains("success") ||
                                            messageText.Contains("welcome") ||
                                            messageText.Contains("secure");

                Assert.IsTrue(containsSuccessMessage,
                    $"Expected success message not found. Actual message: '{alert.Text}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding success message: {ex.Message}");
                Console.WriteLine($"Current URL: {driver.Url}");
                Console.WriteLine($"Page title: {driver.Title}");
                throw;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}