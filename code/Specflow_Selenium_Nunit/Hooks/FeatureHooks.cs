using OpenQA.Selenium;
using Specflow_Selenium_Nunit.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow_Selenium_Nunit.Hooks
{
    [Binding]
    internal class FeatureHooks
    {
        private readonly FeatureContext _featureContext;

        public FeatureHooks(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        [BeforeFeature]
        public static void CreateDriverLibraries(FeatureContext featureContext)
        {
            var webDriverLibrary = new WebDriverLibrary(featureContext);
            featureContext.Add(Constants.WebDriverLibraryKey, webDriverLibrary);
        }

        [AfterFeature]
        public static void CleanupDrivers(FeatureContext featureContext)
        {
            //TODO: We need a way to get all drivers and Quit at the end. 
            // One idea is to store the keys in the driver library classes to we cab easily get all keys
            // Another option is to traver the featureContext and locate all objects by checking type of values
            featureContext.Get<IWebDriver>(Constants.DefaultWebDriverName).Quit();
        }
    }
}
