using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;


namespace LibruryDatabase.Models
{
    internal class BorrowBookDAO
    {
        private MySqlConnection conn;

        public MySqlConnection connection()
        {
            conn = Connection.getConnection();
            return conn;
        }

        public void RemoveBorrowmember(string id) // 대여목록에 있는 아이디 db에서 제거
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.RemoveBorrowmember, id), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public bool IsCheckingBorrowedBook(string id) // 대여한 책이 있으면 False, 없으면 true
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(Constants.BorrrowBookUserquery, conn);
            MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

            while (userData.Read())
            {
                if (userData["id"].ToString() == id)
                {
                    conn.Close();
                    return Constants.isFail; // 아이디가 있으면 반납 안함
                }
            }
            conn.Close();
            return Constants.isSucess; // 반납함
        }


        /*
        public bool Login(string id, string password) // 관리자 아이디 로그인
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(Constants.AdminSearchQuery, conn);
            MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

            while (userData.Read())
            {
                if (userData["id"].ToString() == id && userData["pw"].ToString() == password)
                {
                    conn.Close();
                    return Constants.isSucess;
                }
            }
            conn.Close();

            return Constants.isFail;
        }

        public void StoreUserInformation(string id, string pw, string name, string phone, string age, string address) // db 회원가입 정보 저장
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.insertUserQuery, id, pw, name, phone, age, address), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }
        */


        public void close()
        {
            conn.Close();
        }
    }
}
