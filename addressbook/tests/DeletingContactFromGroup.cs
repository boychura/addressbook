using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    public class DeletingContactFromGroup : AuthTestBase
    {
        [Test]
        public void TestDeletingContactToGroup()
        {
            List<GroupData> groupList = GroupData.GetAll();
            List<UserBio> contactList = UserBio.GetAll();
            GroupData newGroup = new GroupData("newgroup");
            UserBio newcontact = new UserBio("test_name", "test_surname");

            if (groupList.Count == 0)
            {
                app.Groups.Create(newGroup);

                if (contactList.Count == 0)
                {
                    app.Contact.CreateContact(newcontact);
                    GroupData bufferGroup = GroupData.GetAll()[0];
                    List<UserBio> bufferOldList = bufferGroup.GetUserBios();
                    UserBio bufferContact = UserBio.GetAll().Except(bufferOldList).First();
                    app.Contact.AddContactToGroup(bufferContact, bufferGroup);
                }
            }
            else
            {
                if (contactList.Count == 0)
                {
                    app.Contact.CreateContact(newcontact);
                }

                GroupData bufferGroup = GroupData.GetAll()[0];
                List<UserBio> bufferOldList = bufferGroup.GetUserBios();


                if (bufferOldList.Count == 0)
                {
                    UserBio bufferContact = UserBio.GetAll().Except(bufferOldList).First();
                    app.Contact.AddContactToGroup(bufferContact, bufferGroup);
                }
            }

            GroupData group = GroupData.GetAll()[0];
            List<UserBio> oldList = group.GetUserBios();
            UserBio contact = GroupData.GetAll()[0].GetUserBios().First();

            app.Contact.RemoveContactFromGroup(contact, group);

            List<UserBio> newData = group.GetUserBios();
            oldList.Remove(contact);
            oldList.Sort();
            newData.Sort();

            Assert.AreEqual(oldList, newData);

        }
    }
}
