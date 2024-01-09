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
            //Ok, last one! Let’s go back to our table with unique id and check that the last row of the table content information for “Quality Assurance Engineer”. Assume the table may be updated at any time, but this title should always be displayed on the last row (which won’t always be row #3).

            var driver = GetChromeDrive();
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");

            Assert.IsTrue(driver.FindElement(By.XPath("//table[@id='htmlTableId']//tr[last()]/td[1]")).Text.Equals("Quality Assurance Engineer"));

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