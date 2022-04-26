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
        public void StoreUserInformation(string id, string pw, string name, string phone, string age, string address) // 데이터베이스에 회원정보 저장
        {

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string insertQuery = "INSERT INTO member(id,pw,name,phone,age,address) VALUES('"+id+"','"+ pw+"','"+name+"','"+ phone+"','"+age+"','"+address+"');";
                MySqlCommand Command = new MySqlCommand(insertQuery, user);
                Command.ExecuteNonQuery();
            }

        }

        public void RemoveUserInformation(string userId)
        {
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string DeleteQuery = "DELETE FROM member WHERE id = '" + userId + " ';";
                MySqlCommand Command = new MySqlCommand(DeleteQuery, book);
                Command.ExecuteNonQuery();
            }
        }
    }
}

