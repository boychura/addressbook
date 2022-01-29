using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {
        [Test]
        public void ContactInformationTK()
        {
            UserBio fromTable = app.Contact.GetContactInformationFromTable(0);
            UserBio fromForm = app.Contact.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
        }
    }
}