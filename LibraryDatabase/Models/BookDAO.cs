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

        public List<BookDTO> StoreBookReturn() // 도서목록 리턴
        {
            List<BookDTO> book = new List<BookDTO>();

            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.SearchBookQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                book.Add(new BookDTO(Data["number"].ToString(), Data["name"].ToString(), Data["author"].ToString(), Data["publish"].ToString(), Data["publishday"].ToString(), Data["price"].ToString(), Data["isbn"].ToString(), Data["quantity"].ToString()));
            }
            conn.Close();
            return book;
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

        public string BringSearchResult(string name) // 데베에 책 있는지 체크
        {


            MySqlConnection user = new MySqlConnection(Constants.getQuery);

            user.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.SearchBookQuery), user);
            MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

            while (bookData.Read())
            {
                if (bookData["author"].ToString().Contains(name)) { return bookData["author"].ToString(); }
                else if (bookData["publish"].ToString().Contains(name)) { return bookData["publish"].ToString(); }
                else if (bookData["name"].ToString().Contains(name)) { return bookData["name"].ToString(); }
            }
            user.Close();

            return name;
        }

        public bool IsCheckongBookQuantity(string bookNumber) // 책 수량 체크
        {

            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowedIdQuery, bookNumber), conn);
            MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

            while (bookData.Read())
            {
                if (bookData["quantity"].ToString() == Constants.NONE_BOOK)
                {
                    conn.Close();
                    return Constants.isFail;
                }
            }
            conn.Close();
            return Constants.isPassing;

        }

        public void MinusBook(string bookNumber) // 책 대여시 해당 책 갯수 1 감소
        {
            conn.Open();
            MySqlCommand Command = new MySqlCommand(String.Format(Constants.minusBook, bookNumber), conn);
            Command.ExecuteNonQuery();
            conn.Close();
        }

        public bool CheckBookNumber(string bookNumber)
        {
            conn.Open();
            //ExecuteReader를 이용하여
            //연결 모드로 데이타 가져오기
            MySqlCommand Command = new MySqlCommand(Constants.SearchBookQuery, conn);
            MySqlDataReader Data = Command.ExecuteReader();

            while (Data.Read())
            {
                if(Data["number"].ToString() == bookNumber)
                {
                    conn.Close();
                    return Constants.isPassing;
                }
            }
            conn.Close();
            return Constants.isFail;
        }


        public void close()
        {
            conn.Close();
        }
    }
}
