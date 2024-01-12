using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
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
            _driver.Navigate().GoToUrl("https://testpages.eviltester.com/styled/gui-scribble.html");
            _driver.Manage().Window.Maximize();

            IWebElement canvas = _driver.FindElement(By.Id("canvas"));
            Debug.WriteLine($"canvas x:{canvas.Location.X}");
            Debug.WriteLine($"canvas y:{canvas.Location.Y}");

            var eventList = _driver.FindElement(By.Id("draweventslist"));

            var li = eventList.FindElements(By.TagName("li"));
            var eventCount = li.Count;

            for (int i = 0; i < 100; i++)
            {
                Random rnd = new Random(i);
                var rnd2 = new Random(i +3);

                var x = rnd2.Next(1, 100);
                var y = rnd.Next(1, 100);

                Debug.WriteLine($"rnd:{canvas.Location.X - x}");
                Debug.WriteLine($"rnd2:{canvas.Location.Y - y}");

                _actions.DragAndDropToOffset(canvas, canvas.Location.X - x, canvas.Location.Y - y).Perform();
            }

            Assert.IsTrue(eventCount < eventList.FindElements(By.TagName("li")).Count);
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