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
        private string bookNumber;
        private Screen Menu;
        private MessageScreen Message;
        private LogDAO logDao;
        private LogDTO logDto;
        private memberDAO memberDao;
        private memberDTO memberDto;
        private BorrowBookDAO borrowBookDao;
        private BorrowBookDTO borrowBookDto;
        private BookDAO bookDao;
        private BookDTO bookDto;

        public ApprovalUserBook()
        {
        }

        public ApprovalUserBook(Screen Menu, MessageScreen message)
        {         
            this.Menu = Menu;
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

        public void ApproveUserRequest() // 책 저장 메서드
        {
            string quantity;


            memberDao.connection(); // db 연결
            logDao.connection(); // db연결
            borrowBookDao.connection(); // db연결
            bookDao.connection(); // db연결

            Console.Clear();

            Menu.PrintUserRequest(bookDao.StoreRequestBookReturn());// 유저가 요청한 책 정보 출력

            Message.GreenColor(Message.PrintContinueRequestmessage()); // 안내메시지
            if (Menu.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            bookNumber = InputBookNumber(); // 책 번호 입력

            if (!bookDao.isCheckingRequestBookNumber(bookNumber)) // 책이 없으면
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                Message.RedColor(Message.PrintNoneNumberMessage()); // 책 번호 없음 메시지 출력
                SelectMenu();
                return;
            }
            else
            {
                ClearCurrentLine(Constants.CURRENT_LOCATION);
                quantity = InputQuantity();
                bookDao.StoreRequestBook(bookNumber, quantity); // book db에 저장
                bookDao.DeleteRequestStoreBook(bookNumber);
                SelectMenu(); // 뒤로가기
            }
        }

        public string InputQuantity() // 수량입력
        {
            string quantity;

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
            Message.PrintQuantity();
            while (Constants.isPassing)
            {
                quantity = Console.ReadLine();
                if (Constants.isFail == Regex.IsMatch(quantity, Utility.Exception.QUANTITY))
                {
                    Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);
            ClearCurrentLine(Constants.CURRENT_LOCATION);

            Message.GreenColor(Message.PrintDoneInput());
            return quantity;
        }


        public string InputBookNumber()// 책 번호 입력
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



        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
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
                            Menu.PrintAdminMenu();
                            return;
                        }
                    default: continue;
                }

            }
        }
    }
}
