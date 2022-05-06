﻿using System;
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
        private memberDAO memberDao;
        private BorrowBookDAO borrowBookDao;
        private BookDAO bookDao;

        public RemovalBook()
        {

        }

        public RemovalBook(Screen Menu, MessageScreen message) : base(Menu, message)
        {
            this.Print = Menu;
            this.Message = message;
            logDao = new LogDAO();
            memberDao = new memberDAO();
            borrowBookDao = new BorrowBookDAO();
            bookDao = new BookDAO();
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

            memberDao.connection(); // db 연결
            logDao.connection(); // db연결
            borrowBookDao.connection(); // db연결
            bookDao.connection(); // db연결

            Console.Clear();
            Print.PrintSearchBookName();
            Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);
            Message.GreenColor(Message.PrintChooseRemoveBook()); // 안내메시지           
            Print.PrintBookData(bookDao.StoreBookReturn()); // 책 목록 프린트
            Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);

            if (Print.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(Constants.isFail, Constants.ADMIN); // 책 제목 검색

            bookNumber = InputBookNumber();

            if (!bookDao.IsCheckingBookExistence(bookNumber)) //  도서관에 책 존재 x
            {
                Message.RedColor(Message.PrintNoneBook());
            }

            else if (bookDao.IsCheckingBookExistence(bookNumber)) //도서관에 책 존재 o
            {
                bookName = bookDao.BringBookname(bookNumber); // 해당 책 제목 가져오기
                bookDao.close(); // db닫기 위치 애매함 나중에 수정
                logDao.StoreLog(Constants.ADMIN, Constants.REMOVE, bookName); // db에 로그 내역 저장

                bookDao.RemoveBookInformation(bookNumber); // 책 삭제
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

        
    }
}
