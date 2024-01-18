using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationOne")]
    public class SampleApplicationOne
    {
        private IWebDriver _driver { get; set; }
        internal TestUser TheTestUser { get; private set; }


        [TestInitialize]
        public void SetupForEverySingleMethod()
        {
            _driver = GetChromeDrive();
            TheTestUser = new TestUser();
            TheTestUser.FirstName = "Evandro";
            TheTestUser.LastName = "Lucas";
        }

        [TestCleanup]
        public void CleanUpAfterEveryTestMethod()
        {
            _driver.Close();
            _driver.Quit();
        }

        [TestMethod]
        public void TestMethod1()
        {
            SetupForEverySingleMethod();

            var sampleApplicationPage = new SampleApplicationPage(_driver);
            sampleApplicationPage.GoTo();
          
            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }

        [TestMethod]
        public void PretendTestNumber2()
        {
            var sampleApplicationPage = new SampleApplicationPage(_driver);
            sampleApplicationPage.GoTo();

            var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}