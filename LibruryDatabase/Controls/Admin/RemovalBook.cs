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
        //Screen Menu = new Screen();

        public Screen Print;

        public RemovalBook()
        {

        }

        public RemovalBook(Screen Menu) : base(Menu)
        {
            this.Print = Menu;
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
                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }
                    default: continue;
                }

            }
        }
        
        public void RemoveBook()
        {
            string bookNumber;
            bool isBookExitence;
            string bookName;

            Console.Clear();
            Print.PrintSearchBookName();
            Print.PrintBookData(); // 책 목록 프린트

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("책 제거 : Enter                                         뒤로가기 : ESC");
            Console.ResetColor();

            if (Print.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(Constants.isFail, "관리자"); // 책 제목 검색

            bookNumber = InputBookNumber();
            isBookExitence = BookData.Get().IsCheckingBookExistence(bookNumber);// 도서관에 책 있는지 체크

            if (isBookExitence == Constants.isFail)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("존재하지 않는 책입니다.  뒤로가기 : ESC    프로그램 종료 : F5");
                Console.ResetColor();
            }
            else if (isBookExitence == Constants.isPassing)
            {
                bookName = BookData.Get().BringBookname(bookNumber);// 해당 책 정보가져오기
                LogData.Get().StoreLog("관리자", "도서삭제", bookName); // 로그에 저장
                BookData.Get().RemoveBookInformation(bookNumber); // 책 삭제
                

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("책이 삭제되었습니다.  뒤로가기 : ESC    프로그램 종료 : F5");
                Console.ResetColor();
            }

            GoBackMenu();
        }



        string InputBookNumber() // 책 번호 입력
        {
            string bookNumber;
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("삭제할 책 번호 :");

            while (Constants.isPassing)
            {           
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                bookNumber = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.Write("다시 입력해주세요 :"); continue;
                }
                break;
            }
            return bookNumber;         
        }

        
    }
}
