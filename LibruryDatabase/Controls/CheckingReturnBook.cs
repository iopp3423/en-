﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;
using LibruryDatabase.Utility;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Controls
{
    internal class CheckingReturnBook
    {
        Screen Menu = new Screen();
        public void moveMenu() //이전 메뉴로 돌아가기
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
                            Menu.PrintUserMenu();
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

        public void ShowBorrowBook(string id)
        {
            string bookNumber;
            bool checkAlreadyReturn;
            bool AlreadyBorrow;

            Console.Clear();
            Menu.PrintBorrowBookData(id);
            bookNumber = InputBookNumber();
            AlreadyBorrow = CheckAlreadyBorrowBook(id, bookNumber);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

            if (AlreadyBorrow == Constants.FAIL)
            {
                Console.Write("대여하지 않은 도서입니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ");
                moveMenu();
            }

            else if (AlreadyBorrow == Constants.PASS)
            {

                checkAlreadyReturn = CheckBookOverlap(id, bookNumber);

                if (checkAlreadyReturn == Constants.PASS)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("이미 반납하셨습니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ");
                    moveMenu();
                }
                else
                {
                    ReturnBook(bookNumber);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("도서를 반납하였습니다. 뒤로가기 : ESC, 프로그램 종료 : F5");
                    moveMenu();
                }
            }
            
        }


        public string InputBookNumber() // 책 제목, 책 번호 
        {
            string bookNumber;

            Console.Write("반납할 책 번호를 입력해주세요 : ");
            while (Constants.ENTRANCE) // 책 번호 입력
            {

                bookNumber = Console.ReadLine();
                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                if (Constants.CHECK == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK)) // 정규식에 맞지 않으면
                {
                    Constants.ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return bookNumber;
        }


        public bool CheckAlreadyBorrowBook(string id, string bookNumber) // 대여한 책인지 체크
        {
            

            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();
                string insertQuery = "SELECT * FROM BORROWMEMBER WHERE id = '" + id + " ';";
                MySqlCommand Command = new MySqlCommand(insertQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["number"].ToString() == bookNumber) return Constants.SUCESS;
                    
                }
                user.Close();
            }
            return Constants.FAIL;
        }


        public bool CheckBookOverlap(string id, string bookNumber) // 데베에서 책 이미반납했는지 체크
        {
            

            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();
                string borrowIdQuery = "SELECT * FROM BORROWMEMBER WHERE id = '" + id + " ';";
                MySqlCommand Command = new MySqlCommand(borrowIdQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["number"].ToString() == bookNumber && userData["returnbook"].ToString() != " ") return Constants.SUCESS; // 해당 번호 책 반납했는지 체크                                     
                }
                user.Close();
            }
            return Constants.FAIL;
          
        }





        public void ReturnBook(string bookNumber) // 로그인한 유저 책 반납
        {
            string returnDay = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            
           
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                string returnBookQuery = "UPDATE BORROWMEMBER SET returnbook = '" + returnDay + "' WHERE number = '" + bookNumber + " ';";

                MySqlCommand Command = new MySqlCommand(returnBookQuery, book);
                Command.ExecuteNonQuery();
            }
            
        }

    }

}