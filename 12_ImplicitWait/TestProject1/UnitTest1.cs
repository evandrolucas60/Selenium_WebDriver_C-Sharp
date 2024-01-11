using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IWebDriver _driver = GetChromeDrive();
        
        [TestMethod]
        [TestCategory("Implicit waits")]
        public void TestMethod1()
        {
            //Implicit Waits

            //What's it?
            //Tells Webdriver to poll the DOM for a certain amount of time when trying
            //to find an element or elements if they are not immediately available

            //Usage
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Default timeout
            //0 seconds

            //Disadvantages
            //*Unless if the element is hidden on the page
            //*Applies to all future commands


            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            FillOutLoginInfo();
            

            _driver.Quit();
        }

        private void FillOutLoginInfo()
        {
            _driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
            _driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
            _driver.FindElement(By.Id("login-button")).Submit();
        }

        private static IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}