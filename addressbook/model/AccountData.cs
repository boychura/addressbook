using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook
{
    public class AccountData
    {
        //объявление полей класса
        private string username;
        private string password;


        //конструктор класса AccountData
        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }


        //аксесор для поля login
        public string Username {
            get 
            {
                return username;
            } 
            set 
            {
                username = value; 
            } 
        }


        //аксесор для поля password
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
