using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task2.Selenium;

namespace Task2
{
    public class MainLogic
    {
        #region 1
        String username = "stepka.k@gmail.com";
        String password = "Password123";

        #endregion
        public List<Container> GetAllStuff()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs(username).WithPassword(password).Login();

            List<Container> branches = GetBranches();

            foreach (Branch branch in branches)
            {
                Driver.Instance.Url = branch.url;
                GetFilesFoldersFor(branch);
            }

            return branches;
        }

        public List<Container> GetBranches()
        {
            List<Container> branches = new List<Container>();
            BranchPage.GoTo();
            BranchPage bp = new BranchPage();

            int nrOfBranches = bp.GetNrOfBranches();

            for (int i = 6; i < nrOfBranches; i++)
            {
                branches.Add(new Branch(bp.GetName(i), bp.GetBehind(i), bp.GetAhead(i), bp.GetUrl(i)));
            }

            return branches;

        }

        public void GetFilesFoldersFor(Container container)
        {
            ContentPage page = new ContentPage();
            int nrOfItems = page.GetNrOfItems();
            container.Children = new List<Container>();

            for (int i = 0; i < nrOfItems; i++)
                {
                    if (page.GetType(i) == "Folder")
                    {
                        string tempName = page.GetName(i);
                        container.Children.Add(new Folder(page.GetName(i), page.GetComment(i), page.GetLastUpdated(i)));
                        string tempUrl = page.GetUrl();
                        page.SetUrl(tempUrl + "/" + page.GetName(i));
                        GetFilesFoldersFor(container.Children.Find(x => (x.name == tempName)));
                        page.SetUrl(tempUrl);
                        page.UpdateTable();
                    }
                    else
                    {
                        container.Children.Add(new File1(page.GetName(i), page.GetComment(i), page.GetLastUpdated(i)));
                    }

                }
        }
    }
}
