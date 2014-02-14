using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text;
//
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Iheritance_Web_subproject_rework
{   
    class Program
    {        
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            try
            {
                //Source Page
                //driver.Url = "https://github.com/costea32/AutomationTraining/tree/ikulpin/Task1/Task1.Test";
                //Context page = new Context(new SourceStrategy(), driver);
                //page.ExecuteOperations();

                
                //Branches Page
                driver.Url = "https://github.com/costea32/AutomationTraining/branches";
                Context page = new Context(new BranchStrategy(),driver);
                page.ExecuteOperations();

            }
            finally
            {
                driver.Quit();
                Console.WriteLine("All done!");
            }
            Console.ReadLine();   
        }   
    }
}
