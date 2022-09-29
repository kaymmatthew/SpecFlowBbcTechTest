using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SpecFlowBbcTechTest.Drivers;
using TechTalk.SpecFlow;
using System;
using System.Diagnostics;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowBbcTechTest.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        IObjectContainer container;
        public Hooks(IObjectContainer _container)
        {
            container = _container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArguments("--headless");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            container.RegisterInstanceAs<IWebDriver>(driver);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
            using (var process = Process.GetCurrentProcess())
            {
                if (process.ToString() == "chromedriver") 
                {
                    process.Kill(true);
                }
                else if (process.ToString() == "gechodriver")
                {
                    process.Kill(true);
                }
                driver?.Dispose(); driver = null;
            }
        }
    }
}
