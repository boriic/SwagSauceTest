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
        public void ValidLogin()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            loginPageObject.VerifyValidLogin("standard_user", "secret_sauce", true);

        }
        [Test]
        public void InvalidLogin()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            loginPageObject.VerifyInvalidLogin("krivi", "podatci");
            driver.Navigate().Refresh();
        }
        [Test]
        public void VerifyLoginWithUsernameOnly()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            loginPageObject.VerifyLoginWithUsernameOnly("standard_user");
            driver.Navigate().Refresh();
        }
        [Test]
        public void VerifyLoginWithPasswordOnly()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            loginPageObject.VerifyLoginWithPasswordOnly("secret_sauce");
            driver.Navigate().Refresh();
        }
        [Test]
        public void VerifyLoginWithWrongUsername()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            loginPageObject.VerifyLoginWithWrongUsername("krivi_username", "secret_sauce");
            driver.Navigate().Refresh();
        }
        [Test]
        public void VerifyLoginWithWrongPassword()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            loginPageObject.VerifyLoginWithWrongPassword("standard_user", "kriva_sifra");
            driver.Navigate().Refresh();
        }
        [Test]
        public void LoginWithoutInfo()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            loginPageObject.VerifyLoginWithoutAnyInfo();
            driver.Navigate().Refresh();
        }
        [TestFixtureTearDown]
        public void Cleanup()
        {
            //Closing chrome
            driver.Close();
        }
    }
}
