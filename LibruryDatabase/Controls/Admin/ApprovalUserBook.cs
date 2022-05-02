using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class ApprovalUserBook
    {
        public Screen Menu;
        public MessageScreen Message;

        string isbn;

        public ApprovalUserBook()
        {
        }

        public ApprovalUserBook(Screen Menu, MessageScreen message)
        {         
            this.Menu = Menu;
            this.Message = message;
        }

        public void ApproveUserRequest() // 책 저장 메서드
        {
            Console.Clear();

            BookData.Get().UserRequestBook.Clear(); // 재조회시 초기화
            BookData.Get().PrintSearchBookName(); // 유저 isbn입력한 데베 리스트에 저장
            Menu.PrintRequestBookList();// 유저가 isbn입력한 책 정보 출력

            Message.GreenColor(Message.PrintContinueRequestmessage()); // 안내메시지
            if (Menu.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            isbn = InputISBN();
            Checkisbn(isbn);

            IsSelectingMenu(); // 뒤로가기
        }


        public void Checkisbn(string Isbn) // isbn 체크 후 bookdata에 저장 -- 수정해야함
        {
            bool isNoneisbn = Constants.isFail;

            foreach (NaverBookVO book in BookData.Get().UserRequestBook)
            {
                if (Isbn == book.isbn)
                {
                    BookData.Get().StoreBookUserRequest(book.title, book.author, book.publisher, book.publishday, book.price, book.isbn, Constants.ADD_BOOK.ToString()); // 책에 정보 저장
                    BookData.Get().RemoveBookData(book.isbn); // 추가한 책 제거
                    isNoneisbn = Constants.isPassing;
                }
            }
            if (isNoneisbn == Constants.isFail)
            {
                Message.PrintNoneIsbnMessage(); //isbn없음 메시지 출력
            }
        }


        string InputISBN()//isbn입력
        {
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
            Message.PrintAddisbn();

            while (Constants.isPassing)
            {               
                isbn = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(isbn, Utility.Exception.ISBN))
                {
                    Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage();
                    continue;
                }
                break;
            }
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
            ClearCurrentLine(Constants.CURRENT_LOCATION);

            Message.GreenColor(Message.PrintDoneInput());
            return isbn;
        }





        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }

        public void IsSelectingMenu() //이전 메뉴로 돌아가기
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
                            Menu.PrintAdminMenu();
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
    }
}
