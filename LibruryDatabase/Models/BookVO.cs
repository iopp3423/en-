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
        string number;
        string name;
        string author;
        string publish;
        string price;
        string quantity;

        public static BookVO Get()
        {
            if (BookData == null)
                BookData = new BookVO();

            return BookData;
        }


        public void Book()
        {
            string number;
            string name;
            string author;
            string publish;
            string price;
            string quantity;

            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string sql = "SELECT * FROM book";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(sql, book);
                MySqlDataReader bookInformation = Command.ExecuteReader();
                while (bookInformation.Read())
                {
                    number = bookInformation["Number"].ToString();
                    name = bookInformation["name"].ToString();
                    author = bookInformation["author"].ToString();
                    publish =  bookInformation["publish"].ToString();
                    price = bookInformation["price"].ToString();
                    quantity = bookInformation["quantity"].ToString();
                }
                bookInformation.Close();
            }
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
