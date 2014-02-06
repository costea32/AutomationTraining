using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace ObjectMap
{
    public abstract class Page
    {
        private IWebDriver _browser;

        public Page(RemoteWebDriver browser)
        {
            _browser = browser;
        }

    }
}
