using OpenQA.Selenium;

namespace ConcentricDemoProj.PageObjects
{
    class FormsView
    {
        IWebDriver driver;
        HelperClasses.HelperFunctions helperFunctions;
        public FormsView(IWebDriver driver)
        {
            this.driver = driver;
            helperFunctions = new HelperClasses.HelperFunctions(driver);
        }

        public static By practiceForm = By.XPath("//span[text()='Practice Form']");

        public void ClickOnPracticeForm()
        {
            helperFunctions.Click(practiceForm);
        }
    }
}
