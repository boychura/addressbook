using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTestCase()
        {
            UserBio user = new UserBio("ser_modificated", "boy_modificated");

            app.Contact.StartCheckContacts(0, user);

            List<UserBio> oldContacts = UserBio.GetAll();
            UserBio oldData = oldContacts[0];

            app.Contact.ModifyContact(oldData, user);
            app.Navigator.GoBackToMain();
            //check contacts count
            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            List<UserBio> newContacts = UserBio.GetAll();
            oldContacts[0].Name = user.Name;
            oldContacts[0].Surname = user.Surname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (UserBio userIndex in newContacts)
            {
                if (userIndex.Id == oldData.Id)
                {
                    Assert.AreEqual(user.Name, userIndex.Name);
                }
            }
        }
    }
}
