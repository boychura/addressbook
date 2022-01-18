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
        public static IEnumerable<UserBio> RandomContactDataProvider()
        {
            List<UserBio> user = new List<UserBio>();
            for (int i = 0; i < 5; i++)
            {
                user.Add(new UserBio(GenerateRandomString(30))
                {
                    Name = GenerateRandomString(100),
                    Surname = GenerateRandomString(100)
                });
            }
            return user;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreatingTK(UserBio user)
        {
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