using OpenQA.Selenium;

namespace PageObjects
{
    public class ShoppingCartComponent
    {
        private readonly IWebDriver _driver;

        public ShoppingCartComponent(IWebDriver driver)
        {
            _driver = driver;
        }

        public int ItemsInCart()
        {
            IWebElement cartElement = _driver.FindElement(By.ClassName("VLMSP"));
            int itemsInCart;

            if (int.TryParse(cartElement.Text, out itemsInCart))
            {
                return itemsInCart;
            }
            else
            {
                // Handle the case where the text is not a valid integer
                return -1; // or throw an exception, log an error, etc.
            }
        }
    }
}