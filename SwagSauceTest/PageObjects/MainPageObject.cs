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
    public class MainPageObject
    {
        private readonly IWebDriver _driver;
        public MainPageObject(IWebDriver driver) => _driver = driver;
        public IWebElement addProducts => _driver.FindElement(By.XPath("//*[@id='inventory_container']/div/div[1]/div[3]/button"));
        public List<IWebElement> listAllProducts => _driver.FindElements(By.ClassName("inventory_item")).ToList();
        public IWebElement changeFilter => _driver.FindElement(By.ClassName("product_sort_container"));

        public void RedirectedToProductList()
        {
            bool areProductsVisible = _driver.FindElement(By.Id("inventory_container")).Displayed;
            Assert.IsTrue(areProductsVisible);
        }
        //public void AddAllProducts()
        //{
        //    var numberOfProducts = listAllProducts.Count;
        //    for (int i = 0; i < numberOfProducts; i++)
        //    {
        //        AddProductAtIndexOf(i);
        //    }
        //}
        public void AddProductAtIndexOf(int index)
        {
            var numberOfProducts = listAllProducts.Count;
            if (index >= 0 && index <= numberOfProducts)
            {
                IWebElement productButton = listAllProducts[index].FindElement(By.ClassName("btn_inventory"));
                var buttonTitle = productButton.Text;
                if (buttonTitle == Message.AddToCart)
                {
                    productButton.Click();
                    Task.Delay(500).Wait();
                    var cartNumber = int.Parse(_driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a/span")).Text);
                    if (cartNumber > 0)
                    {
                        Assert.AreEqual(productButton.Text, Message.RemoveFromCart);
                    }
                }
            }
        }
        public void ButtonTextRemoveAndCartUpdated(int index)
        {
            var numberOfProducts = listAllProducts.Count;
            if (index >= 0 && index <= numberOfProducts)
            {
                IWebElement productButton = listAllProducts[index].FindElement(By.ClassName("btn_inventory"));
                var buttonTitle = productButton.Text;
                var cartNumber = int.Parse(_driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a/span")).Text);
                var isCartUpdated = cartNumber > 0 ? true : false;
                Assert.AreEqual(buttonTitle, Message.RemoveFromCart);
                Assert.IsTrue(isCartUpdated);

            }
        }
        public void ButtonTextADDTOCARTAndCartUpdated(int index)
        {
            var numberOfProducts = listAllProducts.Count;
            if (index >= 0 && index <= numberOfProducts)
            {
                IWebElement productButton = listAllProducts[index].FindElement(By.ClassName("btn_inventory"));
                var buttonTitle = productButton.Text;
                bool isCartNumberDisplayed;
                try
                {
                    var element = _driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a/span")).Displayed;
                    isCartNumberDisplayed = true;
                }
                catch
                {
                    isCartNumberDisplayed = false;
                }
                Assert.AreEqual(buttonTitle, Message.AddToCart);
                Assert.IsFalse(isCartNumberDisplayed);
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
                if (buttonTitle == Message.RemoveFromCart)
                {
                    productButton.Click();
                    Assert.AreEqual(productButton.Text, Message.AddToCart);
                }
            }

        }
        public void ChangeFilter(string value)
        {
            var currentFilterValue = _driver.FindElement(By.ClassName("product_sort_container")).GetAttribute("value");
            if (value != currentFilterValue)
            {
                var productsBeforeFilter = listAllProducts;
                changeFilter.SelectFilter(value);
                var productsAfterFilter = listAllProducts;
                Assert.AreNotEqual(productsBeforeFilter[0], productsAfterFilter[0]);
            }
        }
        public void CheckIfPageFiltered(string value)
        {
            var currentFilterValue = _driver.FindElement(By.ClassName("product_sort_container")).GetAttribute("value");
            Assert.AreEqual(value, currentFilterValue);
        }
    }
}
