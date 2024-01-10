using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Driver Interrogation")]
        public void TestMethod1()
        {
            var driver = GetChromeDrive();

            driver.Navigate().GoToUrl("https://ultimateqa.com/automation");
            var myElement = driver.FindElement(By.XPath("//*[@href='http://courses.ultimateqa.com/users/sign_in']"));

            driver.Quit();
        }

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}