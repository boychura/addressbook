using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToDB.Mapping;

namespace addressbook
{
    //указываем что клас наследует IEquatable,IComparable и его можно сравнивать  с другими объектами GroupData
    [Table(Name = "group_list")]//checking name in db in phpMyadmin
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }
        public GroupData(string name)
        {
            Name = name;
        }

        //standart method 'Equals'
        //сравнение элементов обьекта GroupData(список груп до создания и список груп после создания)
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        //standart method 'GetHashCode'
        //сравнение элементов по хеш коду(если элементы одинаковы значит и хеш код одинаковен)
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        //standart method 'CompareTo'
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        //standart method, returns string value GroupData
        public override string ToString()
        {
            return "group name=" + Name + "\nheader= " + Header + "\nfooter" + Footer;
        }

        [Column(Name = "group_name")]
        public string Name { get; set; }

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }
    }
}
