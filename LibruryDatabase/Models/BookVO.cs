using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace LibruryDatabase.Models
{
    class BookVO
    {
        private static BookVO BookData = null;

        public static BookVO Get()
        {
            if (BookData == null)
                BookData = new BookVO();

            return BookData;
        }




    }
    public class Book
    {
        string server = "localhost"; //DB 서버 주소, 로컬일 경우 localhost
        int port = 3306; //DB 서버 포트
        string database = "new_schema"; //DB 이름
        string id = "root"; //계정 아이디
        string pw = "0000"; //계정 비밀번호
        string connectionAddress = "";

        public Book()
        {
         
            //MySQL 연결을 위한 주소 형식
            connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", server, port, database, id, pw);
        }


        public static void SelectUsingReader()
        {
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string sql = "SELECT * FROM book";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(sql, book);
                MySqlDataReader bookInforamtion = Command.ExecuteReader();
                while (bookInforamtion.Read())
                {
                    Console.WriteLine("{0}: {1}", bookInforamtion["number"], bookInforamtion["Name"]);
                }
                bookInforamtion.Close();
            }
        }



        /*
        private void BookVo(object sender, EventArgs e)
        {
            
                using (MySqlConnection mysql = new MySqlConnection(connectionAddress))
                {
                    mysql.Open();

                    //accounts_table에 name, phone column 데이터를 삽입합니다. id는 자동으로 증가합니다.
                    string insertQuery = string.Format("INSERT INTO book VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}');",);

                    MySqlCommand command = new MySqlCommand(insertQuery, mysql);
                }
            }
            
        }
        */
    }
}
