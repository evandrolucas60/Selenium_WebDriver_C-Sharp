using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var driver = GetChromeDrive();
            driver.Navigate().GoToUrl("https://www.techlistic.com/p/selenium-practice-form.html");

            driver.FindElement(By.XPath("//*[@id='post-body-3077692503353518311']/div[1]/div/div/h2[2]/div[1]/div/div[2]/input")).Click();
            driver.FindElement(By.XPath("//*[@id='post-body-3077692503353518311']/div[1]/div/div/h2[2]/div[1]/div/div[2]/input")).SendKeys("Evandro");

            driver.FindElement(By.XPath("//*[@id=\"post-body-3077692503353518311\"]/div[1]/div/div/h2[2]/div[1]/div/div[5]/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"post-body-3077692503353518311\"]/div[1]/div/div/h2[2]/div[1]/div/div[5]/input")).SendKeys("Lucas");

            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
            js.ExecuteScript("window.scrollBy(0,1200)");

            driver.FindElement(By.XPath("//*[@id=\"sex-0\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"exp-4\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"datepicker\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"datepicker\"]")).SendKeys("16-10-2020");

            js.ExecuteScript("window.scrollBy(0,1800)");
            driver.FindElement(By.XPath("//*[@id=\"profession-1\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"tool-2\"]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"continents\"]/option[5]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"selenium_commands\"]/option[5]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"submit\"]")).Click();

            driver.Quit();
        }

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}