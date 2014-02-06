using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;


namespace ObjectMap
{
    public class BranchesPage : Page
    {
        private IWebDriver _browser;
        private string _uri = @"https://github.com/costea32/AutomationTraining/branches";

        public BranchesPage(RemoteWebDriver browser)
            : base(browser)
        {
            _browser = browser;
        }

        public void Launch()
        {
            _browser.Navigate().GoToUrl(_uri);
        }

    }
}
