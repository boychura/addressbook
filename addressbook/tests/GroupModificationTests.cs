using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTestCase()
        {
            GroupData group = new GroupData("table_name_modified");
            group.Header = "table_header_modified";
            group.Footer = "table_footer_modified";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.StartCheckGroups(0, group);
            app.Groups.Modify(0, group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
