using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;

namespace Task2v2
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BranchesPage Do(string UserName, string Password)
        {
            driver.FindElement(By.Id("login_field")).SendKeys(UserName);
            driver.FindElement(By.Id("password")).SendKeys(Password);
            driver.FindElement(By.Name("commit")).Click();

            driver.Navigate().GoToUrl(driver.Url + "costea32/AutomationTraining/branches");

            return new BranchesPage(driver);
        }
    }
}
