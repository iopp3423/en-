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
    internal class ModificationBook : SearchingBook
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

        public ModificationBook()
        {
        }

        public ModificationBook(Screen Menu, MessageScreen message) : base(Menu, message)
        {
            this.Message = message;
            this.Print = Menu;
            logDao = new LogDAO();
            logDto = new LogDTO();
            memberDao = new memberDAO();
            memberDto = new memberDTO();
            borrowBookDto = new BorrowBookDTO();
            borrowBookDao = new BorrowBookDAO();
            bookDto = new BookDTO();
            bookDao = new BookDAO();
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
                    default: continue;
                }

            }
        }
        public void ModifyBook()
        {
            string number;
            string receiveInput;
            string bookNumber;
            string bookName;

            memberDao.connection(); // db 연결
            logDao.connection(); // db연결
            borrowBookDao.connection(); // db연결
            bookDao.connection(); // db연결

            Console.Clear();
            Print.PrintSearchBookName();
            Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);
            Message.GreenColor(Message.PrintReviseBookInput());
            Print.PrintBookData(bookDao.StoreBookReturn()); // 책 목록 프린트
            Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);


            if (Print.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(Constants.isFail, Constants.ADMIN); // 책 제목 검색

            bookNumber = InputBookNumber(); // 책 번호 입력받기
            if(!bookDao.IsCheckingBookExistence(bookNumber))// 도서목록에 있는 책이면 진행
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Message.RedColor("도서목록에 없는 책입니다.  뒤로가기 : ESC");
                GoBackMenu();
                return;
            }
            number = InputNumber(); // 수정메뉴 입력
            receiveInput = modificationMenu(number); // 가격 or 수량           

            bookDao.ModifyBookInformation(receiveInput, number, bookNumber);// db에서 책 수정


            bookName = bookDao.BringBookname(bookNumber); // 해당 책 제목 가져오기
            bookDao.close(); // db닫기 위치 애매함 나중에 수정
            if (number == Constants.REVISE_BOOK_QUANTITY) logDao.StoreLog(Constants.ADMIN, Constants.REVISE_QUANTITY, bookName); // 로그에 저장
            else logDao.StoreLog(Constants.ADMIN, Constants.REVISE_PRICE, bookName); // 로그에 저장

            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.GreenColor(Message.PrintReviseAfterMessage());
            GoBackMenu();
        }

        public string InputNumber() // 수정메뉴 입력
        {
            string modificatioNumber;

            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintChooseReviseInput();

            while (Constants.isPassing)
            {
                modificatioNumber = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(modificatioNumber, Utility.Exception.MODIFICATION_BOOK))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop-Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return modificatioNumber;
        }


        public string modificationMenu(string number)//메뉴
        {
            string Input = number; // 초기화
            if (int.Parse(number) == Constants.GO_QUANTITY) Input = InputQuantity(); // 수량입력받기
            else if (int.Parse(number) == Constants.GO_PRICE) Input = InputPrice(); // 가격입력받기
            return Input;
        }

        public string InputQuantity() // 수량입력
        {
            string quantity;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintInputQuantity();
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

        public string InputPrice() // 가격입력
        {
            string bookPrice;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
           ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintInputPrice();

            while (Constants.isPassing)
            {            
                bookPrice = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                if (Constants.isFail == Regex.IsMatch(bookPrice, Utility.Exception.PRICE))

                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return bookPrice;
        }

        public string InputBookNumber()//책 번호 입력받기
        {
            string bookNumber;

            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Message.PrintInputBookNumber();

            while (Constants.isPassing)
            {
                bookNumber = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                if (Constants.isFail == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return bookNumber;
        }
    }
}
