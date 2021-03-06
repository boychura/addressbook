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

            app.Contact.StartCheckContacts(0, user);

            List<UserBio> oldContacts = UserBio.GetAll();
            UserBio oldData = oldContacts[0];

            app.Contact.RemoveContact(oldData);
            app.Navigator.GoBackToMain();
            //check contacts count
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<UserBio> newContacts = UserBio.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            //checking ID
            foreach (UserBio userIndex in newContacts)
            {
                Assert.AreNotEqual(user.Id, oldData.Id);
            }
        }
    }
}
