using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace ConcentricDemoProj.Tests
{
    class PracticeFormTests
    {
        public IWebDriver driver;
        string formsViewURL = "https://demoqa.com/forms";
        string homePageURL = "https://demoqa.com/";

        [SetUp]
        public void CreateDriver()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(homePageURL);
            }
            catch
            {
                Thread.Sleep(30000);
            }
        }

        [TearDown]
        public void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
        [Test]
        public void VerifyUserCanSubmitFormSuccessully()
        {
            TestData.PracticeForm practiceFormTestData = new TestData.PracticeForm()
            {
                firstName = Faker.Name.First(),
                lastName = Faker.Name.First(),
                mobile = "0123456789",
                gender = "Female"
            };

            HelperClasses.FunctionsToInteractWithBrowser functionsToInteractWithBrowser = new HelperClasses.FunctionsToInteractWithBrowser(driver);
            functionsToInteractWithBrowser.NavigateToURL(formsViewURL);
            Assert.AreEqual(formsViewURL, driver.Url);

            PageObjects.FormsView formsPage = new PageObjects.FormsView(driver);
            formsPage.ClickOnPracticeForm();

            PageObjects.PracticeFormView practiceFormsPage = new PageObjects.PracticeFormView(driver);
            practiceFormsPage.EnterFirstName(practiceFormTestData.firstName);
            practiceFormsPage.EnterLastName(practiceFormTestData.lastName);
            practiceFormsPage.SelectGender(practiceFormTestData.gender);
            practiceFormsPage.EnterMobileNumber(practiceFormTestData.mobile);
            practiceFormsPage.ClickOnSubmitButton();
            string SuccessMessage = practiceFormsPage.GetSuccessMessage();
            Assert.AreEqual("Thanks for submitting the form", SuccessMessage);

        }
        [Test]
        public void VerifyRequiredFields()
        {
            HelperClasses.FunctionsToInteractWithBrowser functionsToInteractWithBrowser = new HelperClasses.FunctionsToInteractWithBrowser(driver);
            functionsToInteractWithBrowser.NavigateToURL(formsViewURL);
            Assert.AreEqual(formsViewURL, driver.Url);

            PageObjects.FormsView formsPage = new PageObjects.FormsView(driver);
            formsPage.ClickOnPracticeForm();

            PageObjects.PracticeFormView practiceFormsPage = new PageObjects.PracticeFormView(driver);
            practiceFormsPage.ClickOnSubmitButton();
            Assert.IsTrue(functionsToInteractWithBrowser.IsAttributePresent(practiceFormsPage.firstName, "required"));
            Assert.IsTrue(functionsToInteractWithBrowser.IsAttributePresent(practiceFormsPage.lastName, "required"));
            Assert.IsTrue(functionsToInteractWithBrowser.IsAttributePresent(practiceFormsPage.genderMale, "required"));
            Assert.IsTrue(functionsToInteractWithBrowser.IsAttributePresent(practiceFormsPage.genderFemale, "required"));
            Assert.IsTrue(functionsToInteractWithBrowser.IsAttributePresent(practiceFormsPage.genderOther, "required"));
            Assert.IsTrue(functionsToInteractWithBrowser.IsAttributePresent(practiceFormsPage.mobile, "required"));

        }
    }
}
