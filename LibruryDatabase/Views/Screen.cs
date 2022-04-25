﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Views
{
    internal class Screen
    {
       public void PrintMain()
        {
            Console.WriteLine(string.Format("{0,42}", "★          ★★★   ★★★★     ★★★★   ★★★★   ★★★★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★★★       ★★★★   ★★★★   ★★★★      ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★   ★    ★    ★   ★   ★       ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.WriteLine(string.Format("{0,42}", "★★★★★  ★★★   ★★★★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            Console.WriteLine(string.Format("{0,40}", "입력 : Enter                                              뒤로가기 : ESC"));
            Console.Write("\n");
          
        }
        public void PrintUserOrAdmin()
        {
            Console.WriteLine(string.Format("  》:회원모드"));
            Console.WriteLine(string.Format("  》:관리자모드"));
        }
        
        public void PrintLogin()
        {

            Console.WriteLine("ID(영어, 숫자 포함(8~10자) :");
            Console.WriteLine("PW(영어, 숫자 포함(4~10자) :");
            //Console.SetCursorPosition((Console.WindowWidth - "로그인 :".Length) / 2, Console.CursorTop);
            //Console.SetCursorPosition((Console.WindowWidth - "회원가입:".Length) / 2, Console.CursorTop);

        }

        public void PrintJoinMember()
        {
            Console.WriteLine("유저 ID(영어, 숫자 포함(8~10자) :");
            Console.WriteLine("유저 PW(영어, 숫자 포함(4~10자) :");
            Console.WriteLine("유저 PW확인(영어, 숫자 포함(4~10자) :");
            Console.WriteLine("유저 이름(2~5자) :");
            Console.WriteLine("나이 :");
            Console.WriteLine("핸드폰 번호(01x-xxxx-xxxx) :");
            Console.WriteLine("주소 :");  
        }

        public void JoinPrint()
        {
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                          회   원   가   입                       ★"));
            Console.WriteLine(string.Format("{0,34}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,34}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────\n\n\n"));
        }
        public void PrintBack()
        {
            Console.WriteLine(string.Format("{0,40}", "입력 : Enter                                              뒤로가기 : ESC "));
            Console.WriteLine("\n");
        }

        public void JoinOrLogin()
        {
            Console.WriteLine(string.Format("  》회원가입"));
            Console.WriteLine(string.Format("  》로그인"));
        }

        public void PrintUserMenu()
        {
            Console.WriteLine("  》:도서찾기");
            Console.WriteLine("  》:도서대여");
            Console.WriteLine("  》:도서확인");
            Console.WriteLine("  》:회원정보수정");

        }

        public void PrintSearchMenu()
        {
            Console.Write("원하시는 검색 메뉴 -> Enter -> 검색                       뒤로가기 : ESC ");
            Console.WriteLine("\n");
            Console.WriteLine("  》작가명으로찾기 ");
            Console.WriteLine("  》출판사로찾기 ");
            Console.WriteLine("  》제목으로찾기 ");
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
        }


        public void PrintUserData() // 
        {

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string sql = "SELECT * FROM member";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(sql, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
                    Console.Write("아이디 :");
                    Console.WriteLine(userInformation["id"].ToString());
                    Console.Write("비밀번호 :");
                    Console.WriteLine(userInformation["pw"].ToString());
                    Console.Write("이름 :");
                    Console.WriteLine(userInformation["name"].ToString());
                    Console.Write("전화번호 :");
                    Console.WriteLine(userInformation["phone"].ToString());
                    Console.Write("나이 :");
                    Console.WriteLine(userInformation["age"].ToString());
                    Console.Write("주소 :");
                    Console.WriteLine(userInformation["address"].ToString());
                    Console.WriteLine("=======================================================================");
                }
                userInformation.Close();
            }
        }
        public void PrintBookData() // 책 데이터 출력
        {
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "SELECT * FROM book";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
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
                bookData.Close();
            }
        }
        public void PrintLoginUser(string id, string password)
        {
            Console.WriteLine("=======================================================================");

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";
            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string sql = "SELECT * FROM member";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(sql, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
                    if (userInformation["id"].ToString() == id && (userInformation["pw"].ToString() == password))
                    {
                        Console.Write("아이디 :");
                        Console.WriteLine(userInformation["id"].ToString());
                        Console.Write("비밀번호 :");
                        Console.WriteLine(userInformation["pw"].ToString());
                        Console.Write("이름 :");
                        Console.WriteLine(userInformation["name"].ToString());
                        Console.Write("전화번호 :");
                        Console.WriteLine(userInformation["phone"].ToString());
                        Console.Write("나이 :");
                        Console.WriteLine(userInformation["age"].ToString());
                        Console.Write("주소 :");
                        Console.WriteLine(userInformation["address"].ToString());
                        Console.WriteLine("=======================================================================");
                    }
                }
                userInformation.Close();
            }
        }

        public void PrintSearchUser(string name)
        {
            Console.WriteLine("=======================================================================");

            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";
            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string sql = "SELECT * FROM member";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(sql, user);
                MySqlDataReader userInformation = Command.ExecuteReader();

                while (userInformation.Read())
                {
                    if (userInformation["name"].ToString().Contains(name))
                    {
                        Console.Write("아이디 :");
                        Console.WriteLine(userInformation["id"].ToString());
                        Console.Write("비밀번호 :");
                        Console.WriteLine(userInformation["pw"].ToString());
                        Console.Write("이름 :");
                        Console.WriteLine(userInformation["name"].ToString());
                        Console.Write("전화번호 :");
                        Console.WriteLine(userInformation["phone"].ToString());
                        Console.Write("나이 :");
                        Console.WriteLine(userInformation["age"].ToString());
                        Console.Write("주소 :");
                        Console.WriteLine(userInformation["address"].ToString());
                        Console.WriteLine("=======================================================================");
                    }
                }
                userInformation.Close();
            }
        }
        public void PrintUserInformation()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("  ▶ 휴대폰 번호 변경");
            Console.WriteLine("  ▶ 패스워드 변경");
            Console.WriteLine("  ▶ 주소 변경");
        }

        public void PrintAdminMenu()
        {
            Console.WriteLine("  》도서찾기 ");
            Console.WriteLine("  》도서추가 ");
            Console.WriteLine("  》도서삭제 ");
            Console.WriteLine("  》도서수정 ");
            Console.WriteLine("  》회원관리 ");
            Console.WriteLine("  》대여상황 ");
        }
        public void PrintReturnMenu()
        {
            Console.WriteLine("유저 or 관리자 모드 : ESC, 관리자 로그인 : ENTER");
        }
        public void PrintAddBook()
        {
            Console.WriteLine("책 제목(영어, 한글 2~10자) :");
            Console.WriteLine("작가(영어, 한글 2~8자) :");
            Console.WriteLine("출판사(영어 한글 2~8자):");
            Console.WriteLine("출시일(YYYY/MM/DD) :");
            Console.WriteLine("수량(1~3자리 숫자):");
            Console.WriteLine("가격 :");
        }
    }
}