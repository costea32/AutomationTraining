using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting;
using OpenQA;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Task2
{
    class UIHelpers
    {
        public static FirefoxDriver RestartBrowser(string URL = "about:blank")
        {

            //Console.WriteLine("Restart browser ! Uri : " + URL);
            //Playback.Wait(3000);
            //foreach (Process process in Process.GetProcesses())
            //    if (process.ProcessName.StartsWith("firefox"))
            //        process.Kill();
            //Playback.Wait(2000);

            FirefoxDriver browser;
            try
            {
                var capabilities = DesiredCapabilities.Firefox();
                capabilities.SetCapability("ensureCleanSession", true);
                //var opt = new ChromeOptions();
                //opt.AddAdditionalCapability("ensureCleanSession", true);
                browser = new FirefoxDriver(capabilities);
                browser.Navigate().GoToUrl(URL);
            }
            catch (InvalidCastException) { browser = RestartBrowser(URL); }

            return browser;
        }

        public static string randomString(int n, bool num = false)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random(DateTime.Now.Millisecond);
            char ch;

            for (int i = 0; i < n; i++)
            {
                int m = random.Next(26);
                if (m % 2 == 0)
                    ch = (char)('a' + m);
                else
                    ch = (char)('A' + m);
                sb.Append(ch);
            }

            if (num)
                sb.Append("1");

            return sb.ToString();
        }

    }
}
