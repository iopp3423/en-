﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class AdminMenu : SearchingBook
    {
        RemovalBook removing = new RemovalBook();
        AddingBook adding = new AddingBook();
        ModificationBook modify = new ModificationBook();
        RemovalUser member = new RemovalUser();
        Screen Menu = new Screen();
        public void ChooseMenu()
        {
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintAdminMenu();

            if (Constants.isBack == IsSelectingAdminMenu()) // 컨트롤러
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintReturnMenu();
                return;
            }
        }



        public bool IsSelectingAdminMenu()
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
                            if (Y > Constants.CURRENT_BOOK) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.SEARCH_BOOK) { SearchBook(Constants.isAdminSearching); break; } // 관리자 도서검색
                            if (Y == Constants.ADD_BOOK) { adding.AddBook(); break; } // 책 추가 클래스 이동
                            if (Y == Constants.REMOVE_BOOK) { removing.RemoveBook(); break; } // 책 제거 클래스 이동
                            if (Y == Constants.REVISE_BOOK) { modify.ModifyBook(); break; } // 책 수정 클래스 이동
                            if (Y == Constants.USER_MANAGE) { member.ModifyMember(); break; } // 회원관리 클래스 이동
                            if (Y == Constants.CURRENT_BOOK) // 대여상황
                            { 
                                Console.Clear();
                                Menu.PrintCurrentBorrowBook();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("뒤로가기 : ESC                                프로그램 종료 : F5");
                                Console.ResetColor();
                                GoBackMenu(); 
                            } 
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
                            Menu.PrintMain();
                            Menu.PrintAdminMenu();
                            return;
                        }
                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }
                    default: continue;
                }

            }
        }
    }
}