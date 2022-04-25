﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Exception;

namespace LibruryDatabase.Controls
{
    internal class AdminMenu : SearchingBook
    {
        RemovingBook removing = new RemovingBook();
        AddingBook adding = new AddingBook();
        ModificationBook modify = new ModificationBook();
        ModificationAdmin member = new ModificationAdmin();
        Screen Menu = new Screen();
        public void ChooseMenu()
        {
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintAdminMenu();

            if (Constants.BACK == moveMenu()) // 컨트롤러
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintReturnMenu();
                return;
            }
        }

        public bool moveMenu()
        {
            int Y = Constants.SEARCH_BOOK;

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
                            if (Y > Constants.CURRENT_BOOK) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.SEARCH_BOOK) { SearchBook(Constants.GO_ADMIN_SEARCH); break; } // 관리자 도서검색
                            if (Y == Constants.ADD_BOOK) { adding.AddBook(); break; } // 책 추가 클래스 이동
                            if (Y == Constants.REMOVE_BOOK) { removing.RemoveBook(); break; } // 책 제거 클래스 이동
                            if (Y == Constants.REVISE_BOOK) { modify.ModifyBook(); break; } // 책 수정 클래스 이동
                            if (Y == Constants.USER_MANAGE) { member.ModifyMember(); break; } // 회원관리 클래스 이동
                            if (Y == Constants.CURRENT_BOOK) break;
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