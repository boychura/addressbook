using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTestCase()
        {
            UserBio user = new UserBio("ser_modificated", "boy_modificated");

            List<UserBio> oldContacts = app.Contact.GetContactList();

            app.Contact.StartCheckContacts(0, user);
            app.Contact.ModifyContact(0, user);
            app.Navigator.GoBackToMain();

            List<UserBio> newContacts = app.Contact.GetContactList();
            oldContacts[0].Name = user.Name;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
