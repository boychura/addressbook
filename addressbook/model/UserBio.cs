using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace addressbook
{
    [Table(Name = "addressbook")]
    //указываем что клас наследует IEquatable,IComparable и его можно сравнивать  с другими объектами UserBio
    public class UserBio : IEquatable<UserBio>, IComparable<UserBio>
    {
        private string allPhones;
        private string allEmails;

        //конструктор класса UserBio
        public UserBio()
        {
        }
        public UserBio(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public UserBio(string name)
        {
            Name = name;
        }

        //standart method 'Equals' IEquatable
        //сравнение элементов обьекта GroupData(список груп до создания и список груп после создания)
        public bool Equals(UserBio other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name && Surname == other.Surname;
        }


        //standart method 'GetHashCode' IEquatable
        //сравнение элементов по хеш коду(если элементы одинаковы значит и хеш код одинаковен)
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        //standart method 'CompareTo' IComparable
        public int CompareTo(UserBio other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Name != other.Name)
            {
                return Name.CompareTo(other.Name);
            }
            if (this.Surname != other.Surname)
            {
                return Surname.CompareTo(other.Surname);
            }
            return Surname.CompareTo(other.Surname) & Name.CompareTo(other.Name);
        }


        //standart method, returns string value UserBio
        public override string ToString()
        {
            return $"contact = {Surname} {Name}";
        }

        public string AllPhones
        {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();//Trim deletes spaces
                }
            }
            set {
                allPhones = value; 
            }
        }
        public string AllData { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        //cleaning text of space, (, ), -
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        [Column(Name = "firstname")]
        public string Name { get; set; }


        [Column(Name = "lastname")]
        public string Surname { get; set; }


        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }


        [Column(Name = "address")]
        public string Address { get; set; }


        [Column(Name = "home")]
        public string HomePhone { get; set; }


        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }


        [Column(Name = "work")]
        public string WorkPhone { get; set; }


        [Column(Name = "email")]
        public string Email { get; set; }


        [Column(Name = "email2")]
        public string Email2 { get; set; }


        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public static List<UserBio> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contact.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

    }
}
