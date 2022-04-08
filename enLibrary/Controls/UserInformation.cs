using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EnLibrary.Controls
{
    using Views;
    class UserVO
    {
        public static List<UserVO> UserInformation = new List<UserVO>();
        // UserInformationVo user = new UserInformationVo();

        private string id;
        private string pw;
        private string pwPass;
        private string name;
        private string age;
        private string callNumber;
        private string address;

        public UserVO()
        {
                   // 생성자
        }

        public UserVO(string id, string pw, string pwPass, string name, string age, string callNumber, string address)
        {
            this.id = id;
            this.pw = pw;
            this.pwPass = pwPass;
            this.name = name;
            this.age = age;
            this.callNumber = callNumber;
            this.address = address;
        }
        
        public void UserInformationStore() // 회원가입 정보 저장
        {
            UserVO user = new UserVO();
            user.id = id;
            user.pw = pw;
            user.pwPass = pwPass;
            user.name = name;
            user.age = age;
            user.callNumber = callNumber;
            user.address = address;
            UserInformation.Add(user);
            //Userprint();
        }
        public void Userprint()
        {
            Console.WriteLine(UserInformation[0].id);
            Console.WriteLine(UserInformation[0].pw);
            //Console.WriteLine(UserInformation[0].pwPass);
            //Console.WriteLine(UserInformation[0].name);
            //Console.WriteLine(UserInformation[0].age);
            //Console.WriteLine(UserInformation[0].callNumber);
        }

        public void CheckingIdPw() // 아이디 비밀번호 맞는지 확인
        {
            BookMenu Menu = new BookMenu();
            UserMode User = new UserMode();

            if (Input.idConfirm == UserInformation[0].id && Input.pwConfirm == UserInformation[0].pw) // 아디 비번 맞으면
            {
                Console.Clear();
                Console.WriteLine();
                Menu.SeeBookMenu(); // BookInformation으로 이동
            }
            else { Console.Write("아이디 비밀번호가 일치하지 않습니다. 다시 입력해주세요 :"); User.LoginPrint(); }
        }

        public void Print()
        { 
            Console.WriteLine(UserInformation[0]);       
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

        public override string ToString()
        {
            return "아이디 : " + id + "\n비밀번호 : " + pw + "\n이름 : " + age + "\n나이   : " + callNumber + "\n전화번호   : " + callNumber + "\n주소   : " + address;
        }
    }
}
