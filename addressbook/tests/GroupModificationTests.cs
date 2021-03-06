using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTestCase()
        {
            GroupData group = new GroupData("table_name_modified");
            group.Header = "table_header_modified";
            group.Footer = "table_footer_modified";

            app.Groups.StartCheckGroups(0, group);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(oldData, group);
            //check groups count
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupIndex in newGroups)
            {
                if (groupIndex.Id == oldData.Id)
                {
                    Assert.AreEqual(group.Name, groupIndex.Name);
                }
            }
        }

    }
}
