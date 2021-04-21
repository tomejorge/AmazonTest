using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace AmazonTest.Pages
{
    class productPage
    {
        private IWebDriver Driver;

        public productPage(IWebDriver driver)
        {
            Driver = driver;
        }

        // using partial locator as ending changes depending on type of price/discount
        IWebElement fullPrice => Driver.FindElement(By.CssSelector("span[id*='priceblock']"));

        public void assertPriceHigherThan(int targetPrice)
        {
            string price = fullPrice.Text;
            string priceStripped = Regex.Replace(price, "[^,.0-9]", "");
            
            try
            {
                float priceNum = float.Parse(priceStripped);
                Assert.That(priceNum > targetPrice, $"{priceStripped} is lower than {targetPrice}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{price}'");
            }
        }
    }
}
