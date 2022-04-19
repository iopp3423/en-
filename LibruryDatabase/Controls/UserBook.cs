using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class UserBook
    {

        Showing Menu = new Showing(); // 뷰 클래스 객체생성
        SearchingBook BookSearching = new SearchingBook();

        public void StartBookmenu()
        {

            Console.Clear();
            Menu.PrintMain();
            Menu.PrintUserMenu();


            if (Constants.BACK == cursur()) // 마우스 함수
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.JoinOrLogin();
                return;
            }
        }

        public bool cursur()
        {
            int Y = Constants.FIRSTY;
            int searchY = Constants.SEARCH_BOOK;
            int borrowY = Constants.BORROW_BOOK;
            int checkY = Constants.CHECK_BOOK;
            int riviseY = Constants.RIVISE_USER;

            while (Constants.ENTRANCE) // 참이면
            {
                Console.SetCursorPosition(Constants.FIRSTX, Y);
                Constants.cursur = Console.ReadKey(true);

                switch (Constants.cursur.Key)
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
                            if (Y == searchY) { Console.Clear(); BookSearching.SearchBook(); } // 도서찾기
                            if (Y == borrowY) { Console.Clear(); BorrowBook(); } // 도서대여
                            if (Y == checkY) { Console.Clear(); CheckBook(); } // 도서확인
                            if (Y == riviseY) { Console.Clear(); RiviseUser(); } // 회원정보수정
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            return Constants.BACK_MENU;
                        }

                    case ConsoleKey.Escape: // 종료
                        {
                            break;
                        }

                    default: break;

                }
            }
        }
        


        public void BorrowBook()
        {

        }
        public void CheckBook()
        {

        }
        public void RiviseUser()
        {

        }

    }
}
