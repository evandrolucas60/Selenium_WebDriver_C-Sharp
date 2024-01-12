using OpenQA.Selenium;

namespace PageObjects
{
    public class ShoppingCartPage
    {
        private IWebDriver _driver;

        public ShoppingCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public ShoppingCartPage Open()
        {
            _driver.Navigate().GoToUrl("https://react-shopping-cart-67954.firebaseapp.com/");
            return this;
        }

        public ShoppingCartComponent AddItemToCart()
        {
            _driver.FindElement(By.ClassName("sc-124al1g-0")).Click();
            return new ShoppingCartComponent(_driver);
        }
    }
}