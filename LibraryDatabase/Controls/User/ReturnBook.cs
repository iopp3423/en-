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

        private Screen Menu;
        private MessageScreen Message;

        public ReturnBook()
        {
        }

        public ReturnBook(Screen Menu, MessageScreen message)

        {
            this.Menu = Menu;
            this.Message = message;
        }

        public void SelectMenu() //이전 메뉴로 돌아가기
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
                    default: continue;
                }

            }
        }

        public void ShowBorrowBook(string id)
        {
            string bookNumber;
            bool isAlreadyBorrow;
            string bookName;
            string name;

                      
            Console.Clear();
            Menu.PrintBorrowBookData(id);

            Message.GreenColor(Message.PrintReturnBookMessage());


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
            isAlreadyBorrow = BookData.Get().IsCheckingAlreadyBorrowBook(id, bookNumber);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

            if (isAlreadyBorrow == Constants.isFail) // 대여목록에 책이 없음
            {
                Message.RedColor(Message.PrintNoBorrowBookMessage());
                SelectMenu();
                return;
            }

            else // 대여목록에 책 있으면
            {

                BookData.Get().RemoveRetuenBookInformation(id, bookNumber);// 책 반납
                BookData.Get().PlusBook(bookNumber); // 책 수량 증가
                BookData.Get().borrow.Clear(); // 리스트에 대여한 유저 책 초기화
                BookData.Get().bookData.Clear(); // 북 리스트 초기화
                BookData.Get().StoreBookData(); // 리스트에 책 리스트 저장
                BookData.Get().AddBorrowBookToList(); // 리스트에 책 저장 유저 저장

                bookName = BookData.Get().BringBookname(bookNumber);// 해당 책 정보가져오기
                name = UserData.Get().Bringname(id);// 해당 id 이름 가져오기
                LogData.Get().StoreLog(name, Constants.RETURN, bookName); // 로그에 저장

                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                ClearCurrentLine(Constants.CURRENT_LOCATION);


                Message.GreenColor(Message.PrintReturnBook());
                SelectMenu();
            }   
        }


        public string InputBookNumber() // 책 제목, 책 번호 
        {
            string bookNumber;

            Message.PrintInputReturnBookNumber();
            while (Constants.isEntrancing) // 책 번호 입력
            {

                bookNumber = Console.ReadLine();
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK)) // 정규식에 맞지 않으면
                {
                   ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return bookNumber;
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
