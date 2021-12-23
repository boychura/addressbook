using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            app.Contact.SelectContact(1);
            app.Contact.InitContactRemove();
            app.Contact.AcceptContactRemove();
            app.Navigator.GoBackToMain();
        }
    }
}
