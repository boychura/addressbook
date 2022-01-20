using System;
using addressbook;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            if (type == "group") 
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.WriteLine("Unrecognized format" + format);
                }
            }

            else if (type == "contacts") 
            {
                List<UserBio> user = new List<UserBio>();
                for (int i = 0; i < count; i++)
                {
                    user.Add(new UserBio(TestBase.GenerateRandomString(10))
                    {
                        Name = TestBase.GenerateRandomString(100),
                        Surname = TestBase.GenerateRandomString(100)
                    });
                }
                if (format == "xml")
                {
                    writeContactsToXmlFile(user, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(user, writer);
                }
                else
                {
                    System.Console.WriteLine("Unrecognized format" + format);
                }
            }
            else
            {
                System.Console.WriteLine("Unrecognized type" + type);
            }
            


            writer.Close();
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void writeContactsToXmlFile(List<UserBio> user, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<UserBio>)).Serialize(writer, user);
        }

        static void writeContactsToJsonFile(List<UserBio> user, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(user, Newtonsoft.Json.Formatting.Indented));
        }
    }
}