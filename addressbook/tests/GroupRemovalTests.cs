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

            //создание списка олдГрупс(существующих) на основе класа ГрупДата и присваивание этому списку елементов
            //полученых методом ГетГрупЛист 
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.StartCheckGroups(0, group);
            app.Groups.Remove(0);

            //создание списка newGroups(после удаления) на основе класа ГрупДата и присваивание этому списку елементов
            //полученых методом ГетГрупЛист 
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);//удаление элемента с первого списка груп(так как он удален тестом)
            Assert.AreEqual(oldGroups, newGroups);//сравнение двух списков груп, до и после удаления
        }
    }
}
