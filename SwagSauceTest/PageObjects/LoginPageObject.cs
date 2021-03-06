﻿using NUnit.Framework;
using OpenQA.Selenium;
using SwagSauceTest.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.PageObjects
{
    class LoginPageObject
    {
        private readonly IWebDriver _driver;
        public LoginPageObject(IWebDriver driver) => _driver = driver;
        public IWebElement txtForUserNameField => _driver.FindElement(By.Name("user-name"));
        public IWebElement txtForPasswordField => _driver.FindElement(By.Name("password"));

        public IWebElement btnLogin => _driver.FindElement(By.Id("login-button"));
        public IWebElement burgerButton => _driver.FindElement(By.Id("react-burger-menu-btn"));
        public IWebElement logOut => _driver.FindElement(By.Id("logout_sidebar_link"));


        public MainPageObject VerifyValidLogin(string userName, string password, bool isTestingLogin)
        {
            txtForUserNameField.EnterText(userName);
            txtForPasswordField.EnterText(password);
            btnLogin.Submit();
            var loggedInTitle = _driver.FindElement(By.XPath("//*[@id='inventory_filter_container']/div")).GetAttribute("innerHTML");
            Assert.AreEqual(loggedInTitle, "Products");
            if (isTestingLogin)
            {
                burgerButton.Click();
                System.Threading.Thread.Sleep(2000);
                logOut.Click();
            }
            return new MainPageObject(_driver);       
        }
        public void VerifyInvalidLogin(string userName, string password)
        {
            txtForUserNameField.EnterText(userName);
            txtForPasswordField.EnterText(password);
            btnLogin.Submit();
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, "Epic sadface: Username and password do not match any user in this service");
            _driver.Navigate().Refresh();
        }
        public void VerifyLoginWithoutAnyInfo()
        {
            btnLogin.Submit();
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, "Epic sadface: Username is required");
            _driver.Navigate().Refresh();
        }
        public void VerifyLoginWithUsernameOnly(string userName)
        {
            txtForUserNameField.EnterText(userName);
            btnLogin.Submit();
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, "Epic sadface: Password is required");
            _driver.Navigate().Refresh();
        }
        public void VerifyLoginWithPasswordOnly(string password)
        {
            txtForPasswordField.EnterText(password);
            btnLogin.Submit();
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, "Epic sadface: Username is required");
            _driver.Navigate().Refresh();
        }
        public void VerifyLoginWithWrongUsername(string userName, string password)
        {
            txtForUserNameField.EnterText(userName);
            txtForPasswordField.EnterText(password);
            btnLogin.Submit();
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, "Epic sadface: Username and password do not match any user in this service");
            _driver.Navigate().Refresh();
        }
        public void VerifyLoginWithWrongPassword(string userName, string password)
        {
            txtForUserNameField.EnterText(userName);
            txtForPasswordField.EnterText(password);
            btnLogin.Submit();
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, "Epic sadface: Username and password do not match any user in this service");
            _driver.Navigate().Refresh();
        }
        public void LogOut()
        {
            burgerButton.Click();
            logOut.Click();
            var loginPageText = _driver.FindElement(By.Id("login-button"));
            Assert.AreEqual(loginPageText.Text, "Login");
            _driver.Navigate().Refresh();
        }
    }
}
