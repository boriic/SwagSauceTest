using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagSauceTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.Tests
{
    [TestFixture]
    class LoginPageTest
    {
        IWebDriver driver = new ChromeDriver();
        [TestFixtureSetUp]
        public void Initialize()
        {
            //Navigate to login page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        [Test]
        public void VerifyAllLoginSituations()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            //Inserting verify methods
            loginPageObject.VerifyValidLogin("standard_user", "secret_sauce", true);
            loginPageObject.VerifyInvalidLogin("krivi", "podatci");
            loginPageObject.VerifyLoginWithUsernameOnly("standard_user");
            loginPageObject.VerifyLoginWithPasswordOnly("secret_sauce");
            loginPageObject.VerifyLoginWithWrongUsername("krivi_username", "secret_sauce");
            loginPageObject.VerifyLoginWithWrongPassword("standard_user", "kriva_sifra");
            loginPageObject.VerifyLoginWithoutAnyInfo();
        }
        [TestFixtureTearDown]
        public void Cleanup()
        {
            //Closing chrome
            driver.Close();
        }
    }
}
