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
            //In this test, we want to make sure that the text above the Click Me!Button contains “Feel free to practice your test automation on these elements”.

            var driver = GetChromeDrive();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");

            Assert.IsTrue(driver.FindElement(By.XPath("//button[text()='Click Me!']/ancestor::form/preceding-sibling::h3")).Text.Contains("Feel free to practice your test automation on these elements"));

            //to close webdrive
            driver.Quit();
        }

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}