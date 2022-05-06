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
        private Screen Print;
        private MessageScreen Message;
        private LogDAO logDao;
        private LogDTO logDto;
        private memberDAO memberDao;
        private memberDTO memberDto;
        private BorrowBookDAO borrowBookDao;
        private BorrowBookDTO borrowBookDto;
        private BookDAO bookDao;
        private BookDTO bookDto;

        public NaverSearch()
        {

        }

        public NaverSearch(Screen Menu, MessageScreen message)
        {
            this.Print = Menu;
            this.Message = message;
            logDao = new LogDAO();
            logDto = new LogDTO();
            memberDao = new memberDAO();
            memberDto = new memberDTO();
            borrowBookDto = new BorrowBookDTO();
            borrowBookDao = new BorrowBookDAO();
            bookDto = new BookDTO();
            bookDao = new BookDAO();
        }

        private string title = "";
        private string quantity="10";
        private string bookNumber = "";

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
                            if (Y == Constants.CHECK_BOOK) { SearchBook(); return Constants.isBackMenu; } // 검색
                            break;
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
            memberDao.connection(); // db 연결
            logDao.connection(); // db연결
            borrowBookDao.connection(); // db연결
            bookDao.connection(); // db연결

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
            if (title == "")
            {
                Console.SetCursorPosition(Constants.CURRENT_BOOK, Constants.SEARCH_BOOK - Constants.BEFORE_INPUT_LOCATION);
                Message.RedColor(Message.PrintNoneInput());
                if (ReEnter() == Constants.isBackMenu) return;// esc-> 뒤로가기 enter -> 재입력
                ClearCurrentLine(Constants.CURRENT_LOCATION);
            }

            else
            {
                bookDao.RemoveAllNaverBook(); // naver db 초기화
                bookDao.StoreNaverBook(title, quantity);// naver db에 저장
                Console.Clear();
                Message.GreenColor("   >>Enter : 도서대여              뒤로가기 : ESC\n\n");
                Print.PrintRequestBook(bookDao.StoreNaverBookReturn()); // 네이버 검색한 도서 출력
                Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
                InputOrBack();
                return;
            }
            
        }

        public void BorrowNaverBook() // 네이버 도서추가
        {
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            bookNumber = InputbookNumber();

            if(bookDao.isCheckingNaverBookNumber(bookNumber)) // 입력한 책 번호가 검색내역에 있으면 진행
            {
                quantity = InputQuantity();
                bookDao.StoreNaverBookTobook(bookNumber, quantity); // book db에 추가

                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Message.GreenColor("도서가 추가되었습니다.    뒤로가기 : ESC");
                IsGoingReturnMenu();
                return;
            }
            else
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Message.RedColor("없는 번호입니다.    뒤로가기 : ESC");
                IsGoingReturnMenu();
                return;
            }
            
        }

        public string InputbookNumber()//책 번호입력
        {

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
            Message.PrintAddbookNumber();

            while (Constants.isPassing)
            {
                bookNumber = Console.ReadLine();
                if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
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
            return bookNumber;
        }


        public string InputQuantity() // 수량입력
        {

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintQuantityInputMessage();
            while (Constants.isPassing)
            {
                quantity = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

                if (Constants.isFail == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return quantity;
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

        public void InputOrBack()
        {
            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                if(Constants.cursor.Key == ConsoleKey.Enter)
                {
                    BorrowNaverBook();
                    break;
                }
                else if(Constants.cursor.Key == ConsoleKey.Escape)
                {
                    break;
                }
                    
            }
        }
    }
}
