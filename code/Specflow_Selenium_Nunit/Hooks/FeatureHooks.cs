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
            featureContext.Get<WebDriverLibrary>(Constants.WebDriverLibraryKey).CleanupDrivers();
        }
    }
}
