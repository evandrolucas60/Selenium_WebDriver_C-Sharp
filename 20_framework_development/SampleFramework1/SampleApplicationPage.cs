
using OpenQA.Selenium;

namespace SampleFramework1
{
    internal class SampleApplicationPage : BaseSampleApplicationPage
    {
        public SampleApplicationPage(IWebDriver driver):base(driver) { }

        public bool IsVisible
        {
            get
            {
                return _driver.Title.Contains(PageTitle);
            }
            internal set { }
        }

        public IWebElement FirstnameField => _driver.FindElement(By.Name("firstname"));
        public IWebElement LastNameField => _driver.FindElement(By.XPath("//*[@id=\"post-932\"]/div/form/input[3]"));
        public IWebElement SubmitButton => _driver.FindElement(By.Name("lastname"));

        private string PageTitle => "Sample Application Lifecycle - Sprint 2 - Ultimate QA";

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-2/");
            Assert.IsTrue(IsVisible, $"Sample application page was not visible, Expected{PageTitle}." +
                $"Actual => {_driver.Title}");
        }
        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            FirstnameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.FirstName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(_driver);
        }
    }
}