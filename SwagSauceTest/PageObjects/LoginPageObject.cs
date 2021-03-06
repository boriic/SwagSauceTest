using NUnit.Framework;
using OpenQA.Selenium;
using SwagSauceTest.Messages;
using SwagSauceTest.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.PageObjects
{
    public class LoginPageObject
    {
        private readonly IWebDriver _driver;
        public LoginPageObject(IWebDriver driver) => _driver = driver;

        //UI ELEMENTS
        public IWebElement txtForUserNameField => _driver.FindElement(By.Name("user-name"));
        public IWebElement txtForPasswordField => _driver.FindElement(By.Name("password"));

        public IWebElement btnLogin => _driver.FindElement(By.Id("login-button"));
        public IWebElement burgerButton => _driver.FindElement(By.Id("react-burger-menu-btn"));
        public IWebElement logOut => _driver.FindElement(By.Id("logout_sidebar_link"));

        public MainPageObject Login(string userName, string password)
        {
            txtForUserNameField.EnterText(userName);
            txtForPasswordField.EnterText(password);
            return new MainPageObject(_driver);
        }
        public void ClickLogin()
        {
            btnLogin.Submit();
        }
        public void TestIfLoginPassed ()
        {
            var loggedInTitle = _driver.FindElement(By.XPath("//*[@id='inventory_filter_container']/div")).GetAttribute("innerHTML");
            Assert.AreEqual(loggedInTitle, Message.Products);
        }
        public void LogOut()
        {
            var loggedInTitle = _driver.FindElement(By.XPath("//*[@id='inventory_filter_container']/div")).GetAttribute("innerHTML");

            if (loggedInTitle == Message.Products)
            {
                burgerButton.Click();
                Task.Delay(1000).Wait();
                logOut.Click();
                var loggedOut = _driver.FindElement(By.Id("login-button")).GetAttribute("value");
                Assert.AreEqual(loggedOut, Message.Login);
            }        
        }
        public void LoginWithWrongInformationError()
        {
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, Message.WrongInfoLoginError);
        }
        public void LoginWithWrongPasswordError()
        {
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, Message.NoPasswordLoginError);
        }
        public void LoginWithoutAnyInfoErrorMsgError()
        {
            var errorText = _driver.FindElement(By.CssSelector("#login_button_container > div > form > h3"));
            Assert.AreEqual(errorText.Text, Message.NoInfoLoginError);
        }
    }
}
