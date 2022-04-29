using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;

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
            Console.Write("PW(영어, 숫자 포함(4~10자) :");

        }

        public void PrintInputMessage()
        {
            Console.SetCursorPosition(Constants.ERROR_X, Constants.ERROR_Y);
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.SetCursorPosition(Constants.ERROR_X, Constants.ERROR_Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("입력되었습니다.");
            Console.ResetColor();
        }

        public void PrintLoginErrorMessage()
        {
            Console.SetCursorPosition(Constants.ERROR_X, Constants.ERROR_Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("잘못 입력하셨습니다.");
            Console.ResetColor();
        }

        public void PrintJoinMember()
        {
            Console.WriteLine("ID(영어, 숫자 포함(8~10자) :");
            Console.WriteLine("PW(영어, 숫자 포함(4~10자) :");
            Console.WriteLine("PW확인(영어, 숫자 포함(4~10자) :");
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
        public void PrintSearchBookName()
        {
            Console.Write("입력 : Enter                                              뒤로가기 : ESC ");
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
        }

        public void PrintInputUserName()
        {
            Console.Write("입력 : Enter                                              뒤로가기 : ESC ");
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("이름을 입력하세요 :");
            Console.WriteLine("────────────────────────────────────────────────────────────────────────");
        }


        public void PrintUserData() 
        {

            

            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
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
           
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(Constants.SearchBookQuery, book);
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
            Console.WriteLine("====================================================================");
           
            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
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

            
            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand Command = new MySqlCommand(Constants.SearchMemberQuery, user);
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



        public void PrintBorrowBookData(string id) // 대여한 책 데이터 출력
        {
            

            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(String.Format(Constants.borrowUserQuery,id), book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    Console.Write("책 번호 :");
                    Console.WriteLine(bookData["number"].ToString());
                    Console.Write("책 제목 :");
                    Console.WriteLine(bookData["bookname"].ToString());
                    Console.Write("책 저자 :");
                    Console.WriteLine(bookData["author"].ToString());
                    Console.Write("출판사  :");
                    Console.WriteLine(bookData["publish"].ToString());
                    Console.Write("대여날짜:");
                    Console.WriteLine(bookData["borrowbook"].ToString());
                    Console.Write("반납날짜:");
                    Console.WriteLine(bookData["returnbook"].ToString());
                    Console.WriteLine("===============================================================");
                }
                bookData.Close();
            }
        }

        public void PrintCurrentBorrowBook() // 대여상황
        {
            

            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(Constants.OrderQuery, book);
                MySqlDataReader bookData = Command.ExecuteReader(); // 데이터 읽기

                while (bookData.Read())
                {
                    Console.Write("아이디  :");
                    Console.WriteLine(bookData["id"].ToString());
                    Console.Write("책 번호 :");
                    Console.WriteLine(bookData["number"].ToString());
                    Console.Write("책 제목 :");
                    Console.WriteLine(bookData["bookname"].ToString());
                    Console.Write("책 저자 :");
                    Console.WriteLine(bookData["author"].ToString());
                    Console.Write("출판사  :");
                    Console.WriteLine(bookData["publish"].ToString());
                    Console.Write("대여날짜:");
                    Console.WriteLine(bookData["borrowbook"].ToString());
                    Console.Write("반납날짜:");
                    Console.WriteLine(bookData["returnbook"].ToString());
                    Console.WriteLine("===============================================================");
                }
                bookData.Close();
            }
        }

        public void PrintSearchAuthor(string name)
        {
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();

                MySqlCommand Command = new MySqlCommand(Constants.SearchBookQuery, book);
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
                        Console.WriteLine("=============================================================================");
                        Constants.SEARCH_RESULT_BOOK = Constants.PASS;
                    }

                }
                book.Close();
            }
        }

        public void PrintSearchPublish(string publish)
        {
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();

                MySqlCommand Command = new MySqlCommand(Constants.SearchBookQuery, book);
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
                        Console.WriteLine("=============================================================================");
                        Constants.SEARCH_RESULT_BOOK = Constants.PASS;
                    }
                }
                book.Close();
            }
        }

        public void PrintSearchBookName(string bookName)
        {
            using (MySqlConnection book = new MySqlConnection(Constants.getQuery))
            {
                book.Open();
                MySqlCommand Command = new MySqlCommand(Constants.SearchBookQuery, book);
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
                        Console.WriteLine("============================================================================");
                        Constants.SEARCH_RESULT_BOOK = Constants.PASS;
                    }
                }
                book.Close();
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

        public bool EntranceAfterReturnMenu()
        {
            while (Constants.PASS) // 메뉴 입장한 후 뒤로가기
            {
                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    PrintMain();
                    PrintAdminMenu();
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.BOOK_NAME_Y);
                    return Constants.BACK_MENU;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter) { Constants.ClearCurrentLine(Constants.CURRENT_LOCATION); break; }
            }
            return Constants.PASS;
        }
    }
}
