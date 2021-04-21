using OpenQA.Selenium;
using System.Collections.Generic;
using AmazonTest.Extensions;

namespace AmazonTest.Pages
{
    class HomePage
    {
        private IWebDriver Driver;

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        // Locators
        IWebElement inputSearch => DriverExtentions.FindElement(Driver, By.Id("twotabsearchtextbox"), 10);
        IWebElement searchButton => Driver.FindElement(By.Id("nav-search-submit-text"));
        IList<IWebElement> getListLaptopPriceWhole => Driver.FindElements(By.XPath("//span[@class='a-price-whole']"));

        public void searchForItem(string searchString) 
        {

            inputSearch.SendKeys(searchString);
            searchButton.Click();
        }
        public void clickFirstResult()
        {
            // click on first result price (located by index)
            getListLaptopPriceWhole[0].Click();
        }

    }
}
