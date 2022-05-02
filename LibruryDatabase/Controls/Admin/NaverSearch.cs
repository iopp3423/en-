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
    internal class NaverSearch
    {
        public Screen Print;

        public NaverSearch(Screen Menu)
        {
            this.Print = Menu;
        }
        public NaverSearch()
        {

        }


        public void SearchNaverBook() // 네이버 기본화면
        {
            Console.Clear();
            Print.PrintMain();
            Print.PrintNaverSearch();



            if (Constants.isBackMenu == IsSelectingMenu()) //  책찾기
            {
                Console.Clear();
                Print.PrintMain();
                Print.PrintAdminMenu();
                return;
            }
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
                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }
                    default: continue;
                }

            }
        }

        public bool ReEnter() // 잘못입력시 재입력
        {
            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            return Constants.isPassing;
                        }
                    case ConsoleKey.Escape:
                        {
                            return Constants.isFail;
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




        public bool IsSelectingMenu()
        {
            int Y = Constants.SEARCH_BOOK;

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
                            if (Y < Constants.SEARCH_BOOK) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.CHECK_BOOK) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.SEARCH_BOOK) { if(SearchTitle() == SearchTitle()) return Constants.isBackMenu; } // 제목입력
                            if (Y == Constants.BORROW_BOOK) { } // 출력할 도서 수량 입력
                            if (Y == Constants.CHECK_BOOK) { } // 검색

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


        public bool SearchTitle() // 작가로 찾기
        {
            string title;

           
            while (Constants.isEntrancing) // 책 예외처리
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Console.Write("입력 (영어,한글 2~8자) :");

                title = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.SEARCH_BOOK);

                if (Constants.isFail == Regex.IsMatch(title, Utility.Exception.AUTHOR_CHECK)) // 정규식에 맞지 않으면
                {

                    Console.SetCursorPosition(15, Constants.SEARCH_BOOK- Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("잘못입력하셨습니다.  재입력 : Enter      뒤로가기 : F5");

                    if (ReEnter() == Constants.isBackMenu) return Constants.isBackMenu;

                    else
                    {

                        ClearCurrentLine(Constants.CURRENT_LOCATION);

                        Console.SetCursorPosition(24, Constants.SEARCH_BOOK);
                        continue;
                    }
                }

                break;
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
