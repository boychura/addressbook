using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook
{
    public class GroupData
    {
        private string name;
        private string header;
        private string footer;

        public GroupData(string name)
        {
            this.name = name;
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
        public string Header
        {
            get 
            {
                return header;
            }
            set
            {
                header = value;
            }
        }
        public string Footer 
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}
