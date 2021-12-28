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
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupPage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData group)
        {
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

        public GroupHelper Remove(int p)
        {
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper StartCheckGroups(int p, GroupData group)
        {
            if (!IsGroupPresent(p))
            {
                Create(group);
            }
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
            driver.FindElement(By.XPath("/html/body/div/div[4]/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }

        private bool IsGroupPresent(int index)
        {
            return IsElementPresent(By.XPath("/html/body/div/div[4]/form/span[" + (index + 1) + "]/input"));
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
        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupPage();
            //find all elements in 'span.group'(FindElements return <IWebElement> type)
            //IColection is general list(collection) type in C#
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));//add each element to 'groups' list one by one
            }

            return groups;
        }
    }
}
