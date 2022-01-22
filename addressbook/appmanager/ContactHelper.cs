using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

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

        public UserBio GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToMainPage();
            OpenContactDetails(index);
            string credentials = driver.FindElement(By.Id("content"))
                .FindElement(By.TagName("b")).Text;
            string[] subs = credentials.Split(' ');
            string firstName = subs[0];//text is in 'value'
            string lastName = subs[1];


            char[] dividerMain = { '\r', '\n' };
            char[] dividerMobile = { 'M', ':', ' ' };
            char[] dividerWork = { 'W', ':', ' ' };

            string [] allData = driver.FindElement(By.Id("content")).Text.Split(dividerMain);

            string address = allData[2];

            string mobilePhone = allData[6].Trim(dividerMobile);
            string workPhone = allData[8].Trim(dividerWork);

            string email = driver.FindElement(By.Id("content"))
                .FindElement(By.TagName("a")).Text;

            return new UserBio(firstName, lastName)
            {
                Address = address,
                Email = email,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        public UserBio GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToMainPage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new UserBio(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }
        public UserBio GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToMainPage();
            EditContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");//text is in 'value'
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new UserBio(firstName, lastName)
            {
                Address = address,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
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
            Type(By.Name("address"), user.Address);
            Type(By.Name("home"), user.HomePhone);
            Type(By.Name("mobile"), user.MobilePhone);
            Type(By.Name("work"), user.WorkPhone);
            Type(By.Name("email"), user.Email);

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
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
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

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToMainPage();
            string text = driver.FindElement(By.Id("search_count")).Text;
            return Int32.Parse(text);
        }

        public ContactHelper OpenContactDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }
    }
}
