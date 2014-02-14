using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Iheritance_Web_subproject_rework
{
    class Context
    {
        private IPageStrategy strategy;
        private IWebDriver driver;

        public Context(IPageStrategy strategy,IWebDriver driver)
        {
            this.strategy = strategy;
            this.driver = driver;
        }

        public void SetStrategy(IPageStrategy strategy,IWebDriver driver)
        {
            this.strategy = strategy;
            this.driver = driver;
        }

        public void ExecuteOperations()
        {
            this.strategy.Algorithm(driver);
        }
    }
}
