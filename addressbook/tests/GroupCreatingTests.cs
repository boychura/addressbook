using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class GroupCreatingTests : AuthTestBase
    {
        [Test]
        public void GroupCreateTestCase()
        {
            GroupData group = new GroupData("table_name");
            group.Header = "table_header";
            group.Footer = "table_footer";

            app.Groups.Create(group);
        }
    }
}
