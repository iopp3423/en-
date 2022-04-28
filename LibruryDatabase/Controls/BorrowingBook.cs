using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Utility;
using MySql.Data.MySqlClient;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class BorrowingBook : SearchingBook
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

        public void InputBookTitleandBookNumber(string id) // 책 제목, 책 번호 
        {
            string bookNumber;
            bool alreadyBorrow;
            

            Console.Clear();
            Menu.PrintSearchBookName();
            Menu.PrintBookData(); // 책 목록 프린트

            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.BOOK_Y);            
            SearchBookName(); // 책 제목 검색
            
            if (Constants.SEARCH_RESULT_BOOK == Constants.PASS) // 찾는 책이 없을 시 건너뜀
            {
                while (Constants.ENTRANCE) // 책 번호 입력
                {

                    Console.Write("  대여하실 책 번호 :");
                    bookNumber = Console.ReadLine();
                    
                    if (Constants.CHECK == Regex.IsMatch(bookNumber, Utility.Exception.BOOKNUMBER_CHECK)) // 정규식에 맞지 않으면
                    {
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                        Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        continue;
                    }
                    break;
                }

                alreadyBorrow = BookData.Get().CheckBookOverlap(id, bookNumber); // 책 대여 체크

                if (alreadyBorrow == Constants.FAIL)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("이미 대여하셨습니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ");
                    GoBackMenu();
                }
                else if (alreadyBorrow == Constants.PASS)
                {
                    BookData.Get().SearchBook(id, bookNumber);
                    Console.Write("대여하였습니다. 뒤로가기 : ESC     프로그램 종료 : F5");
                    GoBackMenu();
                }
            }            
        }


        // 잘못만듬 나중에 지우자 - 로그인한 아이디가 책 빌렸는지 확인
        public bool CheckBorrowId(string id)
        {
            using (MySqlConnection user = new MySqlConnection(Constants.getQuery))
            {
                user.Open();
                string borrowIdQuery = "SELECT * FROM BORROWMEMBER";

                MySqlCommand Command = new MySqlCommand(borrowIdQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id) return Constants.PASS; // 책 빌린 회원 id 있음
                }
                user.Close();
            }
            return Constants.FAIL; // 책 빌린 회원 id 없음
        }
    }
    
}
