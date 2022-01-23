using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace addressbook
{
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


        //аксесор для поля имени
        public string Name { get; set; }//default accessor
        public string Surname { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
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
                    return (Email + "\r\n" + Email2 + "\r\n" + Email3 + "\r\n").Trim();
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

    }
}
