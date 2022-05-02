using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;
using LibruryDatabase.Utility;
using MySql.Data.MySqlClient;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class RequestBook
    {
        public Screen Menu;
        public MessageScreen Message;
        string bookName;
        string isbn;

        public RequestBook()
        {
        }

        public RequestBook(Screen Menu, MessageScreen message)

        {
            this.Menu = Menu;
            this.Message = message;
        }

        public void RequestAddBook()
        {
            Menu.PrintMain();
            Message.PrintBookTitle();

            bookName = InputBookName(); //책제목입력

            //BookData.Get().NaverBook.Clear(); // 리스트 비우기
            BookData.Get().StoreNaverBookToList(bookName, Constants.ADD_BOOK.ToString(), Constants.isFail); // 리스트에 저장            
            Console.WriteLine("\n\n");

            Menu.PrintRequestBook();//도서출력

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            isbn = InputISBN();

            Checkisbn(isbn);
            Console.Write(BookData.Get().isbn);

        }

        string InputBookName()//책이름입력
        {


            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.REQUEST_X, Constants.SEARCH_BOOK);
                bookName = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(bookName, Utility.Exception.TITLE_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintBookTitle();
                    Menu.PrintLoginErrorMessage();
                    continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return bookName;
        }

        string InputISBN()//isbn입력
        {


            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.REQUEST_X, Constants.SEARCH_BOOK);
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Message.PrintAddisbn();
                isbn = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(isbn, Utility.Exception.ISBN))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Menu.PrintLoginErrorMessage();
                    continue;
                }
                break;
            }
            Menu.PrintInputMessage();

            return isbn;
        }

        public void Checkisbn(string Isbn) // isbn 체크 후 bookdata에 저장
        {
            bool isNoneisbn = Constants.isFail;

            foreach (NaverBookVO book in BookData.Get().UserRequestBook)
            {
                if (Isbn == book.isbn)
                {
                    BookData.Get().isbn = Isbn;
                    isNoneisbn = Constants.isPassing;
                    break;
                }
            }
            if (isNoneisbn == Constants.isFail)
            {
                Message.PrintNoneIsbnMessage(); //isbn없음 메시지 출력
            }
        }


        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }
    }
}
