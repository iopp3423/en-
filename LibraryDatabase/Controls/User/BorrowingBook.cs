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

        public Screen Print;
        public MessageScreen messagePrint;

        public BorrowingBook()
        {
        }

        public BorrowingBook(Screen Menu, MessageScreen message) : base(Menu, message)
        {
           this.Print = Menu;
           this.messagePrint = message;
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
                            Print.PrintUserMenu();
                            return;
                        }
                    default: continue;
                }

            }
        }

        public void InputBookTitleandBookNumber(string id) // 책 제목, 책 번호 
        {
            string bookNumber;
            bool isAlreadyBorrow;
            string bookName;
            string name;


            Console.Clear();
            Print.PrintSearchBookName();
            Print.PrintBookData(); // 책 목록 프린트

            messagePrint.GreenColor(messagePrint.PrintBorrowBookMessage());

            while (Constants.isPassing) // 뒤로가기 or 입력
            {
                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Print.PrintMain();
                    Print.PrintUserMenu();
                    return;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter) break;
            }


            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(Constants.isPassing, id); // 책 제목 검색

            if (Constants.SEARCH_RESULT_BOOK == Constants.isPassing) // 목록에 책이 있으면 진행
            {
                while (Constants.isEntrancing) // 책 번호 입력
                {

                    messagePrint.PrintBorrowBookNumberMessage();
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

                if (BookData.Get().IsCheckReturnBook(id, bookNumber) == Constants.isPassing) BookData.Get().RemoveRetuenBookInformation(id, bookNumber); // 반납한 책 확인 후 제거

               
                if (BookData.Get().IsCheckingBookExistence(bookNumber) == Constants.isFail) //책 존재 체크
                {
                    messagePrint.RedColor(messagePrint.PrintNoneBook());
                    return; 
                }

                if (BookData.Get().IsCheckongBookQuantity(bookNumber) == Constants.isFail) //책 수량체크
                {
                    messagePrint.RedColor(messagePrint.PrintNoneQuantity());
                    GoBackMenu(); 
                    return; 
                }


                isAlreadyBorrow = BookData.Get().IsCheckingBookOverlap(id, bookNumber); // 책 대여 체크

                if (isAlreadyBorrow == Constants.isFail)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);

                    messagePrint.RedColor(messagePrint.PrintAlreadyBorrowMessage());
                    GoBackMenu();
                }

                else
                {
                    BookData.Get().SearchBook(id, bookNumber);// 책대여                   
                    BookData.Get().MinusBook(bookNumber); // 책 수량 감소
                    BookData.Get().borrow.Clear(); // 리스트에 책 초기화
                    BookData.Get().AddBorrowBookToList(); // 리스트에 책 저장 유저 저장

                    bookName = BookData.Get().BringBookname(bookNumber);// 해당 책 정보가져오기
                    name = UserData.Get().Bringname(id);// 해당 id 이름 가져오기
                    LogData.Get().StoreLog(name, Constants.BORROW, bookName) ; // 로그에 저장

                    messagePrint.GreenColor(messagePrint.PrintDoneBorrowMessage());
                    GoBackMenu();
                    
                }
            }


        }
        
       
    }
}