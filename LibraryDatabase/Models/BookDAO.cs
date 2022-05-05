using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;

namespace LibruryDatabase.Models
{
    internal class BookDAO
    {
        private MySqlConnection conn;

        public MySqlConnection connection()
        {
            conn = Connection.getConnection();
            return conn;
        }

        public void PlusBook(string bookNumber) // 책 반납시 해당 책 갯수 1 증가
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.plusBook, bookNumber), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public string BringBookname(string bookNumber) // 이름가져오기
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowedIdQuery, bookNumber), conn);
            MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

            while (bookData.Read())
            {
                if (bookData["number"].ToString() == bookNumber)
                {                  
                    return bookData["name"].ToString();
                }
            }
            conn.Close();
            return bookData["name"].ToString();
        }
        public void close()
        {
            conn.Close();
        }
    }
}
