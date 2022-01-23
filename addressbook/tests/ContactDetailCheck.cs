using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class ContactDetailCheck : AuthTestBase
    {
        [Test]
        public void ContactDetailCheckTK()
        {
            UserBio fromForm = app.Contact.GetContactInformationFromEditForm(0);
            UserBio fromDetail = app.Contact.GetContactInformationFromDetails(0);

            Assert.AreEqual(fromForm, fromDetail);
        }
    }
}