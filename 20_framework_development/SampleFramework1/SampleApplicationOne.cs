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
        internal SampleApplicationPage SampleAppPage { get; private set; }
        internal TestUser TheTestUser { get; private set; }
        internal TestUser EmergencyContactUser { get; private set; }

        [TestInitialize]
        public void SetupForEverySingleMethod()
        {
            _driver = GetChromeDrive();
            SampleAppPage = new SampleApplicationPage(_driver);

            TheTestUser = new TestUser();
            TheTestUser.FirstName = "Evandro";
            TheTestUser.LastName = "Lucas";
            
            EmergencyContactUser = new TestUser();
            EmergencyContactUser.FirstName = "Emergency First Name";
            EmergencyContactUser.LastName = "Emergency Last Name";
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
            SetGenderTypes(Gender.Female, Gender.Female);

            SampleAppPage.GoTo();
            SampleAppPage.FillOutEmergencyContactUser(EmergencyContactUser);
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisible(ultimateQAHomePage);
        }

        [TestMethod]
        [Description("Fake 2nd test.")]
        public void PretendTestNumber2()
        {
            SampleAppPage.GoTo();
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
            AssertPageVisibleVariation2(ultimateQAHomePage);
        }

        [TestMethod]
        [Description("Validate that when selecting the Other gender type, the form is subimmited  sucessfully ")]
        public void Test3()
        {
            SetGenderTypes(Gender.Other, Gender.Other);

            SampleAppPage.GoTo();
            var ultimateQAHomePage = SampleAppPage.FillOutPrimaryContactFormAndSubmit(TheTestUser);
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

        private void SetGenderTypes(Gender primaryContact, Gender emergencyContact)
        {
            TheTestUser.GenderType = primaryContact;
            EmergencyContactUser.GenderType = emergencyContact;
        }
    }
}