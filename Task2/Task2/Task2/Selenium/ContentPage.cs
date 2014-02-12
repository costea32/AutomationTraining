using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class ContentPage
    {
        public Table<ContentPageRow> table { get { return new Table<ContentPageRow>(Driver.Instance.FindElement(By.ClassName("files"))); } }

        public string GetUrl()
        {
            return Driver.Instance.Url;
        }

        public void SetUrl(string url)
        {
            Driver.Instance.Url = url;
        }
    } 
}
