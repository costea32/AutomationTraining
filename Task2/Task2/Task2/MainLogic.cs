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
            LoginPage.LoginAs(username).WithPassword(password).Login();

            getBranches();

            foreach (Branch branch in branches)
            {
                Driver.Instance.Url = branch.url;
                getFilesFoldersFor(branch);
            }

            return branches;
        }

        public void getBranches()
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

        public void getFilesFoldersFor(Container container)
        {
            ContentPage page = new ContentPage();
            int nrOfItems = page.getNrOfItems();
            container.Children = new List<Container>();

            for (int i = 0; i < nrOfItems; i++)
                {
                    if (page.getType(i) == "Folder")
                    {
                        string tempName = page.getName(i);
                        container.Children.Add(new Folder(page.getName(i), page.getComment(i), page.getLastUpdated(i)));
                        string tempUrl = page.getUrl();
                        page.setUrl(tempUrl + "/" + page.getName(i));
                        getFilesFoldersFor(container.Children.Find(x => (x.name == tempName)));
                        page.setUrl(tempUrl);
                        page.updateTable();
                    }
                    else
                    {
                        container.Children.Add(new File1(page.getName(i), page.getComment(i), page.getLastUpdated(i)));
                    }

                }
        }
    }
}
