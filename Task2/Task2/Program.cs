using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
//using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "alina-goncearenco";
            string password = "MyPassword1";
            
//            IWebDriver driver = new InternetExplorerDriver(@"C:\Users\goncharenkoa\Downloads\IEDriverServer_x64_2.39.0");
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("www.github.com/login");            

            //Need to close fiddler!

            IWebElement login = driver.FindElement(By.Id("login_field"));
            login.SendKeys(username);
            login.FindElement(By.Id("password"));
            login.SendKeys(password);
            login.SendKeys(Keys.Enter);

            driver.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");

            ICollection<IWebElement> table = driver.FindElements(By.XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]")); //XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]")
            List<IWebElement> elements = table.ToList();

            driver.Close();

            Console.WriteLine("\nTest finished!");
            Console.ReadLine();
        }
    }
}
