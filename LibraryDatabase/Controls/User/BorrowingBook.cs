using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Utility;
using MySql.Data.MySqlClient;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class BorrowingBook : SearchingBook
    {
        private Screen Print;
        private MessageScreen Message;
        private LogDAO logDao;
        private LogDTO logDto;
        private BorrowBookDAO borrowBookDao;
        private BorrowBookDTO borrowBookDto;
        private BookDAO bookDao;
        private BookDTO bookDto;

        public BorrowingBook()
        {
        }

        public BorrowingBook(Screen Menu, MessageScreen message, LogDAO LogDao, LogDTO LogDto, BookDAO BookDao, BookDTO BookDto, BorrowBookDAO BorrowBookDao, BorrowBookDTO BorrowBookDto) 
                            : base(Menu, message, LogDao, BookDao)
        {
            this.Print = Menu;
            this.Message = message;
            this.logDao = LogDao;
            this.logDto = LogDto;
            this.bookDto = BookDto;
            this.bookDao = BookDao;
            this.borrowBookDao = BorrowBookDao;
            this.borrowBookDto = BorrowBookDto;
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
                            Print.PrintUserMenu();
                            return;
                        }
                    default: continue;
                }

            }
        }

        public void InputBookTitleandBookNumber(string id) // 책 제목, 책 번호 
        {
            string bookNumber;
            bool isAlreadyBorrow;
            string bookName;
            string returnDay = DateTime.Today.AddDays(Constants.RETURNDAY).ToString("yyyy/MM/dd");

            logDao.connection(); // db연결
            borrowBookDao.connection(); // db연결
            bookDao.connection(); // db연결


            Console.Clear();
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOKNAME_LINE);
            Message.GreenColor(Message.PrintBorrowBookMessage());
            Print.PrintBookData(bookDao.StoreBookReturn()); // 책 목록 프린트
            Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);


            while (Constants.isPassing) // 뒤로가기 or 입력
            {
                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Print.PrintMain();
                    Print.PrintUserMenu();
                    return;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter)
                {
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    break;
                }
            }


            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            SearchBookName(Constants.isPassing, id); // 책 제목 검색

            if (Constants.SEARCH_RESULT_BOOK == Constants.isPassing) // 목록에 책이 있으면 진행
            {
                while (Constants.isEntrancing) // 책 번호 입력
                {
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintBorrowBookNumberMessage();
                    bookNumber = Console.ReadLine();

                    if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK)) // 정규식에 맞지 않으면
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                        ClearCurrentLine(Constants.CURRENT_LOCATION);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        continue;
                    }
                    break;
                }

                bookDto.Number = bookNumber;
                if (bookDao.IsCheckongBookQuantity(bookDto.Number) == Constants.isFail) //책 수량체크
                {
                    Message.RedColor(Message.PrintNoneQuantity());
                    GoBackMenu(); 
                    return; 
                }

                borrowBookDto.Id = id;
                borrowBookDto.Number = bookNumber;
                isAlreadyBorrow = borrowBookDao.IsCheckingBookOverlap(borrowBookDto.Id, borrowBookDto.Number); // 책 대여 체크

                if (isAlreadyBorrow == Constants.isPassing)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Message.RedColor(Message.PrintAlreadyBorrowMessage());
                    GoBackMenu();
                }

                else if (bookDao.CheckBookNumber(bookNumber))
                {
                    Message.GreenColor("반납기한은" + returnDay + "입니다.");
                    borrowBookDao.BorrowBook(borrowBookDto.Id, borrowBookDto.Number); // borrowmember db 책 대여
                    borrowBookDto.Number = bookNumber;
                    bookDao.MinusBook(borrowBookDto.Number); //db 책 수량 1 감소  이렇게 하는건가..

                    bookDto.Number = bookNumber;
                    bookName = bookDao.BringBookname(bookDto.Number); // 해당 책 제목 가져오기
                    bookDao.close(); // db닫기 위치 애매함 나중에 수정
                    logDto.Id = id;
                    logDto.Log = bookName;
                    logDao.StoreLog(logDto.Id, Constants.BORROW, logDto.Log); // db에 로그 내역 저장

                    Message.GreenColor(Message.PrintDoneBorrowMessage());
                    GoBackMenu();
                }
                else
                {
                    Message.RedColor("없는 도서입니다. 뒤로가기 : ESC");
                    GoBackMenu();
                }
            }
            else if (Constants.SEARCH_RESULT_BOOK == Constants.isFail) GoBackMenu();
        }


    }
}