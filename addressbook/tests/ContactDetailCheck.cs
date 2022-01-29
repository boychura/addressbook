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
            UserBio fromForm = app.Contact.GetContactInformationFromEditForm(0);
            UserBio fromDetail = app.Contact.GetContactInformationFromDetails(0);


            Assert.AreEqual(fromDetail, fromForm);
            Assert.AreEqual(fromDetail.Address, fromForm.Address);
            Assert.AreEqual(fromDetail.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromDetail.AllEmails, fromForm.AllEmails);
        }
    }
}