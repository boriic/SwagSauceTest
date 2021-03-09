using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.Methods
{
    public static class MainPageSetMethods
    {
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
            new SelectElement(element).SelectByValue(value);
        }
    }
}
