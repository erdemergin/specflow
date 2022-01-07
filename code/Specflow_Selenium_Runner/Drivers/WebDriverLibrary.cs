using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Specflow_Selenium_Runner.Drivers
{
    internal class WebDriverLibrary
    {
        private FeatureContext _featureContext;
        private Dictionary<string, IWebDriver> _driverDictionary = new Dictionary<string, IWebDriver>();

        public WebDriverLibrary(FeatureContext featureContext) => _featureContext = featureContext;

        public IWebDriver Setup(string browserName, string browserType)
        {
            if (_featureContext.ContainsKey(browserName))
                throw new InvalidOperationException("browser already defined");

            dynamic capability = GetBrowserOptions(browserType);
            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability.ToCapabilities());

            _featureContext.Add(browserName, driver);
            _driverDictionary.Add(browserName, driver);

            return driver;
        }

        public void CleanupDrivers()
        {
            foreach(KeyValuePair<string, IWebDriver> node in _driverDictionary)
            {
                node.Value.Quit();
                _featureContext.Remove(node.Key);
            }
            _driverDictionary.Clear();
        }

        private dynamic GetBrowserOptions(string browserType)
        {

            dynamic capability;
            switch(browserType.ToLowerInvariant())
            {
                case "chrome":
                    capability = new ChromeOptions();
                    break;
                case "firefox":
                    capability = new FirefoxOptions();
                    break;
                case "microsoftedge":
                    capability = new EdgeOptions();
                    break;
                case "safari":
                    capability = new SafariOptions();
                    break;
                default:
                    capability = new ChromeOptions();
                    break;
            };

            capability.AddAdditionalOption("se:recordVideo", true);
            return capability;
        }
    }
}
