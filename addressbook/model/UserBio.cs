using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook
{
    //указываем что клас наследует IEquatable,IComparable и его можно сравнивать  с другими объектами UserBio
    public class UserBio : IEquatable<UserBio>, IComparable<UserBio>
    {

        //объявление полей класса
        private string name;
        private string surname;


        //конструктор класса UserBio
        public UserBio(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
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
            return Name.CompareTo(other.Name);
        }


        //standart method, returns string value UserBio
        public override string ToString()
        {
            return "name=" + Name + "surname=" + Surname;
        }


        //аксесор для поля имени
        public string Name 
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
            }
        }


        //аксесор для поля фамилии
        public string Surname 
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
    }
}
