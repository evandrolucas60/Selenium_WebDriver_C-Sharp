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
        public void DragDropExemple1()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            _actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
        }

        [Test]
        public void DragDropExemple2()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));

            var drag = _actions
                .ClickAndHold(sourceElement)
                .MoveToElement(targetElement)
                .Release(targetElement)
                .Build();

            drag.Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);
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