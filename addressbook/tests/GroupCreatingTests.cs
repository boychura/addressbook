using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;//List<>
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;//Linq language

namespace addressbook
{
    [TestFixture]
    public class GroupCreatingTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.xml");
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>))//first 'List<GroupData>' ykazuvaem iavno vozvrashaemui tip
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreateTestCase(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAll();

            app.Groups.Create(group);
            //check groups count
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(group);//add created group to old group to compare 
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            //Assert.AreEqual(oldGroups.Count + 1, newGroups.Count); проверка по количеству элементов каждого списка
        }

        [Test]
        public void BadNameGroupCreateTestCase()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            //check groups count
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            foreach (UserBio contact in GroupData.GetAll()[0].GetUserBios())
            {
                Console.WriteLine(contact.Deprecated);
            }
        }
    }
}
