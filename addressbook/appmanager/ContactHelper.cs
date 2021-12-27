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

        public ContactHelper RemoveContact(int v, UserBio user)
        {
            if (!IsContactExist(v))
            {
                CreateContact(user);
            }
            SelectContact(v);
            InitContactRemove();
            AcceptContactRemove();

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
            if (!IsContactExist(v))
            {
                CreateContact(user);
            }
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
            return this;
        }
        public ContactHelper SumbitContactEditing()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[" + index + "]/input")).Click();
            return this;
        }

        private bool IsContactExist(int index)
        {
            return IsElementPresent(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[2]/td[" + index + "]/input"));
        }
        
        public ContactHelper InitContactRemove()
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/div[2]/input")).Click();
            return this;
        }
        public ContactHelper AcceptContactRemove()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form[2]/table/tbody/tr[" + (index + 1) + "]/td[8]/a/img")).Click();
            return this;
        }
    }
}
