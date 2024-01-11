using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;
using System.Reflection;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCategory("Manipulation")]
        public void TestMethod1()
        {
            var driver = GetChromeDrive();

          
            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms/");
            var nameField = driver.FindElement(By.Id("et_pb_contact_name_0"));
            nameField.Clear();
            nameField.SendKeys("Test");

            var textBox = driver.FindElement(By.Id("et_pb_contact_message_0"));
            textBox.Clear();
            textBox.SendKeys("Testing");

            var submitBtn = driver.FindElements(By.ClassName("et_pb_contact_submit"));
            submitBtn[0].Submit();

            driver.Quit();

        }

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}