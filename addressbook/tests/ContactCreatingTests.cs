using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class ContactCreatingTests : AuthTestBase
    {
        [Test]
        public void ContactCreatingTK()
        {
            UserBio user = new UserBio("ser1", "boy1");

            List<UserBio> oldContacts = app.Contact.GetContactList();

            app.Contact.CreateContact(user);
            app.Navigator.GoBackToMain();

            List<UserBio> newContacts = app.Contact.GetContactList();
            oldContacts.Add(user);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}