
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

        private string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";
        public IWebElement FirstnameField => _driver.FindElement(By.Name("firstname"));
        public IWebElement LastNameField => _driver.FindElement(By.Name("lastname"));
        public IWebElement SubmitButton => _driver.FindElement(By.Id("submit1"));
        public IWebElement FemaleGenderRadioButton => _driver.FindElement(By.XPath("//input[@value='female']"));
        public IWebElement FemaleGenderRadioButtonForEmergencyContact => _driver.FindElement(By.XPath("//input[@ id='radio2-f']"));
        public IWebElement FirstnameFieldForContact => _driver.FindElement(By.Id("f2"));
        public IWebElement LastNameFieldForContact => _driver.FindElement(By.Id("l2"));

        internal void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Assert.IsTrue(IsVisible, $"Sample application page was not visible, Expected{PageTitle}." +
                $"Actual => {_driver.Title}");
        }
        internal UltimateQAHomePage FillOutPrimaryContactFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstnameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();
            return new UltimateQAHomePage(_driver);
        }

        internal void FillOutEmergencyContactUser(TestUser emergencyContactUser)
        {
            SetGenderFormEmergencyContact(emergencyContactUser);
            FirstnameFieldForContact.SendKeys(emergencyContactUser.FirstName);
            LastNameFieldForContact.SendKeys(emergencyContactUser.LastName);
        }

        private void SetGenderFormEmergencyContact(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Male:
                    break;
                case Gender.Female:
                    FemaleGenderRadioButtonForEmergencyContact.Click();
                    break;
                case Gender.Other:
                    break;
            }
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