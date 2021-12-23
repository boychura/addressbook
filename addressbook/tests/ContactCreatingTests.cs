﻿using System;
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
            UserBio user = new UserBio("ser", "boy");

            app.Contact.InitContactCreate();
            app.Contact.FillContactForm(user);
            app.Contact.SumbitContactCreating();
            app.Navigator.GoBackToMain();
        }
    }
}