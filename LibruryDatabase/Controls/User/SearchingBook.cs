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
        Screen Menu = new Screen();


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
                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }
                    default: continue;
                }

            }
        }

        public void SearchBook(bool goingUserOrAdmin)
        {
            Console.Clear();
            Menu.PrintSearchMenu();
            Menu.PrintBookData();

            if (Constants.isBackMenu == IsSelectingMenu() && Constants.isUserSearching == goingUserOrAdmin) // 유저모드용 책찾기
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserMenu();
                return;
            }
            else if (Constants.isBackMenu == IsSelectingMenu() && Constants.isAdminSearching == goingUserOrAdmin) // 관리자모드용 책찾기
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintAdminMenu();
                return;
            }
        }

        public bool IsSelectingMenu()
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
                            if (Y == Constants.NAME_SEARCH_Y) { SearchName();  } // 작가로찾기
                            if (Y == Constants.PUBLISH_Y) { SearchPublishName();} // 출판사로찾기
                            if (Y == Constants.BOOK_Y) { SearchBookName();} // 책이름으로찾기
                            return IsGoingReturnMenu();
                        }
                     case ConsoleKey.Escape:
                        {                           
                            return Constants.isBackMenu;
                        }

                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }

                    default: break;

                }
            }
        }

        public void BookExistenceCheck()
        {
            if (Constants.SEARCH_RESULT_BOOK == Constants.isFail) // 책 정보 없으면
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("찾으시는 책이 없습니다. 뒤로가기 ESC");
                Console.ResetColor();
            }
            else Console.Write("뒤로가기 : ESC, 프로그램 종료 : F5");
           
        }


        public void SearchName() // 작가로 찾기
        {
            string name;
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("입력 (영어,한글 2~8자) :");

            while (Constants.isEntrancing) // 책 예외처리
            {
                name = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.NAME_LINE);
                
                if (Constants.isFail == Regex.IsMatch(name, Utility.Exception.AUTHOR_CHECK)) // 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }

            Console.Clear();
            Menu.PrintSearchAuthor(name); // 출력
            BookExistenceCheck();            
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
        }
       

        public void SearchPublishName() // 출판사로 찾기
        {
            string publish;
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
           ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("입력 (한글 2~8자) :");

            while (Constants.isEntrancing)
            {
                publish = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.PUBLISH_LINE);
                if (Constants.isFail == Regex.IsMatch(publish, Utility.Exception.PUBLISH_CHECK))// 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }

            Console.Clear();

            Menu.PrintSearchPublish(publish);//출력          
            BookExistenceCheck();
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
        }


        public void SearchBookName() // 책제목으로 찾기
        {
            string bookName;
            Constants.SEARCH_RESULT_BOOK = Constants.isFail;
           ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("책 제목 (한글, 영어 2~10자) :");

            while (Constants.isEntrancing)
            {
                bookName = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);

                if (Constants.isFail == Regex.IsMatch(bookName, Utility.Exception.TITLE_CHECK))// 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }

            Console.Clear();

            Menu.PrintSearchBookName(bookName);// 출력            
            BookExistenceCheck();
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);           
        }

        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }

    }
}
