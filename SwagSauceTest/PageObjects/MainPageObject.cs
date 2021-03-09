using NUnit.Framework;
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
        public IWebElement addProducts => _driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[1]/div[3]/button"));
        public List<IWebElement> listAllProducts => _driver.FindElements(By.ClassName("inventory_item")).ToList();
        public IWebElement removeProduct => _driver.FindElement(By.ClassName("btn_secondary.btn_inventory"));
        public IWebElement changeFilter => _driver.FindElement(By.ClassName("product_sort_container"));

        public void AddAllProducts()
        {
            var numberOfProducts = listAllProducts.Count;
            for (int i = 0; i < numberOfProducts; i++)
            {
                AddProductAtIndexOf(i);
            }
        }
        public void AddProductAtIndexOf(int index)
        {
            var numberOfProducts = listAllProducts.Count;
            if (index >= 0 && index <= numberOfProducts)
            {
                IWebElement productButton = listAllProducts[index].FindElement(By.ClassName("btn_inventory"));
                var buttonTitle = productButton.Text;
                if (buttonTitle == "ADD TO CART")
                {
                    productButton.Click();
                    System.Threading.Thread.Sleep(500);
                    var cartNumber = int.Parse(_driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a/span")).Text);
                    if (cartNumber > 0)
                    {
                        Assert.AreEqual(productButton.Text, "REMOVE");
                    }
                }
            }

        }
        public void RemoveProductAtIndexOf(int index)
        {
            var numberOfProducts = listAllProducts.Count;
            bool isSomethingInCart;
            try
            {
                _driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a/span"));
                isSomethingInCart = true;
            }
            catch
            {
                isSomethingInCart = false;
            }
            if (index >= 0 && index <= numberOfProducts && isSomethingInCart)
            {
                IWebElement productButton = listAllProducts[index].FindElement(By.ClassName("btn_inventory"));
                var buttonTitle = productButton.Text;
                if (buttonTitle == "REMOVE")
                {
                    productButton.Click();
                    Assert.AreEqual(productButton.Text, "ADD TO CART");
                }
            }

        }
        public void RemoveProduct()
        {
            removeProduct.Click();
        }
        public void ChangeFilter(string value)
        {
            var currentFilterValue = _driver.FindElement(By.XPath("//*[@id='inventory_filter_container']/select/option[1]")).GetAttribute("value");
            if (value != currentFilterValue)
            {
                var productsBeforeFilter = listAllProducts;
                changeFilter.SelectFilter(value);
                var productsAfterFilter = listAllProducts;
                Assert.AreNotEqual(productsBeforeFilter[0], productsAfterFilter[0]);
            }      
        }
    }
}
