using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using ExpectedCondition = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IWebDriver _driver = GetChromeDrive();
        
        [TestMethod]
        [TestCategory("Explicit waits")]
        public void ExplicitWait1()
        {
            //Implicit Waits

            //What's it?
            //This is the code that you write to wait for a certain condition
            //to occur before proceeding

            //Usage
            //

            //Default timeout
            //*0.5 seconds

            //Disadvantages
            //*Should be used for all slow loading elements

            //When to use?
            //For all slow loading elements that need a synchronization point


            Thread.Sleep(1000);
            

            _driver.Quit();
        }

        [TestMethod]
        public void ExplicitWait2()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement element = wait.Until((d)  =>
            {
                return d.FindElement(By.Id("seccess"));
            });

            _driver.Quit();
        }

        [TestMethod]
        public void Test1_FixedExplicitly()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/1");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedCondition.ElementToBeClickable(By.Id("go"))).Click();
            Assert.IsTrue(wait.Until(ExpectedCondition.ElementIsVisible(By.Id("success"))).Displayed);

            _driver.Quit();
        }

        private static IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}