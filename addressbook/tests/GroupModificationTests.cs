using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTestCase()
        {
            GroupData group = new GroupData("table_name_modified");
            group.Header = "table_header_modified";
            group.Footer = "table_footer_modified";

            applicationManager.Groups.Modify(1, group);
        }

    }
}
