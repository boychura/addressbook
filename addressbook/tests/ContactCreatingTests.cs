using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class ContactCreatingTests : AuthTestBase
    {
        [Test]
        public void ContactCreatingTK()
        {
            UserBio user = new UserBio("ser1", "boy1");

            app.Contact.CreateContact(user);
            app.Navigator.GoBackToMain();
        }
    }
}