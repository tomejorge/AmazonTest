using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using AmazonTest.Pages;

namespace AmazonTest.Steps
{
    [Binding]
    public class AmazonSteps
    {
        private DriverHelper _driverHelper;
        HomePage homePage;
        productPage productPage;

        public AmazonSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            productPage = new productPage(_driverHelper.Driver);
        }


        [Given(@"I navigate to the amazon homepage")]
        public void GivenINavigateToTheAmazonHomepage()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://www.amazon.com/");
        }
        
        [Given(@"I search for the word laptop")]
        public void GivenISearchForTheWordLaptop()
        {
            homePage.searchForItem("laptop");
        }

        [Given(@"I click on the first result")]
        public void GivenIClickOnTheFirstResult()
        {
            homePage.clickFirstResult();
        }

        [Then(@"Its price should be higher than (.*)")]
        public void ThenItsPriceShouldBeHigherThan(int p0)
        {
            productPage.assertPriceHigherThan(100);
        }
    }
}
