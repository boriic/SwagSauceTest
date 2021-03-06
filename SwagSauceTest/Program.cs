using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagSauceTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
        }
        [SetUp]
        public void Initialize()
        {
            //Navigate to login page
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        [Test]
        public void ExecuteTest()
        {
            //Initializing LoginPageObject
            LoginPageObject loginPageObject = new LoginPageObject(driver);
            //Initializing MainPageObject
            MainPageObject mainPageObject = loginPageObject.Login("standard_user", "secret_sauce");
            
        }
        [TearDown]
        public void Cleanup()
        {
            //Closing chrome
            driver.Close();
        }
    }
}
