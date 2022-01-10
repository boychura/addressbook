using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
    public class ContactHelper : BaseHelper
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper InitContactCreate()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper RemoveContact(int v)
        {
            SelectContact(v);
            InitContactRemove();
            AcceptContactRemove();

            return this;
        }

        public ContactHelper StartCheckContacts(int v, UserBio user)
        {
            if (!IsContactExist(v))
            {
                CreateContact(user);
            }

            return this;
        }

        public ContactHelper CreateContact(UserBio user)
        {
            InitContactCreate();
            FillContactForm(user);
            SumbitContactCreating();

            return this;
        }

        public ContactHelper ModifyContact(int v, UserBio user)
        {
            EditContact(v);
            FillContactForm(user);
            SumbitContactEditing();

            return this;
        }

        public ContactHelper FillContactForm(UserBio user)
        {
            Type(By.Name("firstname"), user.Name);
            Type(By.Name("lastname"), user.Surname);

            return this;
        }

        public ContactHelper SumbitContactCreating()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;//cache clear
            return this;
        }
        public ContactHelper SumbitContactEditing()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;//cache clear
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[" + (index + 1) + "]/input")).Click();
            return this;
        }

        private bool IsContactExist(int index)
        {
            return IsElementPresent(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[" + (index + 1) + "]/input"));
        }
        
        public ContactHelper InitContactRemove()
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/div[2]/input")).Click();
            return this;
        }
        public ContactHelper AcceptContactRemove()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;//cache clear
            return this;
        }
        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[" + (index + 2) + "]/td[8]/a/img")).Click();
            return this;
        }

        //cache create
        private List<UserBio> contactCache = null;
        public List<UserBio> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<UserBio>();
                manager.Navigator.GoBackToMain();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    IWebElement surname = element.FindElement(By.CssSelector("td:nth-child(2)"));
                    IWebElement name = element.FindElement(By.CssSelector("td:nth-child(3)"));
                    contactCache.Add(new UserBio(name.Text, surname.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<UserBio>(contactCache);//return copy of cashe(original cashe can be changed outside)
        }
        internal int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count();
        }
    }
}
