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
        Screen Menu = new Screen();

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

        public void InputBookTitleandBookNumber(string id) // 책 제목, 책 번호 
        {
            string bookNumber;
            bool isAlreadyBorrow;


            Console.Clear();
            Menu.PrintSearchBookName();
            Menu.PrintBookData(); // 책 목록 프린트

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("대여 : Enter                                  뒤로가기 : ESC");
            Console.ResetColor();

            while (Constants.isPassing)
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

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(); // 책 제목 검색

            if (Constants.SEARCH_RESULT_BOOK == Constants.isPassing) // 목록에 책이 있으면 진행
            {
                while (Constants.isEntrancing) // 책 번호 입력
                {

                    Console.Write("  대여하실 책 번호 :");
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

                if (BookData.Get().CheckReturnBook(id, bookNumber) == Constants.isPassing) BookData.Get().RemoveRetuenBookInformation(id, bookNumber); // 반납한 책 확인 후 제거

               
                if (BookData.Get().CheckBookExistence(bookNumber) == Constants.isFail) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("존재하지 않는 책입니다. 뒤로가기 : ESC      프로그램 종료 : F5"); 
                    Console.ResetColor(); GoBackMenu(); 
                    return; 
                }
                if (BookData.Get().CheckBookQuantity(bookNumber) == Constants.isFail) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("도서 수량이 부족합니다. 뒤로가기 : ESC       프로그램 종료 : F5"); 
                    Console.ResetColor(); 
                    GoBackMenu(); 
                    return; 
                }
                

                alreadyBorrow = BookData.Get().CheckBookOverlap(id, bookNumber); // 책 대여 체크

                if (alreadyBorrow == Constants.isFail)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("이미 대여하셨습니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ");
                    Console.ResetColor();
                    GoBackMenu();
                    return;
                }

                BookData.Get().SearchBook(id, bookNumber);
                BookData.Get().MinusBook(bookNumber); // 책 수량 감소
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("대여하였습니다. 뒤로가기 : ESC     프로그램 종료 : F5");
                Console.ResetColor();
                GoBackMenu();
                return;
            }


        }

       
    }
}