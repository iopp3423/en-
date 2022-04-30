﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;
using LibruryDatabase.Utility;

namespace LibruryDatabase.Controls
{
    class StartConnection
    {
        /*
        Screen Menu = new Screen(); // 뷰 클래스 객체생성
        SearchingBook BookSearching = new SearchingBook();
        BorrowingBook BookBorrowing = new BorrowingBook();
        ModificationUser UserModification = new ModificationUser();
        ReturnBook ReturnBook = new ReturnBook();
        */
        Screen Menu = new Screen();
        SearchingBook BookSearching = new SearchingBook();
        LoginOrRegister UserLibruary = new LoginOrRegister();
        Admin AdminLibruary = new Admin();

        public StartConnection()
        {
            BookSearching = new SearchingBook(Menu);
            UserLibruary = new LoginOrRegister(Menu);
        }


     

        public void StartMenu() // 유저 or 관리자
        {
            Console.SetWindowSize(Constants.CONSOLE_SIZE_WIDTH, Constants.CONSOLE_SIZE_HDIGHT); // 콘솔크기 지정
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintUserOrAdmin();
            int Y = Constants.FIRSTY;
            int goingUser = Constants.USER_Y;
            int goingAdmin = Constants.ADMIN_Y;


            // 메인 컨트롤러
            while (Constants.isEntrancing) // 참이면
            {

                Console.SetCursorPosition(Console.CursorLeft, Y);// 처음 좌표
                Constants.cursor = Console.ReadKey(true);

                switch (Constants.cursor.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            Y--;
                            if (Y < Constants.USER_Y) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.ADMIN_Y) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == goingUser) { Console.Clear(); UserLibruary.RegisterOrLogin(); }
                            if (Y == goingAdmin) { Console.Clear(); AdminLibruary.LoginAdmin(); }
                            break;
                        }

                    case ConsoleKey.F5: // 종료
                        {
                            return;
                        }

                    default: break;

                }
            }


        }
    }
}
