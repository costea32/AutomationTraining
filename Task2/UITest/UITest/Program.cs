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
            IWebDriver driver = new ChromeDriver(@"C:\Users\culpini\Documents\chromedriver_win32");
            driver.Navigate().GoToUrl("http://mail.ru");
        }
    }
}
