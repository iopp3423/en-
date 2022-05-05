using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;
using System.Text.RegularExpressions;
using LibruryDatabase.Utility;
using MySql.Data.MySqlClient;




namespace LibruryDatabase.Controls
{
    internal class SearchingBook
    {
        private string nameResult;
        private string name;
        private LogDAO logDao;
        private LogDTO logDto;
        private memberDAO memberDao;
        private memberDTO memberDto;
        private BorrowBookDAO borrowBookDao;
        private BorrowBookDTO borrowBookDto;
        private BookDAO bookDao;
        private BookDTO bookDto;

        private Screen Menu;
        MessageScreen message;

        public SearchingBook()
        {
        }

        public SearchingBook(Screen Menu, MessageScreen message)
        {
            this.Menu = Menu;
            this.message = message;
            logDao = new LogDAO();
            logDto = new LogDTO();
            memberDao = new memberDAO();
            memberDto = new memberDTO();
            borrowBookDto = new BorrowBookDTO();
            borrowBookDao = new BorrowBookDAO();
            bookDto = new BookDTO();
            bookDao = new BookDAO();
        }

        

        public bool IsGoingReturnMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            return Constants.isBackMenu;
                        }
                    default: continue;
                }

            }
        }

        public void SearchBook(bool goingUserOrAdmin, string id)
        {
            memberDao.connection(); // db 연결
            logDao.connection(); // db연결
            borrowBookDao.connection(); // db연결
            bookDao.connection(); // db연결

            Console.Clear();
            Menu.PrintSearchMenu();
            Menu.PrintBookData(bookDao.StoreBookReturn()); // 책 목록 출력

            if (Constants.isBackMenu == SelectingMenu(id, Constants.isPassing) && Constants.isUserSearching == goingUserOrAdmin) // 유저모드용 책찾기
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserMenu();
                return;
            }
            else if (Constants.isBackMenu == SelectingMenu(id, Constants.isFail) && Constants.isAdminSearching == goingUserOrAdmin) // 관리자모드용 책찾기
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintAdminMenu();
                return;
            }
        }

        public bool SelectingMenu(string id, bool UserOrAdminSearch)
        {
            int Y = Constants.SEARCH_Y;

            while (Constants.isEntrancing) // 참이면
            {
                Console.SetCursorPosition(Constants.SEARCH_X, Y); 
                Constants.cursor = Console.ReadKey(true);

                switch (Constants.cursor.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            Y--;
                            if (Y < Constants.NAME_SEARCH_Y) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.BOOK_Y) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.NAME_SEARCH_Y) { SearchName(UserOrAdminSearch, id);  } // 작가로찾기
                            if (Y == Constants.PUBLISH_Y) { SearchPublishName(UserOrAdminSearch, id);} // 출판사로찾기
                            if (Y == Constants.BOOK_Y) { SearchBookName(UserOrAdminSearch, id);} // 책이름으로찾기
                            
                            return IsGoingReturnMenu();
                        }
                     case ConsoleKey.Escape:
                        {                           
                            return Constants.isBackMenu;
                        }
                    default: break;

                }
            }
        }

        public void BookExistenceCheck()
        {
            if (Constants.SEARCH_RESULT_BOOK == Constants.isFail) // 책 정보 없으면
            {
                message.RedColor(message.PrintNoBookMessage());
            }
            else message.PrintBack();
        }


        public void SearchName(bool goingUserOrAdmin, string id) // 작가로 찾기
        {
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            message.PrintAuthorInput();

            while (Constants.isEntrancing) // 책 예외처리
            {
                name = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.NAME_LINE);
                
                if (Constants.isFail == Regex.IsMatch(name, Utility.Exception.AUTHOR_CHECK)) // 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    message.PrintReEnterMessage(); continue;
                }
                break;
            }



            Console.Clear();
            Menu.PrintSearchAuthor(bookDao.StoreBookReturn(), name); // 출력
            BookExistenceCheck();

            if (goingUserOrAdmin == Constants.isPassing)
            {
                nameResult = bookDao.BringSearchResult(name); // 해당 책 제목 가져오기
                logDao.StoreLog(id, Constants.SEARCH_AUTHOR, nameResult); // db에 로그 내역 저장
            }
            else
            {
                nameResult = bookDao.BringSearchResult(name); // 해당 책 제목 가져오기
                logDao.StoreLog(id, Constants.ADMIN + Constants.SEARCH_AUTHOR, nameResult); // db에 로그 내역 저장
            }

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            
        }
       

        public void SearchPublishName(bool goingUserOrAdmin, string id) // 출판사로 찾기
        {
            string publish;
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            message.PrintpublishInput();

            while (Constants.isEntrancing)
            {
                publish = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.PUBLISH_LINE);
                if (Constants.isFail == Regex.IsMatch(publish, Utility.Exception.PUBLISH_CHECK))// 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    message.PrintReEnterMessage(); continue;
                }
                break;
            }

            Console.Clear();

            Menu.PrintSearchPublish(bookDao.StoreBookReturn(),publish);//출력          
            BookExistenceCheck();

            if (goingUserOrAdmin == Constants.isPassing)
            {
                nameResult = bookDao.BringSearchResult(publish); // 해당 책 제목 가져오기
                bookDao.close(); // db닫기 위치 애매함 나중에 수정
                logDao.StoreLog(id, Constants.SEARCH_PUBLISHER, nameResult); // db에 로그 내역 저장
            }
            else
            {
                nameResult = bookDao.BringSearchResult(publish); // 해당 책 제목 가져오기
                bookDao.close(); // db닫기 위치 애매함 나중에 수정
                logDao.StoreLog(id, Constants.ADMIN + Constants.SEARCH_PUBLISHER, nameResult); // db에 로그 내역 저장
            }

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
        }


        public void SearchBookName(bool goingUserOrAdmin, string id) // 책제목으로 찾기
        {
            string bookName;
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            message.PrintBookTitle();

            while (Constants.isEntrancing)
            {
                bookName = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);

                if (Constants.isFail == Regex.IsMatch(bookName, Utility.Exception.TITLE_CHECK))// 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    message.PrintReEnterMessage(); continue;
                }
                break;
            }
            Console.Clear();

            bookDao.connection();
            Menu.PrintSearchBookName(bookDao.StoreBookReturn(),bookName);// 출력            
            bookDao.close();
            BookExistenceCheck();
            
            if (goingUserOrAdmin == Constants.isPassing)
            {
                nameResult = bookDao.BringSearchResult(bookName); // 해당 책 제목 가져오기
                bookDao.close(); // db닫기 위치 애매함 나중에 수정

                logDao.connection();
                logDao.StoreLog(id, Constants.SEARCH_TITLE, nameResult); // db에 로그 내역 저장
                logDao.close();
            }
            else
            {
                nameResult = bookDao.BringSearchResult(bookName); // 해당 책 제목 가져오기
                bookDao.close(); // db닫기 위치 애매함 나중에 수정

                logDao.connection();
                logDao.StoreLog(id, Constants.ADMIN + Constants.SEARCH_TITLE, nameResult); // db에 로그 내역 저장
                logDao.close();
            }
            


            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);           
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
