using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace Task2.Selenium
{
    public class LoginPage
        {
            public static void GoTo()
            {
                Driver.Instance.Navigate().GoToUrl("https://github.com/login");
            }

            public static LoginCommand LoginAs(string userName)
            {
                return new LoginCommand(userName);
            }
        }

        public class LoginCommand
        {
            private readonly string userName;
            private string password;

            public LoginCommand(string userName)
            {
                this.userName = userName;
            }

            public LoginCommand WithPassword(string password)
            {
                this.password = password;
                return this;
            }

            public void Login()
            {
                var loginInput = Driver.Instance.FindElement(By.Id("login_field"));
                loginInput.SendKeys(userName);

                var passwordInput = Driver.Instance.FindElement(By.Id("password"));
                passwordInput.SendKeys(password);

                var loginButton = Driver.Instance.FindElement(By.Name("commit"));
                loginButton.Click();
            }
     }
}
