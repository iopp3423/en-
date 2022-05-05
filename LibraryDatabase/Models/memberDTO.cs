using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibruryDatabase.Models
{
    public class memberDTO
    {
        private string id;
        private string password;
        private string name;
        private string phone;
        private string age;
        private string address;

        public memberDTO()
        {

        }

        public memberDTO(string id, string password, string name, string phone, string age, string address)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.phone = phone;
            this.age = age;
            this.address = address;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        ~memberDTO() { } // 객체 소멸?? 음
    }
}
