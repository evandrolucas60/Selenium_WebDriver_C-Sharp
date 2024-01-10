using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.Reflection;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driver = GetChromeDrive();

            //Go here first
            driver.Navigate().GoToUrl("https://ultimateqa.com");
            //Assert  page title equals - 'Homepage - Ultimate QA'
            Assert.AreEqual("Homepage - Ultimate QA", driver.Title);

            //Now Go here
            driver.Navigate().GoToUrl("https://ultimateqa.com/automation");
            //Assert  page title equals - 'Automation Practice - Ultimate QA'
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);

            //Click on link with href - complicated-page
            driver.FindElement(By.XPath("//*[@id=\"post-507\"]/div/div[1]/div/div[2]/div/div[1]/div/div/div/div/ul/li[1]/a")).Click();
            //Assert  page title equals - 'Automation Practice - Ultimate QA'
            Assert.AreEqual("Complicated Page - Ultimate QA", driver.Title);

            //Go Back
            driver.Navigate().Back();
            //Assert  page title equals - 'Automation Practice - Ultimate QA'
            Assert.AreEqual("Automation Practice - Ultimate QA", driver.Title);

            driver.Quit();

        }

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}