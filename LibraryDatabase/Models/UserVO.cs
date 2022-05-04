using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    internal class UserVO
    {
        public string id;
        public string password;
        public string name;
        public string phone;
        public string age;
        public string address;

        public UserVO()
        {

        }

        public UserVO(string id, string password, string name, string phone, string age, string address)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.phone = phone;
            this.age = age;
            this.address = address;
        }
          
    }
}
