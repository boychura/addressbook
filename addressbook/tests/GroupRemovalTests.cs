using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTestCase()
        {
            applicationManager.Groups.Remove(1);
        }
    }
}
