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
//    class MainPageTest
//    {
//        readonly IWebDriver driver = new ChromeDriver();
//        public void Initialize()
//        {
//            //Navigate to login page
//            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
//        public void TestAllOnMainPage()
//        {
//            ////Initializing LoginPageObject and MainPageObject
//            //LoginPageObject loginPageObject = new LoginPageObject(driver);
//            //MainPageObject mainPageObject = new MainPageObject(driver);
//            //loginPageObject.ValidLogin("standard_user", "secret_sauce", false);
//            //mainPageObject.AddProductAtIndexOf(1);
//            //mainPageObject.RemoveProductAtIndexOf(1);
//            //mainPageObject.AddAllProducts();
//            //mainPageObject.ChangeFilter("az");
//            //mainPageObject.ChangeFilter("za");
//            //mainPageObject.ChangeFilter("lohi");
//            //mainPageObject.ChangeFilter("hilo");
//        }
//        public void Cleanup()
//        {
//            //Closing chrome
//            driver.Close();
//        }
//    }
//}
