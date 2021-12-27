using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTestCase()
        {
            GroupData group = new GroupData("table_name_deleted");
            group.Header = "table_header_deleted";
            group.Footer = "table_footer_deleted";

            app.Groups.Remove(1, group);
        }
    }
}
