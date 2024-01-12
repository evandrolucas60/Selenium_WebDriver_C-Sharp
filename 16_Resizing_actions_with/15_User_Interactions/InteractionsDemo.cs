using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace _15_User_Interactions
{
    [TestFixture]
    public class InteractionsDemo
    {
        private IWebDriver _driver;
        private Actions _actions;
        private WebDriverWait _wait;

        [Test]
        public void DragDropExemple2()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
            _driver.Manage().Window.Maximize();
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement resizeHandle = _driver.FindElement(By.XPath("//*[@class=\"ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se\"]"));

            _actions.ClickAndHold(resizeHandle).MoveByOffset(100, 100).Perform();
            Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id='resizable' and @style]")).Displayed);   
        }

        [SetUp]
        public void Setup()
        {
            _driver = GetChromeDrive();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(6));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();

        }


        private static IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}