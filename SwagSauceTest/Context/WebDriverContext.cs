using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagSauceTest.Context
{
    public class WebDriverContext
    {
        public ChromeDriver chromeDriver;
        public WebDriverContext()
        {
            chromeDriver = new ChromeDriver();
        }

    }
}
