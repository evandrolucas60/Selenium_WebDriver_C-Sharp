
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

        private string PageTitle => "Sample Application Lifecycle - Sprint 3 - Ultimate QA";
        public IWebElement FirstnameField => _driver.FindElement(By.Name("firstname"));
        public IWebElement LastNameField => _driver.FindElement(By.Name("lastname"));
        public IWebElement SubmitButton => _driver.FindElement(By.XPath("//*[@id=\"post-934\"]/div/form/input[6]"));
        public IWebElement FemaleGenderRadioButton => _driver.FindElement(By.XPath("//input[@value='female']"));

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-3/");
            Assert.IsTrue(IsVisible, $"Sample application page was not visible, Expected{PageTitle}." +
                $"Actual => {_driver.Title}");
        }
        internal UltimateQAHomePage FillOutFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstnameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(_driver);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButton.Click();
                    break;
                case Gender.Other:
                    break;
            }
        }
    }
}