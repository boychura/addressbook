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
            GroupData group = GroupData.GetAll()[0];
            List<UserBio> oldList = group.GetUserBios();


            UserBio contact = oldList.First();

            app.Contact.RemoveContactFromGroup(contact, group);

            //actions
            List<UserBio> newList = group.GetUserBios();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
