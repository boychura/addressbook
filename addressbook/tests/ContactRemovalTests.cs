using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTestCase()
        {
            UserBio user = new UserBio("deleted_name", "deleted_surname");

            List<UserBio> oldContacts = app.Contact.GetContactList();

            app.Contact.StartCheckContacts(0, user);
            app.Contact.RemoveContact(0);
            app.Navigator.GoBackToMain();

            List<UserBio> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
