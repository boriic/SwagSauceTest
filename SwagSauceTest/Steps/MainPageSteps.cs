using SwagSauceTest.Context;
using SwagSauceTest.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SwagSauceTest.Steps
{
    [Binding]
    public sealed class MainPageSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public Contexts _contexts;
        public MainPageSteps(Contexts context)
        {
            _contexts = context;
        }

        [Given(@"I sucessfully login and redirected to the product list page")]
        public void GivenISucessfullyLoginAndRedirectedToTheProductListPage()
        {
            _contexts.chromeDriver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _contexts.loginPageObject.Login("standard_user", "secret_sauce");
            _contexts.loginPageObject.ClickLogin();
            _contexts.loginPageObject.TestIfLoginPassed();
        }

        [Given(@"I press the add to cart button")]
        public void GivenIPressTheAddToCartButton()
        {
            _contexts.mainPageObject.AddProductAtIndexOf(0);
        }

        [Then(@"Button text should change to REMOVE and the cart number should be updated")]
        public void ThenButtonTextShouldChangeToREMOVEAndTheCartNumberShouldBeUpdated()
        {
            _contexts.mainPageObject.ButtonTextRemoveAndCartUpdated(0);
            Dispose();
        }

        [Given(@"I press the remove button on the first product")]
        public void GivenIPressTheRemoveButton()
        {
            _contexts.mainPageObject.RemoveProductAtIndexOf(0);
        }

        [Then(@"Button text should change to ADD TO CART and the cart number should be updated")]
        public void ThenButtonTextShouldChangeToADDTOCARTAndTheCartNumberShouldBeUpdated()
        {
            _contexts.mainPageObject.ButtonTextADDTOCARTAndCartUpdated(0);
            Dispose();
        }
        [Given(@"I add the first product to the cart")]
        public void GivenIAddTheFirstProductToTheCart()
        {
            _contexts.mainPageObject.AddProductAtIndexOf(0);
        }


        [Given(@"I press the option Z-A on the filter dropdown list")]
        public void GivenIPressTheOptionZ_AOnTheFilterDropdownList()
        {
            _contexts.mainPageObject.ChangeFilter("za");
        }

        [Given(@"I press the option HI-LO on the filter dropdown list")]
        public void GivenIPressTheOptionHI_LOOnTheFilterDropdownList()
        {
            _contexts.mainPageObject.ChangeFilter("hilo");
        }

        [Given(@"I press the option LO-HI on the filter dropdown list")]
        public void GivenIPressTheOptionLO_HIOnTheFilterDropdownList()
        {
            _contexts.mainPageObject.ChangeFilter("lohi");
        }
        [Then(@"Products should be filtered by Z-A option")]
        public void ThenProductsShouldBeFilteredByZ_AOption()
        {
            _contexts.mainPageObject.CheckIfPageFiltered("za");
            Dispose();
        }

        [Then(@"Products should be filtered by HI-LO option")]
        public void ThenProductsShouldBeFilteredByHI_LOOption()
        {
            _contexts.mainPageObject.CheckIfPageFiltered("hilo");
            Dispose();
        }

        [Then(@"Products should be filtered by LO-HI option")]
        public void ThenProductsShouldBeFilteredByLO_HIOption()
        {
            _contexts.mainPageObject.CheckIfPageFiltered("lohi");
            Dispose();
        }


        public void Dispose()
        {
            //Closing chrome
            _contexts.chromeDriver.Quit();
        }
    }
}
