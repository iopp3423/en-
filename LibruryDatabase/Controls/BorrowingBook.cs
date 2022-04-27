using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Exception;
using MySql.Data.MySqlClient;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;

namespace LibruryDatabase.Controls
{
    internal class BorrowingBook : SearchingBook
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
                alreadyBorrow = CheckBookOverlap(id, bookNumber); // 책 대여 체크

                if (alreadyBorrow == Constants.PASS)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("이미 대여하셨습니다. 뒤로가기 : ESC, 프로그램 종료 : F5 ");
                    moveMenu();
                }
                else SearchBook(id, bookNumber);
            }            
        }

        public bool CheckBookOverlap(string id, string bookNumber) // 데베에서 책 대여했는지 체크
        {
            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();              
                string borrowIdQuery = "SELECT * FROM BORROWMEMBER WHERE id = '" + id + " ';";
                MySqlCommand Command = new MySqlCommand(borrowIdQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["number"].ToString() == bookNumber && userData["returnbook"].ToString() != " ") return Constants.SUCESS;
                }
                user.Close();
            }
            return Constants.FAIL;

        }


        public void SearchBook(string id, string number) // 로그인한 유저 아이디값, 책 번호 전달받음
        {

            string bookName = null;
            string author= null;
            string publish= null;

            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";


            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "SELECT name, author, publish FROM book WHERE number = '" + number + "';";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    bookName = (bookData["name"].ToString());    
                    author = (bookData["author"].ToString());       
                    publish = (bookData["publish"].ToString());        
                }
                bookData.Close();
            }

            AddBorrowBook(id, number, bookName, author, publish); // 책 대여 함수에 데이터 전송
        }


        
        public void AddBorrowBook(string id, string number, string bookName, string author, string publish) // 로그인한 유저 책 대여
        {
            string borrowDay = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";
            
            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string borrowIdQuery = "INSERT INTO BORROWMEMBER(id, number, bookname, author, publish, borrowbook, returnbook) VALUES('" + id + "','" + number + "','" + bookName + "','" + author + "','" + publish + "','" + borrowDay + "','" + ' ' + "');";

                MySqlCommand Command = new MySqlCommand(borrowIdQuery, book);
                Command.ExecuteNonQuery();
            }
            
        }
       
    }
}
