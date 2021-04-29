using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace ConcentricDemoProj.HelperClasses
{
    class HelperFunctions
    {
        IWebDriver driver;
        public HelperFunctions(IWebDriver driver)
        {
            this.driver = driver;
        }

        //implicit wait.
        public IWebElement WaitAndGetElement(By by, int secsToWait = 30)
        {
            if (by != null)
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, secsToWait)); //you can play with the time integer  to wait for longer than 30 seconds.`
                IWebElement el = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return el;
            }
            return null;
        }
        //function to scroll to bottom of page.
        public void ScrollToBottomOfPage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(new TimeSpan(0, 0, 2));
        }
        //function to click on web elements.
        public void Click(By by)
        {
            IWebElement elemToClick = WaitAndGetElement(by);
            elemToClick.Click();
        }
        //function to verify if a certain attribute is present for an element or not.
        public bool IsAttributePresent(By by, string attribute)
        {
            Boolean result = false;
            string value = driver.FindElement(by).GetAttribute(attribute);
            if (value != null)
            {
                result = true;
            }
            return result;
        }
        //function to navigate on provided URL
        public void NavigateToURL(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
        //function to get the text of provided webelement.
        public string GetText(By by)
        {
            IWebElement currentelement = WaitAndGetElement(by);
            if (currentelement != null)
            {
                string text = currentelement.Text;
                return text;
            }
            else
            {
                return null;
                //log error here
            }
        }
        //function to enter text in text fields.
        public void EnterValue(By by, string value)
        {
            IWebElement elemToEnterValue = WaitAndGetElement(by);
            elemToEnterValue.Clear();
            elemToEnterValue.SendKeys(value);
        }
    }
}
