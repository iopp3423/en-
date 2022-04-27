﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Controls
{
    internal class RemovalBook : SearchingBook
    {
        Screen Menu = new Screen();
        public void GoBackMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.ENTRANCE)
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
        
        public void RemoveBook()
        {
            string bookNumber;
            bool BookExitence;
            Console.Clear();
            Menu.PrintSearchBookName();
            Menu.PrintBookData(); // 책 목록 프린트

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);
            SearchBookName(); // 책 제목 검색

            bookNumber = InputBookNumber();
            BookExitence = CheckBookExistence(bookNumber); // 도서관에 책 있는지 체크

            if (BookExitence == Constants.FAIL)
            {
                Console.Write("존재하지 않는 책 번호입니다.  뒤로가기 : ESC    프로그램 종료 : F5");
            }
            else if (BookExitence == Constants.PASS)
            {
                BookData.Get().RemoveBookInformation(bookNumber); // 책 삭제
                Console.Write("책이 삭제되었습니다.  뒤로가기 : ESC    프로그램 종료 : F5");
            }
            GoBackMenu();
        }



        string InputBookNumber() // 책 번호 입력
        {
            string bookNumber;
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("삭제할 책 번호 :");

            while (Constants.PASS)
            {           
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                bookNumber = Console.ReadLine();

                if (Constants.CHECK == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.Write("다시 입력해주세요 :"); continue;
                }
                break;
            }
            return bookNumber;         
        }

        public bool CheckBookExistence(string bookNumber) // 데베에 책 있는지 체크
        {
            

            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();
                string borrowIdQuery = "SELECT * FROM book WHERE number = '" + bookNumber + " ';";
                MySqlCommand Command = new MySqlCommand(borrowIdQuery, user);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    if (bookData["number"].ToString() == bookNumber) return Constants.SUCESS;
                }
                user.Close();
            }
            return Constants.FAIL;
        }

    }
}