using OpenQA.Selenium;
using SwagSauceTest.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.PageObjects
{
    class MainPageObject
    {
        private readonly IWebDriver _driver;
        public MainPageObject(IWebDriver driver) => _driver = driver;
        public IWebElement addProducts => _driver.FindElement(By.ClassName("btn_primary.btn_inventory"));
        public IWebElement removeProduct => _driver.FindElement(By.ClassName("btn_secondary.btn_inventory"));
        public IWebElement changeFilter => _driver.FindElement(By.Id("shopping_cart_container"));
        public IWebElement goToCheckout => _driver.FindElement(By.ClassName("svg-inline--fa.fa-shopping-cart.fa-w-18.fa-3x "));

        public void AddProduct()
        {
            addProducts.Click();
        }
        public void RemoveProduct()
        {
            removeProduct.Click();
        }
        public void ChangeFilter(string value)
        {
            changeFilter.SelectFilter(value);
        }
        public void GoToCheckout()
        {
            goToCheckout.Click();
        }
    }
}
