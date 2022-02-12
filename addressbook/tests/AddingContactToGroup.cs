using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    public class AddingContactToGroup : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
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
                }
            }
            if (contactList.Count == 0)
            {
                app.Contact.CreateContact(newcontact);
            }

            GroupData group = GroupData.GetAll()[0];
            List<UserBio> oldList = group.GetUserBios();


            if (oldList.SequenceEqual(UserBio.GetAll()))
            {
                app.Contact.CreateContact(newcontact);
            }


            UserBio contacts = UserBio.GetAll().Except(oldList).First();
            app.Contact.AddContactToGroup(contacts, group);

            //actions
            List<UserBio> newList = group.GetUserBios();
            oldList.Add(contacts);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
