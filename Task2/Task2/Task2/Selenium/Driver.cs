using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Task2.Selenium
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new ChromeDriver(@"c:/Selenium/");
        }

        public static void Close()
        {
            Instance.Close();
        }
    }
}
