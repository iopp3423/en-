using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;

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
        public void StoreUserInformation(string id, string pw, string name, string phone, string age, string address) // 데이터베이스에 회원정보 저장
        {
   
            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();
                string insertQuery = "INSERT INTO member(id,pw,name,phone,age,address) VALUES('"+id+"','"+ pw+"','"+name+"','"+ phone+"','"+age+"','"+address+"');";
                MySqlCommand Command = new MySqlCommand(insertQuery, user);
                Command.ExecuteNonQuery();
            }

        }

        public void RemoveUserInformation(string userId) // 유저 삭제
        {
            

            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                string DeleteQuery = "DELETE FROM member WHERE id = '" + userId + " ';";
                MySqlCommand Command = new MySqlCommand(DeleteQuery, book);
                Command.ExecuteNonQuery();
            }
        }

        public bool CheckIdOverlap(string id) // 데베에서 중복아이디 있는지 체크
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id) return Constants.SUCESS;
                }
                user.Close();
            }
            return Constants.FAIL;

        }

        public bool CheckLogin(string id, string password) // 데베에서 회원 유무 확인
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id && userData["pw"].ToString() == password) return Constants.SUCESS;
                }
                user.Close();
            }
            return Constants.FAIL;

        }
    }
}

