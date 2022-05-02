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

        public Screen Print;
        public MessageScreen Message;

        public RemovalBook()
        {

        }

        public RemovalBook(Screen Menu, MessageScreen message) : base(Menu, message)
        {
            this.Print = Menu;
            this.Message = message;
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

            Message.GreenColor(Message.PrintChooseRemoveBook()); // 안내메시지

            if (Print.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(Constants.isFail, Constants.ADMIN); // 책 제목 검색

            bookNumber = InputBookNumber();
            isBookExitence = BookData.Get().IsCheckingBookExistence(bookNumber);// 도서관에 책 있는지 체크

            if (isBookExitence == Constants.isFail)
            {
                Message.RedColor(Message.PrintNoneBook());
            }
            else if (isBookExitence == Constants.isPassing)
            {
                bookName = BookData.Get().BringBookname(bookNumber);// 해당 책 정보가져오기
                LogData.Get().StoreLog(Constants.ADMIN, Constants.REMOVE, bookName); // 로그에 저장
                BookData.Get().RemoveBookInformation(bookNumber); // 책 삭제


                Message.GreenColor(Message.PrintRemoveBookMessage());
            }

            GoBackMenu();
        }



        string InputBookNumber() // 책 번호 입력
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
