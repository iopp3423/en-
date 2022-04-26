using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;
using LibruryDatabase.Exception;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Controls
{
    internal class CheckingReturnBook
    {
        Screen Menu = new Screen();
        public void ShowBorrowBook(string id)
        {
            string bookNumber;

            Console.Clear();
            Menu.PrintBorrowBookData(id);
            bookNumber = InputBookNumber();
            ReturnBook(bookNumber);
        }

        public string InputBookNumber() // 책 제목, 책 번호 
        {
            string bookNumber;

            Console.Write("반납할 책 번호를 입력해주세요 : ");
            while (Constants.ENTRANCE) // 책 번호 입력
            {

                bookNumber = Console.ReadLine();
                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                if (Constants.CHECK == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK)) // 정규식에 맞지 않으면
                {
                    Constants.ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookNumber;
        }

        public void ReturnBook(string bookNumber) // 로그인한 유저 책 대여
        {
            string returnDay = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string returnBookQuery = "UPDATE BORROWMEMBER SET returnbook = '" + returnDay + "' WHERE number = '" + bookNumber + " ';";

                MySqlCommand Command = new MySqlCommand(returnBookQuery, book);
                Command.ExecuteNonQuery();
            }

        }

    }

}
