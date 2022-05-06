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
        private LogDAO logDao;
        private BorrowBookDAO borrowBookDao;
        private BorrowBookDTO borrowBookDto;
        private BookDAO bookDao;
        private BookDTO bookDto;



        public ReturnBook()
        {
        }

        public ReturnBook(Screen Menu, MessageScreen message)

        {
            this.Menu = Menu;
            this.Message = message;
            logDao = new LogDAO();
            borrowBookDao = new BorrowBookDAO();
            borrowBookDto = new BorrowBookDTO();
            bookDto = new BookDTO();
            bookDao = new BookDAO();
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

            borrowBookDao.connection(); // db 연결
            bookDao.connection(); // db연결
            logDao.connection(); // db연결

            Console.Clear();
            Menu.PrintBorrowBookData(borrowBookDao.StoreBorrowBookmemberReturn(), id);// db에서 책 대여한 유저목록 전달
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

            borrowBookDto.Id = id;
            borrowBookDto.Number = bookNumber;

            isAlreadyBorrow = borrowBookDao.IsCheckingAlreadyBorrowBook(borrowBookDto.Id, borrowBookDto.Number); // 해당 아이디로 true면 대여한 책 있음

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

            if (isAlreadyBorrow == Constants.isFail) // 대여목록에 책이 없음
            {
                Message.RedColor(Message.PrintNoBorrowBookMessage());
                SelectMenu();
                return;
            }

            else // 대여목록에 책 있으면
            {

                borrowBookDao.RemoveRetuenBookInformation(borrowBookDto.Id, borrowBookDto.Number); // db에서 해당 아이디에 있는 책 제거(반납)

                bookDto.Number = bookNumber;
                bookDao.PlusBook(bookDto.Number); // 반납 시 책 수량 1 증가

                bookName = bookDao.BringBookname(bookDto.Number); // 해당 책 제목 가져오기
                bookDao.close(); // db닫기 위치 애매함 나중에 수정
                logDao.StoreLog(id, Constants.RETURN, bookName);// 로그에 저장


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
