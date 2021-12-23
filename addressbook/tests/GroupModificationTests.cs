using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

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

            app.Groups.Modify(1, group);
        }

    }
}
