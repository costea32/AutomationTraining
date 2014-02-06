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
            driver.Url = "https://github.com/login";            

            //Need to close fiddler!

            IWebElement login = driver.FindElement(By.Id("login_field"));
            login.SendKeys(username);

            IWebElement pass = driver.FindElement(By.Id("password"));
            pass.SendKeys(password);
            pass.SendKeys(Keys.Enter);

            driver.Navigate().GoToUrl("https://github.com/costea32/AutomationTraining/branches");

//            int countBranches = driver.FindElements(By.XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]/tbody/tr")).Count;
            int countBranches = driver.FindElements(By.ClassName("css-truncate")).Count;
            
            List<IWebElement> bnames = driver.FindElements(By.ClassName("css-truncate")).ToList();
            List<IWebElement> bbehinds = driver.FindElements(By.XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]/tbody/tr/td[@class = 'state-widget']/div/span[@class = 'behind']/em")).ToList();
            List<IWebElement> baheads = driver.FindElements(By.XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]/tbody/tr/td[@class = 'state-widget']/div/span[@class = 'ahead']/em")).ToList();

            List<Branch> branches = new List<Branch>();

            string bname;
            int bbehind;
            int bahead;
            string blink;

            for (int i = 0; i < countBranches; i++ )
            {
//                bname = driver.FindElement(By.XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]/tbody/tr[" + (i+1) + "]/td[@class = 'name']/h3/a")).Text;
                bname = bnames[i].Text;
//                bbehind = Int32.Parse(driver.FindElement(By.XPath("/html/body/div/div[3]/div[2]/div/div[2]/table[2]/tbody/tr[" + (i+1) + "]/td[@class = 'state-widget']/div/span[@class = 'behind']/em")).Text.Substring(0,1));
                bbehind = Int32.Parse(bbehinds[i].Text.Substring(0, 2));
                bahead = Int32.Parse(baheads[i].Text.Substring(0, 2));
                blink = "https://github.com/costea32/AutomationTraining/tree/" + bname;
                branches.Add(new Branch(bname, bbehind, bahead, blink));
            }

            foreach (Branch b in branches)
            {
                driver.Url = b.link;

                int countItems = driver.FindElements(By.ClassName("age")).Count;

                List<IWebElement> icons = driver.FindElement(By.ClassName("files")).FindElements(By.XPath("//tbody/tr/td[@class = 'icon']/span")).ToList();
                List<IWebElement> rnames = driver.FindElements(By.ClassName("js-directory-link")).ToList();
                List<IWebElement> rcomments = driver.FindElement(By.ClassName("files")).FindElements(By.XPath("//tbody/tr/td[@class = 'message']/span/a")).ToList();
                List<IWebElement> rage = driver.FindElement(By.ClassName("files")).FindElements(By.ClassName("js-relative-date")).ToList();

                for (int i = 0; i < countItems; i++)
                {
                    if (icons[i].GetAttribute("class").Contains("directory"))
                    {
                        //add folder
                        Folder ffolder = new Folder(rnames[i].Text, rcomments[i].Text, rage[i].Text, b.link + "/" + rnames[i].Text);

                        b.records.Add(ffolder);                       
                    }

                    else
                    {
                        //add file
                        File ffile = new File(rnames[i].Text, rcomments[i].Text, rage[i].Text);

                        b.records.Add(ffile);                       
                    }
                
                }
 
            }

            driver.Close();

            Console.WriteLine("\nTest finished!");
            Console.ReadLine();
        }
    }
}
