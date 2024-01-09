using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.ComponentModel;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Write a test that navigates to the URL and asserts that the second element with the text '$120,000+' is displayed.Here the easy XPath //td[text()='$120,000+'] will return 2 elements, so we can’t rely on it.

            var driver = GetChromeDrive();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");

            Assert.IsTrue(driver.FindElement(By.XPath("//h2[contains(text(), 'no id')]/following-sibling::table//td[contains(text(),'$120,000+')]")).Displayed);

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