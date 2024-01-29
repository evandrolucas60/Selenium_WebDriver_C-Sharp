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
        internal SampleApplicationPage sampleAppPage { get; private set; }
        internal TestUser TheTestUser { get; private set; }


        [TestInitialize]
        public void SetupForEverySingleMethod()
        {
            _driver = GetChromeDrive();
            sampleAppPage = new SampleApplicationPage(_driver);
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
        [Description("Validate that user is able to fill out the form successfully using valid data. ")]
        public void TestMethod1()
        {
            TheTestUser.GenderType = Gender.Female;

            sampleAppPage.GoTo();
            var ultimateQAHomePage = sampleAppPage.FillOutFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);

        }
           
        [TestMethod]
        [Description("Fake 2nd test.")]
        public void PretendTestNumber2()
        {
            sampleAppPage.GoTo();
            var ultimateQAHomePage = sampleAppPage.FillOutFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }

        [TestMethod]
        [Description("Validate that when selecting the Other gender type, the form is subimmited  sucessfully ")]
        public void Test3()
        {
            TheTestUser.GenderType = Gender.Other;
            sampleAppPage.GoTo();
            var ultimateQAHomePage = sampleAppPage.FillOutFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }

        private IWebDriver GetChromeDrive()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }

        static void AssertPageVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }

        private void AssertPageVisibleVariation2(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "UltimateQA home page was not visible.");
        }
    }
}