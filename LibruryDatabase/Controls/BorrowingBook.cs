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
        public void BorrowBook()
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


            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "SELECT * FROM book";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    if (bookData["number"].ToString().Contains(bookNumber))
                    {
                        Console.Write("책을 대여하였습니다.");
                        check = Constants.PASS;
                        Console.ReadLine();
                        break;
                        //Command.CommandText = "UPDATE book SET Name='Tim' WHERE Id=2";
                        //Command.ExecuteNonQuery();
                    }    
                }
                book.Close();
            }
            BookExistenceCheck(check);
        }
    }
}
