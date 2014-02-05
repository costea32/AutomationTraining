using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task2
{
    public class SeleniumLogic
    {
        IWebDriver driver;
        WebDriverWait wait;

        IList<IWebElement> names;
        IList<IWebElement> comments;
        IList<IWebElement> lastUpdates;

        public List<Container> branches;

        public void Do()
        {

            //
            // Login
            //

            #region 1
            String username = "";
            String password = "";

            #endregion
            driver = new ChromeDriver("C:/Selenium/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Url = "https://github.com/login";
            driver.FindElement(By.Id("login_field")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Name("commit")).Submit();

            driver.Url = "https://github.com/costea32/AutomationTraining/branches";

            //
            // Add branches
            //

            AddBranches();

            //
            // Add the rest
            //

            foreach (Branch branch in branches)
            {
                driver.Url = branch.url;
                AddFilesFolders(branch);
            }

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(100));
            driver.Close();
        }

        public void AddBranches()
        {
            branches = new List<Container>();

            int nrOfBranches = getNrOfBranches();

            IList<IWebElement> names = driver.FindElements(By.ClassName("css-truncate-target"));
            IList<IWebElement> behindAheads = driver.FindElements(By.TagName("em"));

            for (int i = 0; i < nrOfBranches; i++)
            {
                branches.Add(new Branch(names[i].Text, behindAheads[2*i].Text, behindAheads[2*i+1].Text,"https://github.com/costea32/AutomationTraining/tree/" + names[i].Text));
            }
        }

        public void AddFilesFolders(Container container)
        {
            int nrOfItems = getNrOfItems();

            getItems();

            for (int i = 0; i < nrOfItems; i++)
                {
                    if (i == 0) container.Children = new List<Container>();
                    string name = names[i].Text;
                    string type;
                    string url;
                    if (names[i].GetAttribute("href").Contains("tree"))
                    {
                        type = "Folder";
                        url = driver.Url + "/" + name;
                    }
                    else
                    {
                        url = driver.Url;
                        type = "File";
                    }

                    string comment = comments[i].Text;
                    string lastUpdated = lastUpdates[i].Text;

                    if (type == "Folder")
                    {
                        container.Children.Add(new Folder(name, comment, lastUpdated));
                        string previousUrl = driver.Url;
                        driver.Url = url;
                        AddFilesFolders(container.Children.Find(x => (x.name == name)));
                        driver.Url = previousUrl;
                        getItems();
                    }
                    else
                    {
                        container.Children.Add(new File(name, comment, lastUpdated));
                    }

                }
        }

        public void getItems()
        {
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.ClassName("js-directory-link"));
            });
            names = driver.FindElements(By.ClassName("js-directory-link"));
            comments = driver.FindElements(By.ClassName("message"));
            lastUpdates = driver.FindElements(By.ClassName("js-relative-date"));
        }


        public int getNrOfBranches()
        {
            return driver.FindElements(By.ClassName("state-widget")).Count();
        }


        public int getNrOfItems()
        {
            return driver.FindElements(By.ClassName("age")).Count();
        }
    }
}
