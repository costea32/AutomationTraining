using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;

using OpenQA;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using ObjectMap;
using Serializer;
using System.Diagnostics;

namespace Task2
{
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        private FirefoxDriver browser;

        [TestMethod]
        public void CodedUITestMethod1()
        {
            var baseUri = @"https://github.com";

            browser.Navigate().GoToUrl(baseUri + "/costea32/AutomationTraining/branches");

            // Find branches
            var branchAnchorsList = browser
                .FindElementsByCssSelector("table.branches")[1]
                .FindElements(By.CssSelector("tbody tr td h3 a"));

            // Iterate through branches and create a hierarchy of all folders and files for each branch
            for (int i = 0; i < branchAnchorsList.Count; i++)
            {
                var branchAnchor = branchAnchorsList[i];
                var listFile = new StreamWriter(Directory.GetCurrentDirectory() + "\\" + "FileList.txt", true);
                string branchTitle = null;

                try { branchTitle = branchAnchor.Text; }
                catch (StaleElementReferenceException)
                {
                    branchAnchorsList = browser
                        .FindElementsByCssSelector("table.branches")[1]
                        .FindElements(By.CssSelector("tbody tr td h3 a"));
                    branchAnchor = branchAnchorsList[i];
                    branchTitle = branchAnchor.Text;
                }

                listFile.WriteLine("------ " + branchTitle + " ------");
                browser.Navigate().GoToUrl(branchAnchor.GetAttribute("href"));

                // Run a recursive method that creates a list of files/folders in a .txt file
                FileListGenerator(baseUri, listFile);
                browser.Navigate().Back();
                listFile.Close();
            }
        }


        private void FileListGenerator(string baseUri, StreamWriter listFile, string trail = "")
        {
            var tRows = browser.FindElementByCssSelector("table.files")
                .FindElement(By.CssSelector("tbody[data-url*=costea32]"))
                .FindElements(By.TagName("tr"));

            for (int i = 0; i < tRows.Count; i++)
            {
                var tRow = tRows[i];
                IWebElement anchorElement = null;
                try
                {
                    anchorElement = tRow.FindElement(By.CssSelector("td.content span a"));
                }
                catch (StaleElementReferenceException)
                {
                    tRows = browser.FindElementByCssSelector("table.files")
                        .FindElement(By.CssSelector("tbody[data-url*=costea32]"))
                        .FindElements(By.TagName("tr"));
                    tRow = tRows[i];
                    anchorElement = tRow.FindElement(By.CssSelector("td.content span a"));
                }
                var iconElement = tRow.FindElement(By.CssSelector("td.icon span"));

                if (iconElement.GetAttribute("class").Contains("octicon-file-directory"))
                {
                    var folderName = anchorElement.Text + "/";
                    listFile.WriteLine(trail + folderName);

                    browser.Navigate().GoToUrl(anchorElement.GetAttribute("href"));
                    FileListGenerator(baseUri, listFile, trail + folderName);
                    browser.Navigate().Back();
                }
                else
                    listFile.WriteLine(trail + anchorElement.Text);
            }

            #region crap
            //var filesTableBodies = browser.FindElementByCssSelector("table.files").FindElements(By.TagName("tbody"));
            //ICollection<IWebElement> filesTableRows = null;
            //if (filesTableBodies.Count > 0)
            //    foreach (var tbody in filesTableBodies)
            //    {
            //        filesTableRows = tbody.FindElements(By.TagName("tr"));
            //        if (filesTableRows.Count > 0)
            //            foreach (var tableRow in filesTableRows)
            //            {
            //                var anchorElements = tableRow.FindElements(By.CssSelector("td.content span a"));
            //                if (anchorElements.Count > 0)
            //                {
            //                    var anchorElement = anchorElements[0];
            //                    var iconSpanElement = tableRow.FindElement(By.CssSelector("td.icon span"));

            //                    if (iconSpanElement.GetAttribute("class").Contains("octicon-file-directory"))
            //                    {
            //                        trail += anchorElement.Text + "/";
            //                        listFile.WriteLine(trail);

            //                        browser.Navigate().GoToUrl(anchorElement.GetAttribute("href"));
            //                        FileListGenerator(baseUri, listFile, trail);
            //                    }
            //                    else
            //                        listFile.WriteLine(trail + anchorElement.Text);
            //                }
            //            }
            //    }
            #endregion
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            browser = UIHelpers.RestartBrowser();
        }

        //[TestCleanup()]
        ////public void MyTestCleanup()
        //{
        //    browser.Quit();
        //    if (File.Exists(Directory.GetCurrentDirectory() + "\\" + "FileList.txt"))
        //        Process.Start(Directory.GetCurrentDirectory() + "\\" + "FileList.txt");

        //}
    }
}
