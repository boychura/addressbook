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
            GroupData group = GroupData.GetAll()[0];
            List<UserBio> oldList = group.GetUserBios();

            UserBio contact = UserBio.GetAll().Except(group.GetUserBios()).First();

            app.Contact.AddContactToGroup(contact, group);

            //actions
            List<UserBio> newList = group.GetUserBios();
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
