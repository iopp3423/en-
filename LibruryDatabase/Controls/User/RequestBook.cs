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

        public void RequestAddBook() // 유저 책 요청 메서드
        {
            Menu.PrintMain();
            Message.PrintBookTitle();


            BookData.Get().NaverBook.Clear(); // 리스트 비우기


            bookName = InputBookName(); //책제목입력
            BookData.Get().StoreNaverBookToList(bookName, Constants.ADD_BOOK.ToString(), Constants.isPassing); // 리스트에 저장
                                                                                                         
            Console.WriteLine("\n\n");

            Menu.PrintRequestBook();//도서출력

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            isbn = InputISBN();

            Checkisbn(isbn);

            Message.GreenColor(Message.BackPrint());
            GoBackMenu();

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


        public void Checkisbn(string Isbn) //isbn 체크
        {
            bool isNoneisbn = Constants.isFail;

            foreach (NaverBookVO book in BookData.Get().NaverBook)
            {
                if (Isbn == book.isbn) // db에 저장
                {
                    BookData.Get().StoreRequestBook(book.title, book.author, book.publisher, book.publishday, book.price, book.isbn, Constants.ADD_BOOK.ToString());
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

        public void GoBackMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Menu.PrintMain();
                            Menu.PrintUserMenu();
                            return;
                        }
                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }
                    default: continue;
                }

            }
        }
    }
}
