using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
    public class NavigationHelper : BaseHelper
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void
            GoToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GoBackToMain()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
