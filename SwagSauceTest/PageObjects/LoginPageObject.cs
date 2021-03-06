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

        public MainPageObject Login(string userName, string password)
        {
            txtForUserNameField.EnterText(userName);
            txtForPasswordField.EnterText(password);
            btnLogin.Submit();
            return new MainPageObject(_driver);       
        }
    }
}
