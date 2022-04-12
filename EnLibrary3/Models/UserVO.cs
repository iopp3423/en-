using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Models
{
    public class UserVO
    {
        public string id;
        public string pw;
        private string name;
        private string age;
        private string callNumber;
        private string address;

        public UserVO()
        {
            // 생성자
        }

        public UserVO(string id, string pw, string name, string age, string callNumber, string address)
        {         
            this.id = id;
            this.pw = pw;
            this.name = name;
            this.age = age;
            this.callNumber = callNumber;
            this.address = address;
        }

        public string Id
        {
            get { return id;}
            set { id = value; }
        }
        public string Pw
        {
            get { return pw; }
            set { pw = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        public string CallNumber
        {
            get { return callNumber; }
            set { callNumber = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public override string ToString()
        {
            return "아이디 : " + id + "\n비밀번호 : " + pw + "\n이름 : " + age + "\n나이   : " + callNumber + "\n전화번호   : " + callNumber + "\n주소   : " + address;
        }
    }

}
