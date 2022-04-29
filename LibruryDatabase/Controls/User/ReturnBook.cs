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
    internal class ReturnBook
    {
        Screen Menu = new Screen();
        public void ChoiceMenu() //이전 메뉴로 돌아가기
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

        public void ShowBorrowBook(string id)
        {
            string bookNumber;
            bool isCheckAlreadyReturn;
            bool isAlreadyBorrow;

                      
            Console.Clear();                 
            Menu.PrintBorrowBookData(id);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("반납 : Enter                                  뒤로가기 : ESC");
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

           ClearCurrentLine(Constants.CURRENT_LOCATION);
            bookNumber = InputBookNumber();
            isAlreadyBorrow = BookData.Get().CheckAlreadyBorrowBook(id, bookNumber);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

            if (isAlreadyBorrow == Constants.isFail)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("대여하지 않은 도서입니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ");
                Console.ResetColor();
                ChoiceMenu();
                return;
            }

            
            isCheckAlreadyReturn = BookData.Get().CheckUserBorrowedBook(id, bookNumber);

            if (isCheckAlreadyReturn == Constants.isPassing)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                ClearCurrentLine(Constants.CURRENT_LOCATION);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("이미 반납하셨습니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ");
                Console.ResetColor();
                ChoiceMenu();
            }
            else
            {
                BookData.Get().ReturnBook(bookNumber); // 책 반납
                BookData.Get().PlusBook(bookNumber); // 책 수량 증가
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                ClearCurrentLine(Constants.CURRENT_LOCATION);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("도서를 반납하였습니다. 뒤로가기 : ESC, 프로그램 종료 : F5");
                Console.ResetColor();
                ChoiceMenu();
            }
            
            
        }


        public string InputBookNumber() // 책 제목, 책 번호 
        {
            string bookNumber;

            Console.Write("반납할 책 번호를 입력해주세요 : ");
            while (Constants.isEntrancing) // 책 번호 입력
            {

                bookNumber = Console.ReadLine();
               ClearCurrentLine(Constants.CURRENT_LOCATION);
                if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK)) // 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookNumber;
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
