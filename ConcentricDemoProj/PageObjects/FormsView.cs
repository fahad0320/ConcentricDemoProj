using OpenQA.Selenium;

namespace ConcentricDemoProj.PageObjects
{
    class FormsView
    {
        IWebDriver driver;
        HelperClasses.FunctionsToInteractWithBrowser functionsToInteractWithBrowser;
        public FormsView(IWebDriver driver)
        {
            this.driver = driver;
            functionsToInteractWithBrowser = new HelperClasses.FunctionsToInteractWithBrowser(driver);
        }

        public static By practiceForm = By.XPath("//span[text()='Practice Form']");

        public void ClickOnPracticeForm()
        {
            functionsToInteractWithBrowser.Click(practiceForm);
        }
    }
}
