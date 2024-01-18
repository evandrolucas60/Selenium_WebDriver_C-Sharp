using OpenQA.Selenium;

namespace SampleFramework1
{
    internal class UltimateQAHomePage : BaseSampleApplicationPage
    {
        public UltimateQAHomePage(IWebDriver driver) : base(driver) { }
        public IWebElement ScheduleButton => _driver.FindElement(By.XPath("//*[@id=\"post-217913\"]/div/div[1]/div/div[1]/div[1]/div[1]/div[3]/a"));
        public bool IsVisible
        {
            get
            {
                try
                {
                    return ScheduleButton.Displayed;
                }
                catch (NoSuchElementException)
                {

                    return false;
                }
            }
        }
        

    }
}