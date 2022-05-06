using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Controls
{
    internal class RemovalBook : SearchingBook
    {

        private Screen Print;
        private MessageScreen Message;

        private LogDAO logDao;
        private LogDTO logDto;
        private BookDAO bookDao;
        private BookDTO bookDto;

        public RemovalBook()
        {

        }

        public RemovalBook(Screen Menu, MessageScreen message, LogDAO LogDao, LogDTO LogDto, BookDAO BookDao, BookDTO BookDto) : base(Menu, message, LogDao, BookDao)
        {
            this.Print = Menu;
            this.Message = message;

            this.logDao = LogDao;
            this.logDto = LogDto;
            this.bookDto = BookDto;
            this.bookDao = BookDao;
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
                            Print.PrintMain();
                            Print.PrintAdminMenu();
                            return;
                        }
                    default: continue;
                }

            }
        }
        
        public void RemoveBook()
        {
            string bookNumber;
            string bookName;

            logDao.connection(); // db연결
            bookDao.connection(); // db연결

            Console.Clear();
            Print.PrintSearchBookName();
            Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);
            Message.GreenColor(Message.PrintChooseRemoveBook()); // 안내메시지           
            Print.PrintBookData(bookDao.StoreBookReturn()); // 책 목록 프린트
            Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);

            if (IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(Constants.isFail, Constants.ADMIN); // 책 제목 검색

            bookNumber = InputBookNumber();
            bookDto.Number = bookNumber;
            if (!bookDao.IsCheckingBookExistence(bookDto.Number)) //  도서관에 책 존재 x
            {
                Message.RedColor(Message.PrintNoneBook());
            }

            else if (bookDao.IsCheckingBookExistence(bookDto.Number)) //도서관에 책 존재 o
            {
                bookName = bookDao.BringBookname(bookDto.Number); // 해당 책 제목 가져오기
                bookDao.close(); // db닫기 위치 애매함 나중에 수정
                logDto.Log = bookName;
                logDao.StoreLog(Constants.ADMIN, Constants.REMOVE, logDto.Log); // db에 로그 내역 저장

                bookDao.RemoveBookInformation(bookDto.Number); // 책 삭제
                Message.GreenColor(Message.PrintRemoveBookMessage());
            }
            GoBackMenu();
        }

        public string InputBookNumber() // 책 번호 입력
        {
            string bookNumber;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintRemoveBookNumberMessage();

            while (Constants.isPassing)
            {           
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                bookNumber = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return bookNumber;         
        }

        public bool IsGoingBackMenu()
        {
            while (Constants.isPassing) // 메뉴 입장한 후 뒤로가기
            {
                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Print.PrintMain();
                    Print.PrintAdminMenu();
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.BOOK_NAME_Y);
                    return Constants.isBackMenu;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter) { ClearCurrentLine(Constants.CURRENT_LOCATION); break; }
            }
            return Constants.isPassing;
        }

    }
}
