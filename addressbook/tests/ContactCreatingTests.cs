using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class ContactCreatingTests : TestBase
    {
        [Test]
        public void ContactCreatingTK()
        {
            UserBio user = new UserBio("ser", "boy");

            applicationManager.Contact.InitContactCreate();
            applicationManager.Contact.FillContactForm(user);
            applicationManager.Contact.SumbitContactCreating();
            applicationManager.Navigator.GoBackToMain();
            applicationManager.Auth.LogOut();
        }
    }
}