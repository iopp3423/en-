using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Controls
{
    class UserDataVo
    {
        private string id;
        private string pw;
        private string pwCheck;
        private string name;
        private string age;
        private string callNumber;
        private string address;

        public UserDataVo()
        {
            //생성자
        }

        public UserDataVo(string id, string pw, string Check, string name, string age, string callNumber, string address)
        {
            this.id = id;  
            this.pw = pw;
            this.pwCheck = pwCheck;


            this.name = name;
            this.age = age;
            this.callNumber = callNumber;
            this.address = address;
        }
    }
}
