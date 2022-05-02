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

        private string title = "";
        private string quantity="";


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
                            if (Y == Constants.SEARCH_BOOK) { SearchTitle(); } // 제목입력
                            if (Y == Constants.BORROW_BOOK) { InputPrintBookQuantity(); } // 출력할 도서 수량 입력
                            if (Y == Constants.CHECK_BOOK) { SearchBook(); } // 검색
                            break;
                            //return IsGoingReturnMenu();
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


        public void SearchTitle() // 작가로 입력
        {
          
            while (Constants.isEntrancing) // 책 예외처리
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Console.Write("  입력 (영어,한글 2~8자) :");

                title = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(title, Utility.Exception.AUTHOR_CHECK)) // 정규식에 맞지 않으면
                {

                    Console.SetCursorPosition(Constants.CURRENT_BOOK, Constants.SEARCH_BOOK- Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("잘못입력하셨습니다.  재입력 : Enter      뒤로가기 : F5");

                    if (ReEnter() == Constants.isBackMenu) return; // esc-> 뒤로가기 enter -> 재입력

                    else //enter
                    {

                        ClearCurrentLine(Constants.CURRENT_LOCATION);
                        Console.SetCursorPosition(Console.CursorLeft, Constants.SEARCH_BOOK);
                        continue;
                    }
                }

                break;
            }

        }

        public void InputPrintBookQuantity() // 출력권수
        {


            while (Constants.isEntrancing) // 책 예외처리
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Console.Write("  출력할 도서 수 입력    :");
                quantity = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(quantity, Utility.Exception.QUANTITY)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.CURRENT_BOOK, Constants.SEARCH_BOOK - Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("잘못입력하셨습니다.  재입력 : Enter      뒤로가기 : F5");

                    if (ReEnter() == Constants.isBackMenu) return;// esc-> 뒤로가기 enter -> 재입력

                    else //enter
                    {

                        ClearCurrentLine(Constants.CURRENT_LOCATION);
                        Console.SetCursorPosition(Console.CursorLeft, Constants.SEARCH_BOOK+1);
                        continue;
                    }
                }

                break;
            }

        }

        public void SearchBook() // 도서출력
        {
            if (title == "" || quantity == "")
            {
                Console.SetCursorPosition(Constants.CURRENT_BOOK, Constants.SEARCH_BOOK - Constants.BEFORE_INPUT_LOCATION);
                Console.Write("누락된 입력이있습니다.  재입력 : Enter      뒤로가기 : F5");
                if (ReEnter() == Constants.isBackMenu) return;// esc-> 뒤로가기 enter -> 재입력
                ClearCurrentLine(Constants.CURRENT_LOCATION);
            }
            else
            {
                Console.WriteLine();
                BookData.Get().StoreNaverBookToList(title, quantity);
                Print.PrintNaverBook();
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
