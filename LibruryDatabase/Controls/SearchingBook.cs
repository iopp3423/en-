﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;
using System.Text.RegularExpressions;
using LibruryDatabase.Exception;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;



namespace LibruryDatabase.Controls
{
    internal class SearchingBook
    {
        Regex NAME = new Regex(Utility.Exception.AUTHOR_CHECK);
        Regex PUBLISH = new Regex(Utility.Exception.PUBLISH_CHECK);
        Regex TITLE = new Regex(Utility.Exception.TITLE_CHECK);
        Screen Menu = new Screen();

        public void SearchBook(bool goingUserOrAdmin)
        {
            Console.Clear();
            Menu.PrintSearchMenu();
            Menu.PrintBookData();

            if (Constants.BACK == moveMenu() && Constants.GO_USER_SEARCH == goingUserOrAdmin) // 유저모드용 책찾기
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserMenu();
                return;
            }
            else if(Constants.BACK == moveMenu() && Constants.GO_ADMIN_SEARCH == goingUserOrAdmin) // 관리자모드용 책찾기
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintAdminMenu();
                return;
            }
        }

        public bool moveMenu()
        {
            int Y = Constants.SEARCH_Y;

            while (Constants.ENTRANCE) // 참이면
            {
                Console.SetCursorPosition(Constants.SEARCH_X, Y);
                Constants.cursor = Console.ReadKey(true);

                switch (Constants.cursor.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            Y--;
                            if (Y < Constants.NAME_SEARCH_Y) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.BOOK_Y) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.NAME_SEARCH_Y) { SearchName(); } // 도서찾기
                            if (Y == Constants.PUBLISH_Y) { SearchPublishName(); } // 도서대여
                            if (Y == Constants.BOOK_Y) { SearchBookName(); } // 도서확인                          
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
        public void BookExistenceCheck(bool check)
        {
            if (check == Constants.FAIL) // 책 정보 없으면
            {
                Console.Write("찾으시는 책이 없습니다. 뒤로가기 F5");
            }
            else Console.Write("뒤로가기 : F5, 프로그램 종료 : ESC");
        }

        public void SearchName() // 작가로 찾기
        {
            string name;
            bool check = Constants.FAIL;
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("입력 (영어,한글 2~8자) :");

            while (Constants.ENTRANCE) // 책 예외처리
            {
                name = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.NAME_LINE);
                if (Constants.CHECK == NAME.IsMatch(name)) // 정규식에 맞지 않으면
                {
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;

                }
                break;
            }

            Console.Clear();
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "SELECT * FROM book";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    if (bookData["author"].ToString().Contains(name))
                    {
                        Console.Write("책 번호 :");
                        Console.WriteLine(bookData["number"].ToString());
                        Console.Write("책 제목 :");
                        Console.WriteLine(bookData["name"].ToString());
                        Console.Write("책 저자 :");
                        Console.WriteLine(bookData["author"].ToString());
                        Console.Write("출판사  :");
                        Console.WriteLine(bookData["publish"].ToString());
                        Console.Write("책 가격 :");
                        Console.WriteLine(bookData["price"].ToString());
                        Console.Write("책 수량 :");
                        Console.WriteLine(bookData["quantity"].ToString());
                        Console.WriteLine("===============================================================");
                    }
                    check = Constants.PASS;
                }
                book.Close();
            }
            BookExistenceCheck(check);          
        }
        public void SearchPublishName() // 출판사로 찾기
        {
            bool check = Constants.FAIL;
            string publish;
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("입력 (한글 2~8자) :");

            while (Constants.ENTRANCE)
            {
                publish = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.PUBLISH_LINE);
                if (Constants.CHECK == PUBLISH.IsMatch(publish)) // 정규식에 맞지 않으면
                {
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }

            Console.Clear();
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "SELECT * FROM book";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    if (bookData["publish"].ToString().Contains(publish))
                    {
                        Console.Write("책 번호 :");
                        Console.WriteLine(bookData["number"].ToString());
                        Console.Write("책 제목 :");
                        Console.WriteLine(bookData["name"].ToString());
                        Console.Write("책 저자 :");
                        Console.WriteLine(bookData["author"].ToString());
                        Console.Write("출판사  :");
                        Console.WriteLine(bookData["publish"].ToString());
                        Console.Write("책 가격 :");
                        Console.WriteLine(bookData["price"].ToString());
                        Console.Write("책 수량 :");
                        Console.WriteLine(bookData["quantity"].ToString());
                        Console.WriteLine("===============================================================");
                    }
                    check = Constants.PASS;
                }
                book.Close();
            }
            BookExistenceCheck(check);

        }
        public void SearchBookName() // 책제목으로 찾기
        {
            bool check = Constants.FAIL;
            string bookName;
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("책 제목 (한글, 영어 2~10자) :");

            while (Constants.ENTRANCE)
            {
                bookName = Console.ReadLine();
                Console.SetCursorPosition(Constants.SEARCH_X, Constants.BOOKNAME_LINE);
                if (Constants.CHECK == TITLE.IsMatch(bookName)) // 정규식에 맞지 않으면
                {
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }

            Console.Clear();
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "SELECT * FROM book";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    if (bookData["name"].ToString().Contains(bookName))
                    {
                        Console.Write("책 번호 :");
                        Console.WriteLine(bookData["number"].ToString());
                        Console.Write("책 제목 :");
                        Console.WriteLine(bookData["name"].ToString());
                        Console.Write("책 저자 :");
                        Console.WriteLine(bookData["author"].ToString());
                        Console.Write("출판사  :");
                        Console.WriteLine(bookData["publish"].ToString());
                        Console.Write("책 가격 :");
                        Console.WriteLine(bookData["price"].ToString());
                        Console.Write("책 수량 :");
                        Console.WriteLine(bookData["quantity"].ToString());
                        Console.WriteLine("===============================================================");
                    }
                    check = Constants.PASS;
                }
                book.Close();
            }
            BookExistenceCheck(check);
        }


    }
}