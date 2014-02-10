using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Task2v2
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://github.com/login");

            LoginPage Login = new LoginPage(driver);
            BranchesPage Branches = Login.Do("alina-goncearenco", "MyPassword1");

            List<Branch> ListOfBranches = new List<Branch>();
            ListOfBranches = Branches.GetListOfBranches();

            driver.Close();
            Console.WriteLine("\nTest finished!");
            Console.ReadLine();
        }
    }
}
