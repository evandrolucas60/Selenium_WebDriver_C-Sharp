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
        private readonly IWebDriver _driver = GetChromeDrive();
        [Test]
        public void Exemple1()
        {
            var actions = new Actions(_driver);
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(6));

            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            actions.DragAndDrop(sourceElement, targetElement).Perform();

            Assert.AreEqual("Dropped!", targetElement.Text);       
                
            _driver.Quit();
        }

        private static IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}