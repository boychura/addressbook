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
            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
            {
                GroupData newgroup = new GroupData("newgroup");
                app.Groups.Create(group);
            }
            GroupData group = GroupData.GetAll()[0];

            List<UserBio> oldList = UserBio.GetAll();

            UserBio firstcontact = UserBio.GetAll().Intersect(group.GetUserBios()).FirstOrDefault();
            if (firstcontact == null)
            {
                UserBio newcontact = new UserBio("firstname_test", "lastname_test" );
                app.Contact.CreateContact(newcontact);
                oldList.Add(newcontact);

                app.Contact.CreateContact(newcontact);
                app.Contact.AddContactToGroup(newcontact, group);
            }
            UserBio contact = UserBio.GetAll().Intersect(group.GetUserBios()).First();

            app.Contact.RemoveContactFromGroup(contact, group);

            //actions
            List<UserBio> newList = group.GetUserBios();
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
