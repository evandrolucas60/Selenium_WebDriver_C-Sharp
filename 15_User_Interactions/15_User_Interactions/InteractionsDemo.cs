using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Reflection;

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
        }

        private static IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}