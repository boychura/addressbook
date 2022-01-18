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
            user.Address = "Gagarina str";
            user.HomePhone = "+380(64)2222";
            user.WorkPhone = "+380(64)1234";
            user.Email = "123@mail.ru";

            List<UserBio> oldContacts = app.Contact.GetContactList();

            app.Contact.CreateContact(user);
            app.Navigator.GoBackToMain();
            //check contacts count
            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<UserBio> newContacts = app.Contact.GetContactList();
            oldContacts.Add(user);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}