using OpenQA.Selenium;
using Specflow_Selenium_Runner.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Specflow_Selenium_Runner.StepDefinitions
{
    [Binding]
    public sealed class WebDriverStepDefinitions
    {
        private FeatureContext _featureContext;

        public WebDriverStepDefinitions(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        [Given(@"browser")]
        public void GivenBrowser()
        {
            string browserName = Constants.DefaultWebDriverName;
            //TODO: Support multiple browser types, browser names should be unique accros the feature
            _featureContext.Get<WebDriverLibrary>(Constants.WebDriverLibraryKey).Setup(browserName, "chrome");
        }

        [When(@"I open URL '([^']*)'")]
        public void WhenIOpenURL(string p0)
        {
            var driver = _featureContext.Get<IWebDriver>(Constants.DefaultWebDriverName);
            driver.Url = p0;
        }

        [Then(@"I should see '([^']*)'")]
        public void ThenIShouldSee(string p0)
        {
            Thread.Sleep(1000);
            return;
        }



    }
}
