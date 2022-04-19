using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Models
{
    class UserVO
    {
        public List<UserVO> UserInformation = new List<UserVO>();

        public string id;
        public string pw;
        private string name;
        private string age;
        private string phone;
        private string address;

        public UserVO()
        {
            // 생성자
        }

        public UserVO(string id, string pw, string name, string age, string phone, string address)
        {
            this.id = id;
            this.pw = pw;
            this.name = name;
            this.age = age;
            this.phone = phone;
            this.address = address;
        }


        public override string ToString()
        {
            return "아이디 : " + id + "\n비밀번호 : " + pw + "\n이름 : " + name + "\n나이   : " + age + "\n전화번호   : " + phone + "\n주소   : " + address;
        }


        private static UserVO UserData = null;

        public static UserVO Get()
        {
            if (UserData == null)
                UserData = new UserVO();

            return UserData;
        }


        public void User()
        {

            string id;
            string pw;
            string name;
            string age;
            string phone;
            string address;

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string sql = "SELECT * FROM member";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(sql, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
                    id = userInformation["id"].ToString();
                    pw = userInformation["pw"].ToString();
                    name = userInformation["name"].ToString();
                    phone = userInformation["phone"].ToString();
                    age = userInformation["age"].ToString();
                    address = userInformation["address"].ToString();

                    UserInformation.Add(new UserVO(id, pw, name, phone, age, address));
                }
                userInformation.Close();
            }

            
        }
        public void PrintUser()
        {

            foreach (UserVO list in UserInformation)
            {
                Console.WriteLine(list);
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }

        }

        public void StoreUserInformation(string id, string pw, string name, string phone, string age, string address) // 데이터베이스에 회원정보 저장
        {

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";
            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                string insertQuery = string.Format("INSERT INTO member VALUES('{0}','{1}','{2}','{3}','{4}','{5}');", id, pw, name, phone, age, address);
                user.Open();
                MySqlCommand Command = new MySqlCommand(insertQuery, user);
            }

        }
    }
}
