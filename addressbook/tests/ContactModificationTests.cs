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

            app.Contact.ModifyContact(1, user);
            app.Navigator.GoBackToMain();
        }
    }
}
