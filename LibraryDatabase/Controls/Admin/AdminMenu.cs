using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class AdminMenu : SearchingBook
    {
        private LogDAO logDao;
        private BorrowBookDAO borrowBookDao;
        private Screen Print;
        private MessageScreen PrintMessage;

        RemovalBook removing = new RemovalBook();
        BookEdition adding = new BookEdition();
        ModificationBook modify = new ModificationBook();
        RemovalUser member = new RemovalUser();
        LogManage Log = new LogManage();
        NaverSearch naver = new NaverSearch();
        ApprovalUserBook book = new ApprovalUserBook(); 

        public AdminMenu()
        {

        }

        public AdminMenu(Screen Menu, MessageScreen message, memberDAO MemberDao, memberDTO MemberDto, LogDAO LogDao, LogDTO LogDto, BookDAO BookDao, BookDTO BookDto, BorrowBookDAO BorrowBookDao, BorrowBookDTO BorrowBookDto)
                         : base(Menu, message, LogDao, BookDao)
        {
            this.Print = Menu;
            this.PrintMessage = message;
            this.logDao = LogDao;
            this.borrowBookDao = BorrowBookDao;

            removing = new RemovalBook(Menu, message, LogDao, LogDto, BookDao, BookDto);
            adding = new BookEdition(Menu, message, LogDao, LogDto, BookDao, BookDto);
            modify = new ModificationBook(Menu, message, LogDao, LogDto, BookDao, BookDto);
            Log = new LogManage(Menu, message, LogDao, LogDto);
            member = new RemovalUser(Menu, message, LogDao, LogDto, MemberDao, MemberDto, BorrowBookDao, BorrowBookDto);
            naver = new NaverSearch(Menu, message, BookDao, BookDto);
            book = new ApprovalUserBook(Menu, message, BookDao, BookDto);

        }


        public void ChooseMenu()
        {
            Console.Clear();
            Print.PrintMain();
            Print.PrintAdminMenu();

            if (Constants.isBack == IsSelectingAdminMenu()) // 컨트롤러
            {
                Console.Clear();
                Print.PrintMain();
                Print.PrintReturnMenu();
                return;
            }
        }



        public bool IsSelectingAdminMenu()
        {
            int Y = Constants.SEARCH_BOOK;

            while (Constants.isEntrancing) // 참이면
            {
                Console.SetCursorPosition(Constants.FIRSTX, Y);
                Constants.cursor = Console.ReadKey(true);

                switch (Constants.cursor.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            Y--;
                            if (Y < Constants.SEARCH_BOOK) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.REQUEST) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.SEARCH_BOOK) { SearchBook(Constants.isAdminSearching, Constants.ADMIN); break; } // 관리자 도서검색
                            if (Y == Constants.ADD_BOOK) { adding.AddBook(); break; } // 책 추가 클래스 이동
                            if (Y == Constants.REMOVE_BOOK) { removing.RemoveBook(); break; } // 책 제거 클래스 이동
                            if (Y == Constants.REVISE_BOOK) { modify.ModifyBook(); break; } // 책 수정 클래스 이동
                            if (Y == Constants.USER_MANAGE) { member.ModifyMember(); break; } // 회원관리 클래스 이동
                            if (Y == Constants.CURRENT_BOOK) { PrintCurrentBook(); break; }// 대여상황
                            if (Y == Constants.LOG_MANAGE) { Log.PrintLogMenu();break; } // 로그
                            if( Y == Constants.NABER_SEARCH) { naver.SearchNaverBook(); break; } // 네이버도서
                            if (Y == Constants.REQUEST) { book.ApproveUserRequest(); break; } // 유저요청
                            break;
                        }
                     case ConsoleKey.Escape:
                        {
                            return Constants.isBackMenu;
                        }
                    default: break;

                }
            }
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
        public void PrintCurrentBook()
        {
            borrowBookDao.connection(); // db연결
            logDao.connection(); // db연결
            Console.Clear();
            PrintMessage.GreenColor(PrintMessage.PrintBackOrExit());
            logDao.StoreLog(Constants.ADMIN, Constants.BOOK_LIST, Constants.OPEN_LIST); // db에 로그 내역 저장

            Print.PrintCurrentBorrowBook(borrowBookDao.StoreBorrowBookmemberReturn());
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
            GoBackMenu();
        }
    }
}
