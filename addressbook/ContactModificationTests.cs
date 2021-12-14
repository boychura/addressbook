using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTestCase()
        {
            UserBio user = new UserBio("ser_modificated", "boy_modificated");

            applicationManager.Contact.EditContact(1);
            applicationManager.Contact.FillContactForm(user);
            applicationManager.Contact.SumbitContactEditing();
            applicationManager.Navigator.GoBackToMain();
            applicationManager.Auth.LogOut();
        }
    }
}
