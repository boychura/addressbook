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
            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0) 
            {
                GroupData newGroup = new GroupData("newgroup");
                app.Groups.Create(group);
            }
            GroupData group = GroupData.GetAll()[0];

            List<UserBio> oldList = group.GetUserBios();

            
            UserBio firstcontact = oldList.Except(group.GetUserBios()).FirstOrDefault();
            if (contact == null)
            {
                UserBio newcontact = new UserBio("test_name", "test_surname");
                app.Contact.CreateContact(contact);
                oldList.Add(contact);
            }
            UserBio contact = UserBio.GetAll().Except(oldList).First();

            app.Contact.AddContactToGroup(contact, group);

            //actions
            List<UserBio> newList = group.GetUserBios();
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
