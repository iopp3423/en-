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

        List<BookVO> BookInformation = new List<BookVO>();

        private string number;
        private string name;
        private string author;
        private string publish;
        private string price;
        private string quantity;

        public BookVO()
        {
            // 생성자
        }

        public BookVO(string number, string name, string author,string publish, string price, string quantity)
        {
            this.number = number;
            this.name = name;
            this.author = author;
            this.publish = publish;
            this.price = price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return "책번호 : " + number + "\n책이름 : " + name + "\n출판사 : " + publish + "\n저자   : " + author + "\n가격   : " + price + "\n수량   : " + quantity;
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

                    BookInformation.Add(new BookVO(number, name, author, publish, price, quantity));
                }

                bookInformation.Close();
            }         
        }
        public void print()
        {

            foreach (BookVO list in BookInformation)
            {
                Console.WriteLine(list);
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
