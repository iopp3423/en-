using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;
using LibruryDatabase.Utility;

namespace LibruryDatabase.Controls
{
    internal class UserMenu
    {

        //Screen Menu = new Screen(); // 뷰 클래스 객체생성
        SearchingBook BookSearching = new SearchingBook();
        BorrowingBook BookBorrowing = new BorrowingBook();
        ModificationUser UserModification = new ModificationUser();
        ReturnBook ReturnBook = new ReturnBook();

        public Screen Menu;

        public UserMenu()
        {

        }

        public UserMenu(Screen InputMenu)
        {
            this.Menu = InputMenu;
            BookSearching = new SearchingBook(Menu);
            BookBorrowing = new BorrowingBook(Menu);
            UserModification = new ModificationUser(Menu);
            ReturnBook = new ReturnBook(Menu);
        }

        

       

        public void StartBookmenu(string id, string password) // id, pw정보 저장
        {

            Console.Clear();
            Menu.PrintMain();
            Menu.PrintUserMenu();


            if (Constants.isBack == IsChoosingMenu(id, password)) // 컨트롤러
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.RegisterOrLogin();
                return;
            }
        }

        public bool IsChoosingMenu(string id, string password)
        {
            int Y = Constants.FIRSTY;

            while (Constants.isEntrancing) // 참이면
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
                            if (Y == Constants.SEARCH_BOOK) { Console.Clear(); BookSearching.SearchBook(Constants.isUserSearching, id); } // 도서찾기
                            if (Y == Constants.BORROW_BOOK) { Console.Clear(); BookBorrowing.InputBookTitleandBookNumber(id); } // 도서대여
                            if (Y == Constants.CHECK_BOOK) { Console.Clear();  ReturnBook.ShowBorrowBook(id); } // 도서확인
                            if (Y == Constants.RIVISE_USER) { Console.Clear(); UserModification.ModifyUserInformation(id, password); } // 회원정보수정
                            break;
                        }
                     case ConsoleKey.Escape:
                        {
                            return Constants.isBackMenu;
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
