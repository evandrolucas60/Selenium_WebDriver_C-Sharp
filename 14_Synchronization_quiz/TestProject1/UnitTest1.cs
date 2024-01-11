using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using ExpectedCondition = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IWebDriver _driver = GetChromeDrive();
        
        [TestMethod]
        [TestCategory("Explicit waits")]
        public void ExplicitWait1()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com");
            _driver.Manage().Window.Maximize();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var firstSyncElement = By.XPath("//*[@id=\"post-217913\"]/div/div[1]/div/div[1]/div[1]/div[2]/div/span/img");

            wait.Until(ExpectedCondition.ElementIsVisible(firstSyncElement));

            wait.Until(ExpectedCondition.ElementToBeClickable(By.XPath("//*[@id=\"menu-item-218225\"]/a"))).Click();

            wait.Until(ExpectedCondition.ElementToBeClickable(By.LinkText("Automation Exercises"))).Click();

            wait.Until(ExpectedCondition.ElementIsVisible(By.XPath("//span[text()='Automation Practice']")));
            _driver.FindElement(By.LinkText("Big page with many elements")).Click();

            var finalElement = wait.Until(ExpectedCondition.ElementIsVisible(By.XPath("//*[@title='footer-logo']")));
            Assert.IsTrue(finalElement.Displayed);
            _driver.Quit();
        }

        private static IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}