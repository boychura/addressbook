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
            UserBio user = new UserBio("deleted_name", "deleted_surname");

            app.Contact.RemoveContact(1, user);
            app.Navigator.GoBackToMain();
        }
    }
}
