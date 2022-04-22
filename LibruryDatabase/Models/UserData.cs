using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Models
{
    internal class UserData
    {
        private static UserData User = null;

        public static UserData Get()
        {
            if (User == null)
                User = new UserData();

            return User;
        }

        public void PrintUserData() // 
        {

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
                    Console.WriteLine(userInformation["id"].ToString());
                    Console.WriteLine(userInformation["pw"].ToString());
                    Console.WriteLine(userInformation["name"].ToString());
                    Console.WriteLine(userInformation["phone"].ToString());
                    Console.WriteLine(userInformation["age"].ToString());
                    Console.WriteLine(userInformation["address"].ToString());
                    Console.WriteLine("===============================================================");
                }
                userInformation.Close();
            }
        }


        public void StoreUserInformation(string id, string pw, string name, string phone, string age, string address) // 데이터베이스에 회원정보 저장
        {

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string insertQuery = string.Format("INSERT INTO member VALUES({0},{1},{2},{3},{4},{5});", id, pw, name, phone, age,address);
                //string insertQuery = string.Format("INSERT INTO MEMBER VALUES('id','pw','name','string','age','address')") ;
                MySqlCommand Command = new MySqlCommand(insertQuery, user);
                
                user.Close();
            }

        }

        /*
        public void StoreUserInformation(string id, string pw) 
        {

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string insertQuery = string.Format("SELECT * FROM member WHERE id pw LIKE ‘% id %’‘% pw %’)");

                MySqlCommand Command = new MySqlCommand(insertQuery, user);

                user.Close();
            }

        }
        */


    }


}

