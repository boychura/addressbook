using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook
{
    //указываем что клас наследует IEquatable,IComparable и его можно сравнивать  с другими объектами GroupData
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
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

        //accessors with default body
        public string Name { get; set; }

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
    }
}
