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
        private static UserData User;
        public static UserData Get()
        {
            if (User == null)
                User = new UserData();

            return User;
        }

        public bool IsLoginCheck(string id, string password) // 관리자 아이디로그인 체크
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                MySqlCommand Command = new MySqlCommand(Constants.AdminSearchQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id && userData["pw"].ToString() == password) return Constants.isSucess;
                }
                user.Close();
            }
            return Constants.isFail;

        }

        public void StoreUserInformation(string id, string pw, string name, string phone, string age, string address) // 데이터베이스에 회원정보 저장
        {           

            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.insertUserQuery,id,pw,name,phone,age,address), user);
                Command.ExecuteNonQuery();
            }

        }

        public void RemoveUserInformation(string userId) // 유저 삭제
        {


            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.DeleteUserQuery,userId), book);
                Command.ExecuteNonQuery();
            }
        }

        public bool IsCheckingIdOverlap(string id) // 데베에서 중복아이디 있는지 체크
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id) return Constants.isSucess;
                }
                user.Close();
            }
            return Constants.isFail;

        }

        public bool IsCheckingLogin(string id, string password) // 데베에서 회원 유무 확인
        {

            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                
                user.Open();
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id && userData["pw"].ToString() == password) return Constants.isSucess;
                }
                user.Close();
                
            }
            return Constants.isFail;

        }

        public string Bringname(string id) // 데베에서 회원 이름 가져오기
        {

            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {

                user.Open();
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id) return userData["name"].ToString();
                }
                user.Close();

            }
            return id;
        }

        public void ModifyPhone(string callNumber, string id)// 전화번호 데베에서 변경
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
               
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.updatePhoneQuery,callNumber, id), user);
                Command.ExecuteNonQuery();
            }
        }

        public void ModifyPassword(string password, string id) // 비밀번호 데베에서 변경
        {
            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();

                MySqlCommand Command = new MySqlCommand(String.Format(Constants.updatePwQuery,password, id), user);
                Command.ExecuteNonQuery(); 
            }
        }

        public void ModifyAddress(string address, string id)// 주소 데베에서 변경
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.updateAddressQuery,user, id), user);
                Command.ExecuteNonQuery();  
            }
        }

        public bool IsCheckingExistenceId(string id) // 아이디 존재유무
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id) return Constants.isPassing;
                }
                user.Close();
            }
            return Constants.isFail;
        }

        public bool IsCheckingExistenceUser(string name) // 회원이름이 존재하는지 체크
        {


            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["name"].ToString().Contains(name)) return Constants.isSucess;
                }
                user.Close();
            }
            return Constants.isFail;

        }
    }
}

