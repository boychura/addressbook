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
        private string concatAll;
        private string fullNameConcatk;
        private string addressConcat;
        private string phonesConcat;
        private string emailConcat;

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
        public string ConcatAll
        {
            get
            {
                string fullNameConcat = FullNameConcat;
                string addressConcat = AddressConcat;
                string phoneConcat = PhoneConcat;
                string emailConcat = EmailConcat;
                string concatAllBuffer = "";



                if (concatAll != null)
                {
                    return concatAll = "";
                }
                else
                {
                    if (fullNameConcat != "")
                    {
                        concatAllBuffer = fullNameConcat;
                    }
                    if (addressConcat != "")
                    {
                        if (concatAllBuffer != "")
                        {
                            concatAllBuffer += ReturnTextWithEnterBeforeText(addressConcat);
                        }
                        else
                        {
                            concatAllBuffer = addressConcat;
                        }
                    }
                    if (phoneConcat != "")
                    {
                        if (concatAllBuffer != "")
                        {
                            concatAllBuffer += ReturnTextWithTwoEnters(phoneConcat);
                        }
                        else
                        {
                            concatAllBuffer = phoneConcat;
                        }
                    }
                    if (emailConcat != "")
                    {
                        if (concatAllBuffer != "")
                        {
                            concatAllBuffer += ReturnTextWithTwoEnters(emailConcat);
                        }
                        else
                        {
                            concatAllBuffer = emailConcat;
                        }
                    }
                }
                return concatAllBuffer.Trim();
            }
            set
            {
                concatAll = value;
            }
        }


        public string FullNameConcat
        {
            get
            {
                if (fullNameConcatk != null)
                {
                    return fullNameConcatk;
                }
                else
                {

                    return ReturnFullName(Name.Trim(), Surname.Trim());
                }
            }
            set
            {
                fullNameConcatk = value;
            }
        }

        public string PhoneConcat
        {
            get
            {
                string phoneConcat = "";

                if (HomePhone != null && HomePhone != "")
                {
                    phoneConcat = ("H: " + HomePhone.Trim()).Trim();
                }
                if (MobilePhone != null && MobilePhone != "")
                {
                    if (phoneConcat != null && phoneConcat != "")
                    {
                        phoneConcat += "\r\n" + ("M: " + MobilePhone.Trim()).Trim();
                    }
                    else
                    {
                        phoneConcat = ("M: " + MobilePhone.Trim()).Trim();
                    }
                }
                if (WorkPhone != null && WorkPhone != "")
                {
                    if (phoneConcat != null && phoneConcat != "")
                    {
                        phoneConcat += "\r\n" + ("W: " + WorkPhone.Trim()).Trim();
                    }
                    else
                    {
                        phoneConcat = ("W: " + WorkPhone.Trim()).Trim();
                    }
                }
                return phoneConcat;
            }
            set
            {
                phonesConcat = value;
            }
        }

        public string EmailConcat
        {
            get
            {
                string emailConcat = "";

                if (Email != null && Email != "")
                {
                    emailConcat = Email;
                }
                if (Email2 != null && Email2 != "")
                {
                    if (emailConcat != null && emailConcat != "")
                    {
                        emailConcat = emailConcat.Trim() + "\r\n" + Email2.Trim();
                    }
                    else
                    {
                        emailConcat = Email2;
                    }
                }
                if (Email3 != null && Email3 != "")
                {
                    if (emailConcat != null && emailConcat != "")
                    {
                        emailConcat = emailConcat + "\r\n" + Email3.Trim();
                    }
                    else
                    {
                        emailConcat = Email3;
                    }
                }
                return emailConcat;
            }
            set
            {
                emailConcat = value;
            }
        }

        public string AddressConcat
        {
            get
            {
                string addressConcat = "";
                if (Address != null && Address != "")
                {
                    if (addressConcat != null && addressConcat != "")
                    {
                        addressConcat += "\r\n" + Address.Trim();
                    }
                    else
                    {
                        addressConcat = Address.Trim();
                    }
                }
                return addressConcat;
            }
            set
            {
                addressConcat = value;
            }
        }

        public string ReturnTextWithEnter(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }

        public string ReturnTextWithoutEnter(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text;
        }

        public string ReturnTextWithEnterBeforeText(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n" + text;
        }

        public string ReturnTextWithTwoEnters(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n\r\n" + text;
        }

        public string ReturnFullName(string name, string surname)
        {
            string FullName = "";
            if (name != null && name != "")
            {
                FullName = name;
            }
            if (surname != null && surname != "")
            {
                if (FullName != "")
                {
                    FullName += " " + surname;
                }
                else
                {
                    FullName = surname;
                }
            }

            return FullName;
        }
    }
}
