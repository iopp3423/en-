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
        private string bookName;
        private string bookNumber;
        private  Screen Menu;
        private  MessageScreen Message;
        private BookDAO bookDao;
        private BookDTO bookDto;

        public RequestBook()
        {
        }

        public RequestBook(Screen Menu, MessageScreen message, BookDAO BookDao, BookDTO BookDto)

        {
            this.Menu = Menu;
            this.Message = message;
            this.bookDto = BookDto;
            this.bookDao = BookDao;
        }

        public void SelectMenu() //이전 메뉴로 돌아가기
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
                    default: continue;
                }

            }
        }

        public void RequestAddBook() // 유저 책 요청 메서드
        {
            bookDao.connection(); // db연결

            Menu.PrintMain();
            Message.PrintBookTitle();
            Message.GreenColor(Message.PrintContinueRequestmessage());

            while (Constants.isPassing) // 뒤로가기
            {
                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Menu.PrintMain();
                    Menu.PrintUserMenu();
                    return;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter) break;
            }

            ClearCurrentLine(Constants.CURRENT_LOCATION); // 안내메시지 제거 후
            Message.PrintBookTitle(); // 입력메시지 출력

            bookDao.RemoveAllNaverBook(); // 네이버 db 초기화
            bookDto.Title = InputBookName(); //책제목입력
            bookDao.StoreNaverBook(bookDto.Title, Constants.ADD_BOOK.ToString()); // db에 네이버 검색한 책 저장

            Console.WriteLine("\n\n");

            Menu.PrintBookData(bookDao.StoreNaverBookReturn());//도서출력          


            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            bookDto.Number = InputbookNumber(); // 도서번호 입력

            if (bookDao.CheckNaverBookNumber(bookDto.Number))// 도서번호 맞게 입력하면
            {
                Message.GreenColor(Message.BackPrint());
                bookDao.InsertRequestBook(bookDto.Number);
                GoBackMenu();
            }

            else if (!bookDao.CheckNaverBookNumber(bookDto.Number))// 도서번호 잘못 입력하면
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Message.RedColor(Message.PrintNoneNumberMessage());
                SelectMenu();
            }
           
        }

        public string InputBookName()//책이름입력
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

        public string InputbookNumber()//책 번호 입력
        {
            while (Constants.isPassing)
            {
                Console.SetCursorPosition(Constants.REQUEST_X, Constants.SEARCH_BOOK);
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Message.PrintAddbookNumber();
                bookNumber = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Menu.PrintLoginErrorMessage();
                    continue;
                }
                break;
            }
            Menu.PrintInputMessage();
            return bookNumber;
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
                    default: continue;
                }

            }
        }
    }
}
