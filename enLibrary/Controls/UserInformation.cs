using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Controls
{
    public class UserInformationVo
    {
        List<UserInformationVo> UserInformation = new List<UserInformationVo>();
        private string id;
        private string pw;
        private string pwPass;
        private string name;
        private string age;
        private string callNumber;
        private string address;

        public UserInformationVo()
        {
            // 생성자
        }

        public UserInformationVo(string id, string pw, string pwPass, string name, string age, string callNumber, string address)
        {
            this.id = id;
            this.pw = pw;
            this.pwPass = pwPass;
            this.name = name;
            this.age = age;
            this.callNumber = callNumber;
            this.address = address;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Pw
        {
            get { return pw; }
            set { pw = value; }
        }
        public string PwPass
        {
            get { return pwPass; }
            set { pwPass = value; }
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
    }
}
