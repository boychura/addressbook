using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            applicationManager.Contact.SelectContact(1);
            applicationManager.Contact.InitContactRemove();
            applicationManager.Contact.AcceptContactRemove();
            applicationManager.Navigator.GoBackToMain();
            applicationManager.Auth.LogOut();
        }
    }
}
