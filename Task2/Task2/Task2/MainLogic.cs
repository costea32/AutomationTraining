using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task2.Selenium;
using OpenQA.Selenium;

namespace Task2
{
    public class MainLogic
    {
        #region 1
        String username = "stepka.k@gmail.com";
        String password = "Password123";

        #endregion
        public List<Branch> branches;

        public List<Branch> getAllStuff()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs(username).WithPassword(password);

            AddBranches();

            foreach (Branch branch in branches)
            {
                Driver.Instance.Url = branch.url;
                AddFilesFolders(branch);
            }

            return branches;
        }

        public void AddBranches()
        {
            branches = new List<Branch>();
            BranchPage.GoTo();
            BranchPage bp = new BranchPage();

            int nrOfBranches = bp.getNrOfBranches();

            for (int i = 0; i < nrOfBranches; i++)
            {
                branches.Add(new Branch(bp.getName(i), bp.getBehind(i), bp.getAhead(i), bp.getUrl(i)));
            }
        }

        public void AddFilesFolders(Container container)
        {
            int nrOfItems = getNrOfItems();

            getItems();

            for (int i = 0; i < nrOfItems; i++)
                {
                    if (i == 0) container.Children = new List<Container>();
                    string name;
                    try
                    {
                        name = names[i].Text;
                    }
                    catch
                    {
                        getItems();
                        name = names[i].Text;
                    }
                    string type;
                    string url;

                    if (names[i].GetAttribute("href").Contains("blob"))
                    {
                        url = driver.Url;
                        type = "File";
                    }
                    else
                    {
                        type = "Folder";
                        url = driver.Url + "/" + name;
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
                        container.Children.Add(new File1(name, comment, lastUpdated));
                    }

                }
        }

        public void getItems()
        {
//            IWebElement element = wait.Until<IWebElement>((d) =>
//            {
//                return d.FindElement(By.ClassName("js-directory-link"));
//            });
            names = driver.FindElements(By.ClassName("js-directory-link"));
            comments = driver.FindElements(By.ClassName("message"));
            lastUpdates = driver.FindElements(By.ClassName("js-relative-date"));
        }


        public int getNrOfBranches()
        {
           // return driver.FindElements(By.ClassName("state-widget")).Count();
            return 1;
        }


        public int getNrOfItems()
        {
            return driver.FindElements(By.ClassName("age")).Count();
        }
    }
}
