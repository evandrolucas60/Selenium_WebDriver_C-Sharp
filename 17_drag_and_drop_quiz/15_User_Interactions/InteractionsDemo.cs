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
        public void DragDropQuiz()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/drag_and_drop");
            _driver.Manage().Window.Maximize();
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("content")));

            IWebElement sourceElement = _driver.FindElement(By.Id("column-a"));
            IWebElement targetElement = _driver.FindElement(By.Id("column-b"));

            
            if (_driver.FindElement(By.XPath("//*[@id=\"column-a\"]/header")).Text.Equals("A"))
            {
                _actions.DragAndDrop(sourceElement, targetElement).Perform();
                Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id=\"column-a\"]/header")).Text.Equals("B"));   
            }
            else
            {
                _actions.DragAndDrop(sourceElement, targetElement).Perform();
                Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id=\"column-a\"]/header")).Text.Equals("A"));
            }
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

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}