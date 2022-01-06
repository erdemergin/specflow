using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow_Selenium_Nunit.Drivers
{
    internal class WebDriverLibrary
    {
        private FeatureContext _featureContext;


        public WebDriverLibrary(FeatureContext featureContext) => _featureContext = featureContext;

        public IWebDriver Setup(string browserName, string browserType)
        {
            if (_featureContext.ContainsKey(browserName))
                throw new InvalidOperationException("browser already defined");

            dynamic capability = GetBrowserOptions(browserType);
            var driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability.ToCapabilities());

            _featureContext.Add(browserName, driver);

            return driver;
        }

        private dynamic GetBrowserOptions(string browserType)
        {
            dynamic capability = browserType.ToLowerInvariant() switch
            {
                "chrome" => new ChromeOptions(),
                "firefox" => new FirefoxOptions(),
                "microsoftedge" => new EdgeOptions(),
                "safari" => new SafariOptions(),
                _ => new ChromeOptions(),// Chrome is default
            };
            capability.AddAdditionalOption("se:recordVideo", true);
            return capability;
        }
    }
}
