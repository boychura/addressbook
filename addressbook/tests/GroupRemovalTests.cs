using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using System.Collections.Generic;//List<>

namespace addressbook
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTestCase()
        {
            GroupData group = new GroupData("table_name_deleted");
            group.Header = "table_header_deleted";
            group.Footer = "table_footer_deleted";

            app.Groups.StartCheckGroups(0, group);

            //создание списка олдГрупс(существующих) на основе класа ГрупДата и присваивание этому списку елементов
            //полученых методом ГетГрупЛист 
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];//saving 1-st element in list before changes

            app.Groups.Remove(0);
            //check groups count
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            //создание списка newGroups(после удаления) на основе класа ГрупДата и присваивание этому списку елементов
            //полученых методом ГетГрупЛист 
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);//удаление элемента с первого списка груп(так как он удален тестом)
            Assert.AreEqual(oldGroups, newGroups);//сравнение двух списков груп, до и после удаления

            foreach (GroupData groupIndex in newGroups)
            {
                Assert.AreNotEqual(group.Id, oldData.Id);
            }
        }
    }
}
