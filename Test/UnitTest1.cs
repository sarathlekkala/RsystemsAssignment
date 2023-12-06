using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;
using RsystemAssign.BaseClass;
using RsystemAssign.PageObjects;
using System;
using AventStack.ExtentReports;

namespace RsystemAssign
{

    [TestFixture]
    public class Tests : BaseTest
    {
        

        [Test]
        public void TestCheckboxSelection()
        {

           HomePage homePage = new HomePage( driver);
            test= extent.CreateTest("TestCheckboxSelection", "Navigate to the URL, scroll to Checkbox table, select the checkbox against the row with the Name Blue Band");

            // Navigate to the URL
            homePage.NavigateToUrl("https://www.primefaces.org/primereact-v5/#/datatable/selection");

            // Scroll to the Checkbox table
            homePage.ScrollToCheckboxTable();

            // Select the checkbox against the row with the Name Blue Band
            homePage.SelectCheckboxForRow("Blue Band");

            string screenshotPath = "C:\\AutoDrivers\\TestCheckboxSelection.png";
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(screenshotPath);

            // Log screenshot in the report
            test.Info("Screenshot: " + test.AddScreenCaptureFromPath(screenshotPath));

            // Log additional information
           test.Log(Status.Info, "Checkbox for 'Blue Band' selected successfully.");


        }
    }
}