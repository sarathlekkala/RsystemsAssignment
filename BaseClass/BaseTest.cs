using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports.Reporter;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace RsystemAssign.BaseClass
{

    public class BaseTest
    {
        public static IWebDriver driver;
        private WebDriverWait wait;
        public static ExtentReports extent;
        public static ExtentTest test;

        [SetUp]
        public void Setup()
        {
            // Set up the ExtentReports
            var chromeDriverPath = ("C:\\Automation\\RsystemAssign\\Driver");
            var htmlReporter = new ExtentHtmlReporter("C:\\Automation\\RsystemAssign\\Reports\\ExtentReport.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            // Set up the WebDriver
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized"); // Optional: Start Chrome maximized

            // Create a ChromeDriverService with the specified path
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(chromeDriverPath);

            // Create a ChromeDriver instance with the service and options
             driver = new ChromeDriver(service, options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            // Close the WebDriver
            driver.Quit();
            extent.Flush();

        }

    }
}
