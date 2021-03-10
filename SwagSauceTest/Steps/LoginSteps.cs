using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagSauceTest.Context;
using SwagSauceTest.Methods;
using SwagSauceTest.PageObjects;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SwagSauceTest.Steps
{
    [Binding]
    public class LoginSteps
    {
        public WebDriverContext _webDriverContext;
        public LoginPageObject loginPageObject;
        public LoginSteps(WebDriverContext webDriverContext)
        {
            _webDriverContext = webDriverContext;
        }

       [Given(@"I launch the website")]
        public void GivenILaunchTheWebsite()
        {
            _webDriverContext.chromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            loginPageObject = new LoginPageObject(_webDriverContext.chromeDriver);
        }
        
        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPageObject.Login(data.Username, data.Password);
        }
        
        [Given(@"I click the login button")]
        public void GivenIClickTheLoginButton()
        {
            loginPageObject.ClickLogin();
        }
        
        [Then(@"I should be redirected to product list page")]
        public void ThenIShouldBeRedirectedToProductListPage()
        {
            loginPageObject.TestIfLoginPassed();
            Dispose();
        }
        public void Dispose()
        {
            //Closing chrome
            _webDriverContext.chromeDriver.Quit();
        }
    }
}
