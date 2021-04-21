using System;
using System.Linq;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Remote;

namespace AmazonTest.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private DriverHelper _driverHelper;
 
        public Hooks(DriverHelper driverHelper) => _driverHelper = driverHelper;

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            // options.AddArguments("--disable-gpu");
            // option.AddArguments("--headless");

            // webdrivermanager takes care of downloading and storing the latest drivers automatically
            // new DriverManager().SetUpDriver(new ChromeConfig());
            _driverHelper.Driver = new ChromeDriver("c:/driver", options);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }
    }
}
