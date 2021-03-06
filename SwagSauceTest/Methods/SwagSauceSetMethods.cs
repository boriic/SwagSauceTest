using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.Methods
{
    public static class SwagSauceSetMethods
    {
        /// <summary>
        /// Method used when entering text in to a text field
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        //
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        /// <summary>
        /// Method used for clicking a button, checkbox, option etc
        /// </summary>
        /// <param name="element"></param>
        public static void Click(this IWebElement element)
        {
            element.Click();
        }
        /// <summary>
        /// Selecting value in dropdown
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectFilter(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
    }
}
