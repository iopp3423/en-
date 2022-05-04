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
        public MessageScreen Message;

        public NaverSearch(Screen Menu, MessageScreen message)
        {
            this.Print = Menu;
            this.Message = message;
        }
        public NaverSearch()
        {

        }

        private string title = "";
        private string quantity="";
        private string isbn = "";

        public void SearchNaverBook() // 네이버 기본화면
        {
            Console.Clear();
            Print.PrintMain();
            Print.PrintNaverSearch();



            if (Constants.isBackMenu == SelectMenu()) //  책찾기
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
                    default: continue;
                }

            }
        }




        public bool SelectMenu()
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
                    default: break;

                }
            }
        }


        public void SearchTitle() // 제목 입력
        {
          
            while (Constants.isEntrancing) // 책 예외처리
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Message.PrintInputBookName();

                title = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(title, Utility.Exception.AUTHOR_CHECK)) // 정규식에 맞지 않으면
                {

                    Console.SetCursorPosition(Constants.CURRENT_BOOK, Constants.SEARCH_BOOK- Constants.BEFORE_INPUT_LOCATION);
                    Message.RedColor(Message.PrintErrorInputMessage());

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
                Message.PrintBookQunatityInput();
                quantity = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(quantity, Utility.Exception.QUANTITY)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.CURRENT_BOOK, Constants.SEARCH_BOOK - Constants.BEFORE_INPUT_LOCATION);
                    Message.RedColor(Message.PrintErrorInputMessage());

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
                Message.RedColor(Message.PrintNoneInput());
                if (ReEnter() == Constants.isBackMenu) return;// esc-> 뒤로가기 enter -> 재입력
                ClearCurrentLine(Constants.CURRENT_LOCATION);
            }

            else
            {
                BookData.Get().RemoveAllNaverBook(); // 데베 비우기
                BookData.Get().NaverBook.Clear(); // 리스트 비우기
                BookData.Get().StoreNaverBookToList(title, quantity, Constants.isPassing); // 관리자 리스트에 저장

                Message.GreenColor("Enter : 도서대여              뒤로가기 : ESC");
                foreach (NaverBookVO book in BookData.Get().NaverBook) // 데베에 저장
                {
                    BookData.Get().StoreNaverBook(book.title, book.author, book.price, book.publisher, book.publishday, book.isbn, RemoveSpecialCharacterFromString(book.description));
                }            
                Print.PrintNaverBook();                
            }
            
        }

        public void BorrowNaverBook() // 네이버 도서 저장
        {
            isbn = InputISBN();


        }

        public string InputISBN()//isbn입력
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



        public string RemoveSpecialCharacterFromString(string description) // 책 설명 특수문자 제거
        {
            return Regex.Replace(description, Utility.Exception.DESCRIPTION, string.Empty, RegexOptions.Singleline);
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
