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
                branch.children = GetFilesFoldersFor(branch.url);
            }

            return branches;
        }

        public List<Container> GetBranches()
        {
            List<Container> branches = new List<Container>();
            BranchPage.GoTo();
            BranchPage bp = new BranchPage();

            foreach (var row in bp.table.tableRows)
            {
                branches.Add(new Branch(row.name, row.behind, row.ahead, row.url));
            }

            return branches;

        }

        public List<Container> GetFilesFoldersFor(string url)
        {
            ContentPage page = new ContentPage();
            page.SetUrl(url);
            var Children = new List<Container>();
                foreach (var row in page.table.tableRows.Where(x => x.isBack == false))
                {
                    if (row.type == "Folder")
                    {
                        Children.Add(new Folder(row.name, row.comment, row.lastUpdated, row.url));
                    }
                    else
                    {
                        Children.Add(new File1(row.name, row.comment, row.lastUpdated));
                    }
                }
                foreach (Container container in Children)
                {
                    if (container.GetType() == typeof(Folder))
                    {
                        var folderChildren = GetFilesFoldersFor(container.url);
                        container.children = folderChildren;
                    }
                }

            return Children;
        }
    }
}
