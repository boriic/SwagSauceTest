using OpenQA.Selenium.Chrome;
using SwagSauceTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.Context
{
    public class Contexts
    {
        public ChromeDriver chromeDriver;
        public LoginPageObject loginPageObject;
        public MainPageObject mainPageObject;
        public Contexts()
        {
            chromeDriver = new ChromeDriver();
            loginPageObject = new LoginPageObject(chromeDriver);
            mainPageObject = new MainPageObject(chromeDriver);
        }

    }
}
