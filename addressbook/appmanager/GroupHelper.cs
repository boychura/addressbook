 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
    public class GroupHelper : BaseHelper
    {

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            if (!IsGroupPresent(v))
            {
                Create(group);
            }
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupMofifcation();
            manager.Navigator.GoToGroupPage();

            return this;
        }

        public GroupHelper Remove(int p, GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            if (!IsGroupPresent(p))
            {
                Create(group);
            }
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }


        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("/html/body/div/div[4]/form/span[" + index + "]/input")).Click();
            return this;
        }

        private bool IsGroupPresent(int index)
        {
            return IsElementPresent(By.XPath("/html/body/div/div[4]/form/span[" + index + "]/input"));
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper SubmitGroupMofifcation()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
