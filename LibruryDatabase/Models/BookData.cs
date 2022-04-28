using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;

namespace LibruryDatabase.Models
{
    internal class BookData
    {
        private static BookData Book = null;
        public static BookData Get()
        {
            if (Book == null)
                Book = new BookData();

            return Book;
        }

        public void StoreBookInformation(string bookName, string author, string publish, string publishDay, string quantity, string price) // 책 추가
        {
           
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                string insertQuery = "INSERT INTO book(name,author,publish,publishDay,price,quantity) VALUES('" + bookName + "','" + author + "','" + publish + "','" + publishDay + "','" + price + "','" + quantity + "');";

                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                Command.ExecuteNonQuery();
            }
        }

        public void RemoveBookInformation(string bookNunmber) // 책 제거
        {
            

            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                string DeleteQuery = "DELETE FROM book WHERE number = '" + bookNunmber + " ';";
                MySqlCommand Command = new MySqlCommand(DeleteQuery, book);
                Command.ExecuteNonQuery();
            }
        }
    
        public void ModifyBookInformation(string bookInformation, string menu, string bookNumber) // 책 수정
        {
            string ModifyQuery;
            
            if (menu == Constants.REVISE_BOOK_QUANTITY) ModifyQuery = "UPDATE book SET quantity = '" + bookInformation + "'WHERE number = '" + bookNumber + " ';"; // 수량 수정
            else ModifyQuery = "UPDATE book SET price = '" + bookInformation + "' WHERE number = '" + bookNumber + " ';"; // 가격 수정

            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(ModifyQuery, book);
                Command.ExecuteNonQuery();
            }
        }


        public bool CheckBookOverlap(string id, string bookNumber) // 데베에서 책 대여했는지 체크
        {

            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                string borrowIdQuery = "SELECT * FROM BORROWMEMBER WHERE id = '" + id + " ';";

                MySqlCommand Command = new MySqlCommand(borrowIdQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["number"].ToString() == bookNumber && userData["borrowbook"].ToString() != " " && userData["returnbook"].ToString() != " ") return Constants.SUCESS;// 대여하고 반납함
                    else if (userData["number"].ToString() == bookNumber && userData["borrowbook"].ToString() != " " && userData["returnbook"].ToString() == " ") return Constants.FAIL; // 대여하고 반납안함
                }
                user.Close();
            }
            return Constants.SUCESS;

        }


        public void SearchBook(string id, string number) // 로그인한 유저 아이디값, 책 번호 전달받음
        {

            string bookName = null;
            string author = null;
            string publish = null;


            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                string insertQuery = "SELECT name, author, publish FROM book WHERE number = '" + number + "';";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    bookName = (bookData["name"].ToString());
                    author = (bookData["author"].ToString());
                    publish = (bookData["publish"].ToString());
                }
                bookData.Close();
            }

            AddBorrowBook(id, number, bookName, author, publish); // 책 대여 함수에 데이터 전송
        }



        public void AddBorrowBook(string id, string number, string bookName, string author, string publish) // 로그인한 유저 책 대여
        {
            string borrowDay = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;

            
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                //string borrowIdQuery = "INSERT INTO BORROWMEMBER(id, number, bookname, author, publish, borrowbook, returnbook) VALUES('" + id + "','" + number + "','" + bookName + "','" + author + "','" + publish + "','" + borrowDay + "','" + ' ' + "');";
                string borrowIdQuery = "INSERT INTO BORROWMEMBER(id, number, bookname, author, publish, borrowbook, returnbook) VALUES('" + id + "','" + number + "','" + bookName + "','" + author + "','" + publish + "','" + borrowDay + "','" + ' ' + "') ON DUPLICATE KEY UPDATE id = '" + id + "',borrowbook= '" + borrowDay + "',returnbook = '" + ' ' + "';";

                MySqlCommand Command = new MySqlCommand(borrowIdQuery, book);
                Command.ExecuteNonQuery();
            }
            
        }
    }
}
