using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

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
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(homePageURL);
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
            HelperClasses.HelperFunctions helperFunctions = new HelperClasses.HelperFunctions(driver);
            helperFunctions.NavigateToURL(formsViewURL);
            Assert.AreEqual(formsViewURL, driver.Url);

            PageObjects.FormsView formsPage = new PageObjects.FormsView(driver);
            formsPage.ClickOnPracticeForm();

            TestData.PracticeForm practiceFormTestData = TestData.PracticeForm.Create(Faker.Name.First(), Faker.Name.First(), "0123456789", "Female");
            PageObjects.PracticeFormView practiceFormsPage = new PageObjects.PracticeFormView(driver);
            practiceFormsPage.EnterFirstName(practiceFormTestData.FirstName);
            practiceFormsPage.EnterLastName(practiceFormTestData.LastName);
            practiceFormsPage.SelectGender(practiceFormTestData.Gender);
            practiceFormsPage.EnterMobileNumber(practiceFormTestData.Mobile);
            practiceFormsPage.ClickOnSubmitButton();
            string SuccessMessage = practiceFormsPage.GetSuccessMessage();
            Assert.AreEqual("Thanks for submitting the form", SuccessMessage);

        }
        [Test]
        public void VerifyRequiredFields()
        {
            HelperClasses.HelperFunctions helperFunctions = new HelperClasses.HelperFunctions(driver);
            helperFunctions.NavigateToURL(formsViewURL);
            Assert.AreEqual(formsViewURL, driver.Url);

            PageObjects.FormsView formsPage = new PageObjects.FormsView(driver);
            formsPage.ClickOnPracticeForm();

            PageObjects.PracticeFormView practiceFormsPage = new PageObjects.PracticeFormView(driver);
            practiceFormsPage.ClickOnSubmitButton();
            Assert.IsTrue(helperFunctions.IsAttributePresent(practiceFormsPage.firstName, "required"));
            Assert.IsTrue(helperFunctions.IsAttributePresent(practiceFormsPage.lastName, "required"));
            Assert.IsTrue(helperFunctions.IsAttributePresent(practiceFormsPage.genderMale, "required"));
            Assert.IsTrue(helperFunctions.IsAttributePresent(practiceFormsPage.genderFemale, "required"));
            Assert.IsTrue(helperFunctions.IsAttributePresent(practiceFormsPage.genderOther, "required"));
            Assert.IsTrue(helperFunctions.IsAttributePresent(practiceFormsPage.mobile, "required"));

        }
    }
}
