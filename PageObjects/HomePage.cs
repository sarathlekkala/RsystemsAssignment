using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RsystemAssign.PageObjects
{
    public class HomePage
    {
        IWebDriver driver;
        private WebDriverWait wait;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
          
        }
         private By checkboxTableLocator = By.XPath("//div[contains(@class, 'p-datatable p-component')]/ancestor::div[@class='card']/h5[text()='Checkbox']");
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ScrollToCheckboxTable()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement checkboxTable = wait.Until(ExpectedConditions.ElementToBeClickable(checkboxTableLocator));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkboxTable);
        }

        public void SelectCheckboxForRow(string rowName)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //By checkboxLocator = By.XPath($"//tr[td[text()='{rowName}']]//input[@type='checkbox']");
            //IWebElement checkbox = wait.Until(ExpectedConditions.ElementIsVisible(checkboxLocator));
            //// Wait for the table to be visible
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[td[text()='Blue Band']]")));

            // Find the checkbox next to the row with the Name 'Blue Band' and select it
            IWebElement checkbox = driver.FindElement(By.XPath("//tr[td[text()='Blue Band']]//*[@role='checkbox']"));
            checkbox.Click();


        }

    }
}