﻿using NUnit.Framework;
using System;
using Selenium;
using System.Web;
using System.Text;
using System.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SauceLabProject4
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]//,"Windows")]
    public class SauceNUnit_Test
    {
        private IWebDriver driver;
        private String browser;
        // private String version;
        private String os;
        //private String deviceName;
        //private String deviceOrientation;

        public SauceNUnit_Test(String browser) //,  String os) //, String version, String deviceName, String deviceOrientation)
        {
            this.browser = browser;
            // this.os = os;
            //this.version = version;

            //this.deviceName = deviceName;
            //this.deviceOrientation = deviceOrientation;
        }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browser);
            //caps.SetCapability(CapabilityType.Version, version);
            //   caps.SetCapability(CapabilityType.Platform, os);
            //  caps.SetCapability("deviceName", deviceName);
            //  caps.SetCapability("deviceOrientation", deviceOrientation);
            //  caps.SetCapability("username", Constants.SAUCE_LABS_ACCOUNT_NAME);
            //  caps.SetCapability("accessKey", Constants.SAUCE_LABS_ACCOUNT_KEY);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), caps, TimeSpan.FromSeconds(600));

        }

        [Test]
        public void googleTest()
        {
            driver.Navigate().GoToUrl("http://www.mortgagecalculator.org/");
              StringAssert.Contains("Google", driver.Title);
            //  IWebElement query = driver.FindElement(By.Name("q"));
            //  query.SendKeys("Sauce Labs");
            //  query.Submit();
        }

        [Test]
        public void googleTest2()
        {
            driver.Navigate().GoToUrl("http://www.mortgagecalculator.org/");
            //  StringAssert.Contains("Google", driver.Title);
            //  IWebElement query = driver.FindElement(By.Name("q"));
            //  query.SendKeys("Sauce Labs");
            //  query.Submit();
        }

        [TearDown]
        public void CleanUp()
        {
            bool passed = TestContext.CurrentContext.Result.Status == TestStatus.Passed;
            try
            {
                // Logs the result to Sauce Labs
                //  ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
            finally
            {
                // Terminates the remote webdriver session
                driver.Quit();
            }
        }
    }
}
