using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class GroupCreatingTests : TestBase
    {
        [Test]
        public void GroupCreateTestCase()
        {
            GroupData group = new GroupData("table_name");
            group.Header = "table_header";
            group.Footer = "table_footer";

            applicationManager.Groups.Create(group);
            applicationManager.Auth.LogOut();
        }
    }
}
