using OpenQA.Selenium;

namespace SampleFramework1
{
    [TestClass]
    [TestCategory("SampleApplicationOne")]
    public class SampleApplicationOne
    {
        private IWebDriver _driver;

        [TestMethod]
        public void TestMethod1()
        {
            var sampleApplicationPage = new SampleApplicationPage(_driver);
            sampleApplicationPage.GoTo();
            Assert.IsTrue(sampleApplicationPage.IsVisible);

             var ultimateQAHomePage = sampleApplicationPage.FillOutFormAndSubmit("Evandro");
            Assert.IsTrue(ultimateQAHomePage.IsVisible);
        }
    }
}