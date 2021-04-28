using OpenQA.Selenium;

namespace ConcentricDemoProj.PageObjects
{
    class PracticeFormView
    {
        IWebDriver driver;
        HelperClasses.FunctionsToInteractWithBrowser functionsToInteractWithBrowser;
        public PracticeFormView(IWebDriver driver)
        {
            this.driver = driver;
            functionsToInteractWithBrowser = new HelperClasses.FunctionsToInteractWithBrowser(driver);
        }

        public By submitButton = By.Id("submit");
        public By firstName = By.Id("firstName");
        public By lastName = By.Id("lastName");
        public By mobile = By.Id("userNumber");
        public By genderMale = By.Id("gender-radio-1");
        public By genderFemale = By.Id("gender-radio-2");
        public By genderOther = By.Id("gender-radio-3");
        public By genderMaleLabel = By.XPath("//label[@for='gender-radio-1']");
        public By genderFemaleLabel = By.XPath("//label[@for='gender-radio-2']");
        public By genderOtherLabel = By.XPath("//label[@for='gender-radio-3']");
        public By successMessage = By.Id("example-modal-sizes-title-lg");

        public void ClickOnSubmitButton()
        {
            functionsToInteractWithBrowser.ScrollToBottomOfPage();
            functionsToInteractWithBrowser.Click(submitButton);
        }
        public void EnterFirstName(string firstNameToEnter)
        {
            functionsToInteractWithBrowser.EnterValue(firstName, firstNameToEnter);
        }
        public void EnterLastName(string lastNameToEnter)
        {
            functionsToInteractWithBrowser.EnterValue(lastName, lastNameToEnter);
        }
        public void SelectGender(string gender)
        {
            if (gender.ToLower() == "male")
            {
                functionsToInteractWithBrowser.Click(genderMaleLabel);
            }
            else if (gender.ToLower() == "female")
            {
                functionsToInteractWithBrowser.Click(genderFemaleLabel);
            }
            else
            {
                functionsToInteractWithBrowser.Click(genderOtherLabel);
            }
        }
        public void EnterMobileNumber(string mobileNumber)
        {
            functionsToInteractWithBrowser.EnterValue(mobile, mobileNumber);
        }
        public string GetSuccessMessage()
        {
            string message = functionsToInteractWithBrowser.GetText(successMessage);
            return message;
        }
    }
}
