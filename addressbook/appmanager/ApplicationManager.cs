using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Threading.Tasks;

namespace addressbook
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected ContactHelper conctactHelper;
        protected GroupHelper groupHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            conctactHelper = new ContactHelper(this);
            groupHelper = new GroupHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GoToMainPage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver 
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get { return loginHelper; }
        }
        public NavigationHelper Navigator
        {
            get { return navigationHelper; }
        }
        public ContactHelper Contact
        {
            get { return conctactHelper; }
        }
        public GroupHelper Groups
        {
            get { return groupHelper; }
        }
    }
}
