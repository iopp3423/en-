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
    internal class LogManage
    {
        public Screen Print;

        public LogManage()
        {
        }

        public LogManage(Screen Menu)
        {
            this.Print = Menu;
        }


        public void PrintLogMenu() // 로그메뉴 프린트
        {
            Console.Clear();
            Print.PrintMain();
            Print.PrintLogMenu();


            if (Constants.isBack == SelectLogMenu()) // 컨트롤러
            {
                Console.Clear();
                Print.PrintMain();
                Print.PrintAdminMenu();
                return;
            }
        }


        public bool SelectLogMenu() // 로그메뉴 내 이동
        {
            int Y = Constants.SEARCH_BOOK;

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
                            if (Y > Constants.REVISE_BOOK) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.SEARCH_BOOK) {  } // 로그수정
                            if (Y == Constants.ADD_BOOK) { } // 로그초기화
                            if (Y == Constants.REMOVE_BOOK) { } // 로그저장
                            if (Y == Constants.REVISE_BOOK) {  } // 로그삭제
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
