//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using SwagSauceTest.PageObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SwagSauceTest.Tests
//{
//    [TestFixture]
//    class LoginPageTest
//    {
//        readonly IWebDriver driver = new ChromeDriver();
//        [OneTimeSetUp]
//        public void Initialize()
//        {
//            //Navigate to login page
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
//        }
//        [Test]
//        public void VerifyAllLoginSituations()
//        {
//            ////Initializing LoginPageObject
//            //LoginPageObject loginPageObject = new LoginPageObject(driver);
//            ////Inserting verify methods
//            //loginPageObject.ValidLogin("standard_user", "secret_sauce", true);
//            //loginPageObject.InvalidLogin("krivi", "podatci");
//            //loginPageObject.LoginWithUsernameOnly("standard_user");
//            //loginPageObject.LoginWithPasswordOnly("secret_sauce");
//            //loginPageObject.LoginWithWrongUsername("krivi_username", "secret_sauce");
//            //loginPageObject.LoginWithWrongPassword("standard_user", "kriva_sifra");
//            //loginPageObject.LoginWithoutAnyInfo();
//        }
//        [OneTimeTearDown]
//        public void Cleanup()
//        {
//            //Closing chrome
//            driver.Close();
//        }
//    }
//}
