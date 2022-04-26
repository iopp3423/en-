using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;
using LibruryDatabase.Exception;

namespace LibruryDatabase.Controls
{
    internal class UserBook
    {

        Screen Menu = new Screen(); // 뷰 클래스 객체생성
        SearchingBook BookSearching = new SearchingBook();
        BorrowingBook BookBorrowing = new BorrowingBook();
        ModificationUser UserModification = new ModificationUser();
        CheckingReturnBook ReturnBook = new CheckingReturnBook();

        public void StartBookmenu(string id, string password) // id, pw정보 저장
        {

            Console.Clear();
            Menu.PrintMain();
            Menu.PrintUserMenu();


            if (Constants.BACK == moveMenu(id, password)) // 컨트롤러
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.JoinOrLogin();
                return;
            }
        }

        public bool moveMenu(string id, string password)
        {
            int Y = Constants.FIRSTY;
            int searchingY = Constants.SEARCH_BOOK;
            int borrowingY = Constants.BORROW_BOOK;
            int checkingY = Constants.CHECK_BOOK;
            int riviseingY = Constants.RIVISE_USER;

            while (Constants.ENTRANCE) // 참이면
            {
                Console.SetCursorPosition(Constants.FIRSTX, Y);
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
                            if (Y > Constants.RIVISE_USER) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == searchingY) { Console.Clear(); BookSearching.SearchBook(Constants.GO_USER_SEARCH); } // 도서찾기
                            if (Y == borrowingY) { Console.Clear(); BookBorrowing.InputBookTitleandBookNumber(id); } // 도서대여
                            if (Y == checkingY) { Console.Clear();  ReturnBook.ShowBorrowBook(); } // 도서확인
                            if (Y == riviseingY) { Console.Clear(); UserModification.ModifyUserInformation(id, password); } // 회원정보수정
                            break;
                        }
                     case ConsoleKey.Escape:
                        {
                            return Constants.BACK_MENU;
                        }

                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }

                    default: break;

                }
            }
        }  

    }
}
