using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace UITest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] branches;
            List<ChromeWebElement> elements = new List<ChromeWebElement>();

            IWebDriver driver = new ChromeDriver(@"C:\Users\culpini\Documents\chromedriver_win32");
            try
            {
                driver.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");
                IWebElement element = driver.FindElement(By.XPath("//*[@id=\"js-repo-pjax-container\"]/table[2]/tbody/tr[1]/td[1]/h3/a"));
                string str = element.GetAttribute("href");
                Console.WriteLine(str);
            }
            finally
            {
                //driver.Close();
            }
        }
    }
}
