using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Exception;
using MySql.Data.MySqlClient;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;

namespace LibruryDatabase.Controls
{
    internal class BorrowingBook : SearchingBook
    {
        Screen Menu = new Screen();
        Regex NUMBER = new Regex(Utility.Exception.BOOKNUMBER_CHECK);
        public void InputBookTitleandBookNumber(string id) // 책 제목, 책 번호 
        {
            bool check = Constants.FAIL;
            string bookNumber;
            Console.Clear();
            Menu.PrintBookData(); // 책 목록 프린트
            SearchBookName(); // 책 제목 검색
            Console.Write("  대여하실 책 번호 :");

            while (Constants.ENTRANCE) // 책 번호 입력
            {
                bookNumber = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);
                if (Constants.CHECK == NUMBER.IsMatch(bookNumber)) // 정규식에 맞지 않으면
                {
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            SearchBook(id, bookNumber);
        }
        
        public void SearchBook(string id, string number)
        {

            string bookName = null;
            string author= null;
            string publish= null;

            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";


            using (MySqlConnection book = new MySqlConnection(getBook))
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

            AddBorrowBook(id, bookName, author, publish); // 책 대여 함수에 데이터 전송
        }


        
        public void AddBorrowBook(string id, string bookName, string author, string publish) 
        {
            string borrowDay = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";
            
            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string borrowIdQuery = "INSERT INTO BORROWMEMBER(id, bookname, author, publish, returnbook) VALUES('" + id + "','" + bookName + "','" + author + "','" + publish + "','" + borrowDay + "');";

                MySqlCommand Command = new MySqlCommand(borrowIdQuery, book);
                Command.ExecuteNonQuery();
            }
            
        }
       
    }
}
