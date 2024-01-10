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
        [TestMethod]
        [TestCategory("Driver Interrogation")]
        public void TestMethod1()
        {
            var driver = GetChromeDrive();

            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation");
            driver.Manage().Window.Maximize();
            //1. find button using ID
            var myElement = driver.FindElement(By.Id("button1"));
            //2. GetAttribute("type") and assert that it equals the right value
            Assert.IsTrue(myElement.GetAttribute("type").Equals("submit"));
            //3. GetCssValue
            Assert.IsTrue(myElement.GetCssValue("letter-spacing").Equals("normal"));
            //4. Assert is Displayed
            Assert.IsTrue(myElement.Displayed);
            //5. Assert is Enabled
            Assert.IsTrue(myElement.Enabled);
            //6. Assert is Not Selected
            Assert.IsFalse(myElement.Selected);
            //7. Assert the text is correct
            Assert.IsTrue(myElement.Text.Equals("Click Me!"));
            //8. Assert that the tag name is correct
            Assert.IsTrue(myElement.TagName.Equals("button"));
            //9. Assert that the size height is 21
            Assert.IsTrue(myElement.Size.Height.Equals(21));
            //10. Assert that the location is x=190, y=330
            Assert.AreEqual(341, myElement.Location.X);
            Assert.AreEqual(171, myElement.Location.Y);

            driver.Quit();
        }
        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}