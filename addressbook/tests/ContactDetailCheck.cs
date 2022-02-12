using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class ContactDetailCheck : ContactTestBase
    {
        [Test]
        public void ContactDetailCheckTK()
        {
            UserBio fromForm = app.Contact.GetContactInformationFromEditForm(7);
            string fromDetail = app.Contact.GetContactInformationFromDetails(7);

            Assert.AreEqual(fromDetail, fromForm.ConcatAll);
        }
    }
}