using OpenQA.Selenium;

namespace SampleFramework1
{
    internal class BaseSampleApplicationPage
    {
        protected IWebDriver _driver { get; set; }

        public BaseSampleApplicationPage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}