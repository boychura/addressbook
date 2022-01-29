using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTestCase()
        {
            GroupData group = new GroupData("table_name_deleted");
            group.Header = "table_header_deleted";
            group.Footer = "table_footer_deleted";

            app.Groups.StartCheckGroups(0, group);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];//saving 1-st element in list before changes

            app.Groups.Remove(oldData);
            //check groups count
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);//удаление элемента с первого списка груп(так как он удален тестом)
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupIndex in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldData.Id);
            }
        }
    }
}
