using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTestCase()
        {
            UserBio user = new UserBio("ser_modificated", "boy_modificated");

            app.Contact.EditContact(1);
            app.Contact.FillContactForm(user);
            app.Contact.SumbitContactEditing();
            app.Navigator.GoBackToMain();
        }
    }
}
