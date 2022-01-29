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

        public GroupHelper Modify(GroupData groupData, GroupData group)
        {
            if (!IsGroupPresent(groupData.Id))
            {
                Create(group);
            }
            SelectGroup(groupData.Id);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupMofifcation();
            manager.Navigator.GoToGroupPage();

            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();

            return this;
        }

        public GroupHelper StartCheckGroups(int p, GroupData group)
        {
            manager.Navigator.GoToGroupPage();
            if (!IsGroupPresent(p))
            {
                Create(group);
            }
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;//clear chache
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
            driver.FindElement(By.XPath("//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]' and @value=" + id + "]")).Click();
            return this;
        }

        private bool IsGroupPresent(int index)
        {
            return IsElementPresent(By.XPath("/html/body/div/div[4]/form/span[" + (index + 1) + "]/input"));
        }

        private bool IsGroupPresent(string id)
        {
            return IsElementPresent(By.XPath("//input[@name='selected[]' and @value=" + id + "]"));
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;//clear chache
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
            groupCache = null;//clear chache
            return this;
        }

        //cache create
        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupPage();
                //find all elements in 'span.group'(FindElements return <IWebElement> type)
                //IColection is general list(collection) type in C#
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {      
                    groupCache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")//add ID to list
                    });
                }
            }
            return new List<GroupData>(groupCache);//return copy of cashe(original cashe can be changed outside)
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count();
        }
    }
}
