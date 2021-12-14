using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook
{
    public class UserBio
    {
        private string name;
        private string surname;

        public UserBio(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

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
