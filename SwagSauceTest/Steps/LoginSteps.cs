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
        public Contexts _contexts;
        public LoginSteps(Contexts contexts)
        {
            _contexts = contexts;
        }

       [Given(@"I launch the website")]
        public void GivenILaunchTheWebsite()
        {
            _contexts.chromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }
        
        [Given(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _contexts.loginPageObject.Login(data.Username, data.Password);
        }
        
        [Given(@"I click the login button")]
        public void GivenIClickTheLoginButton()
        {
            _contexts.loginPageObject.ClickLogin();
        }
        
        [Then(@"I should be redirected to product list page")]
        public void ValidInformation()
        {
            _contexts.loginPageObject.TestIfLoginPassed();
            Dispose();
        }
        [Then(@"I should see the Password is required error message")]
        public void WrongPassword()
        {
            _contexts.loginPageObject.LoginWithWrongPassword();
            Dispose();
        }

        [Given(@"I enter no details in the login form")]
        public void GivenIEnterNoDetailsInTheLoginForm()
        {
            _contexts.loginPageObject.ClickLogin();
        }
        [Then(@"I should see the Username and password do not match any user in this service error message")]
        public void WrongInformation()
        {
            _contexts.loginPageObject.LoginWithWrongInformation();
            Dispose();
        }


        [Then(@"I should see the Username is required error message")]
        public void NoInformation()
        {
            _contexts.loginPageObject.LoginWithoutAnyInfoErrorMsg();
            Dispose();
        }


        public void Dispose()
        {
            //Closing chrome
            _contexts.chromeDriver.Quit();
        }
    }
}
