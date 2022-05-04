using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Utility;
using LibruryDatabase.Models;

namespace LibruryDatabase.Views
{
    public class Screen
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
           ClearCurrentLine(Constants.CURRENT_LOCATION);
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

        public void PrintRegisterMember()
        {
            Console.WriteLine("ID(영어, 숫자 포함(8~10자) :");
            Console.WriteLine("PW(영어, 숫자 포함(4~10자) :");
            Console.WriteLine("PW확인(영어, 숫자 포함(4~10자) :");
            Console.WriteLine("유저 이름(2~5자) :");
            Console.WriteLine("나이 :");
            Console.WriteLine("핸드폰 번호(01x-xxxx-xxxx) :");
            Console.WriteLine("주소(천안시동남구신부동) :");
        }

        public void RegisterPrint()
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

        public void RegisterOrLogin()
        {
            Console.WriteLine(string.Format("  》회원가입"));
            Console.WriteLine(string.Format("  》로그인"));
        }

        public void PrintUserMenu()
        {
            Console.WriteLine("  》:도서찾기");
            Console.WriteLine("  》:도서대여");
            Console.WriteLine("  》:대여확인");
            Console.WriteLine("  》:회원정보수정");
            Console.WriteLine("  》:도서추가요청");
        }

        public void PrintNaverSearch()
        {
            Console.WriteLine("  》:책제목으로찾기");
            Console.WriteLine("  》:검색할 도서권수");
            Console.WriteLine("  》:검색");
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

        public void SearchAftermessage()
        {
            Console.Write("뒤로가기 : ESC");
        }

        public void PrintUserData()  // 유저목록 출력
        {
            foreach (UserVO data in UserData.Get().userData)
            {
                Console.Write("아이디 :");
                Console.WriteLine(data.id);
                Console.Write("비밀번호 :");
                Console.WriteLine(data.password);
                Console.Write("이름 :");
                Console.WriteLine(data.name);
                Console.Write("전화번호 :");
                Console.WriteLine(data.phone);
                Console.Write("나이 :");
                Console.WriteLine(data.age);
                Console.Write("주소 :");
                Console.WriteLine(data.address);
                Console.WriteLine("=======================================================================");
            }
        }


        public void PrintBookData() // 책 데이터 출력
        {

            foreach (BookVO data in BookData.Get().bookData)
            {
                Console.Write("책 번호   :");
                Console.WriteLine(data.number);
                Console.Write("책 제목   :");
                Console.WriteLine(data.title);
                Console.Write("책 저자   :");
                Console.WriteLine(data.author);
                Console.Write("출판사    :");
                Console.WriteLine(data.publisher);
                Console.Write("출시일    :");
                Console.WriteLine(data.publishday);
                Console.Write("책 가격   :");
                Console.WriteLine(data.price);
                Console.Write("isbn      :");
                Console.WriteLine(data.isbn);
                Console.Write("책 수량   :");
                Console.WriteLine(data.quantity);
                Console.WriteLine("=======================================================================");
            }
          
    }


        public void PrintLoginUser(string id, string password)
        {
            Console.WriteLine("====================================================================");
           
            foreach (UserVO data in UserData.Get().userData)
            {
                if(data.id.Contains(id) && data.password.Contains(password))
                {
                    Console.Write("아이디 :");
                    Console.WriteLine(data.id);
                    Console.Write("비밀번호 :");
                    Console.WriteLine(data.password);
                    Console.Write("이름 :");
                    Console.WriteLine(data.name);
                    Console.Write("전화번호 :");
                    Console.WriteLine(data.phone);
                    Console.Write("나이 :");
                    Console.WriteLine(data.age);
                    Console.Write("주소 :");
                    Console.WriteLine(data.address);
                    Console.WriteLine("=======================================================================");
                }
            }
        }


        public void PrintSearchUser(string name)
        {
            Console.WriteLine("=======================================================================");
            { 
                foreach (UserVO data in UserData.Get().userData)
                {
                    if (data.name.Contains(name))
                    {
                        Console.Write("아이디 :");
                        Console.WriteLine(data.id);
                        Console.Write("비밀번호 :");
                        Console.WriteLine(data.password);
                        Console.Write("이름 :");
                        Console.WriteLine(data.name);
                        Console.Write("전화번호 :");
                        Console.WriteLine(data.phone);
                        Console.Write("나이 :");
                        Console.WriteLine(data.age);
                        Console.Write("주소 :");
                        Console.WriteLine(data.address);
                        Console.WriteLine("=======================================================================");
                    }
                }
            }
        }



        public void PrintBorrowBookData(string id) // 대여한 책 데이터 출력
        {
           /*
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
           */

            foreach (BorrowUserVO data in BookData.Get().borrow)
            {
                if (data.id.Contains(id))
                {
                    Console.Write("책 번호 :");
                    Console.WriteLine(data.number);
                    Console.Write("책 제목 :");
                    Console.WriteLine(data.title);
                    Console.Write("책 저자 :");
                    Console.WriteLine(data.author);
                    Console.Write("출판사  :");
                    Console.WriteLine(data.publish);
                    Console.Write("대여날짜:");
                    Console.WriteLine(data.borrowbook);
                    Console.Write("반납날짜:");
                    Console.WriteLine(data.returnbook);
                    Console.WriteLine("=======================================================================");
                }
            }
        }

        public void PrintCurrentBorrowBook() // 대여상황
        {           
            foreach (BorrowUserVO data in BookData.Get().borrow)
            {

                Console.Write("아이디  :");
                Console.WriteLine(data.id);
                Console.Write("책 번호 :");
                Console.WriteLine(data.number);
                Console.Write("책 제목 :");
                Console.WriteLine(data.title);
                Console.Write("책 저자 :");
                Console.WriteLine(data.author);
                Console.Write("출판사  :");
                Console.WriteLine(data.publish);
                Console.Write("대여날짜:");
                Console.WriteLine(data.borrowbook);
                Console.Write("반납날짜:");
                Console.WriteLine(data.returnbook);
                Console.WriteLine("=======================================================================");              
            }          
        }

        public void PrintSearchAuthor(string name) // 작가로 검색
        {
            foreach (BookVO data in BookData.Get().bookData)
            {
                if (data.author.Contains(name) == Constants.isPassing)
                {
                    Console.Write("책 번호   :");
                    Console.WriteLine(data.number);
                    Console.Write("책 제목   :");
                    Console.WriteLine(data.title);
                    Console.Write("책 저자   :");
                    Console.WriteLine(data.author);
                    Console.Write("출판사    :");
                    Console.WriteLine(data.publisher);
                    Console.Write("출시일    :");
                    Console.WriteLine(data.publishday);
                    Console.Write("책 가격   :");
                    Console.WriteLine(data.price);
                    Console.Write("isbn      :");
                    Console.WriteLine(data.isbn);
                    Console.Write("책 수량   :");
                    Console.WriteLine(data.quantity);
                    Console.WriteLine("=======================================================================");
                    Constants.SEARCH_RESULT_BOOK = Constants.isPassing;
                }
            }
           
        }

        public void PrintSearchPublish(string publish) // 출판사로 검색
        {

            foreach (BookVO data in BookData.Get().bookData)
            {
                if (data.publisher.Contains(publish) == Constants.isPassing)
                {
                    Console.Write("책 번호   :");
                    Console.WriteLine(data.number);
                    Console.Write("책 제목   :");
                    Console.WriteLine(data.title);
                    Console.Write("책 저자   :");
                    Console.WriteLine(data.author);
                    Console.Write("출판사    :");
                    Console.WriteLine(data.publisher);
                    Console.Write("출시일    :");
                    Console.WriteLine(data.publishday);
                    Console.Write("책 가격   :");
                    Console.WriteLine(data.price);
                    Console.Write("isbn      :");
                    Console.WriteLine(data.isbn);
                    Console.Write("책 수량   :");
                    Console.WriteLine(data.quantity);
                    Console.WriteLine("=======================================================================");
                    Constants.SEARCH_RESULT_BOOK = Constants.isPassing;
                }
            }
        }

        public void PrintSearchBookName(string bookName) // 책 제목으로 검색
        {
            foreach (BookVO data in BookData.Get().bookData)
            {
                if (data.title.Contains(bookName) == Constants.isPassing)
                {
                    Console.Write("책 번호   :");
                    Console.WriteLine(data.number);
                    Console.Write("책 제목   :");
                    Console.WriteLine(data.title);
                    Console.Write("책 저자   :");
                    Console.WriteLine(data.author);
                    Console.Write("출판사    :");
                    Console.WriteLine(data.publisher);
                    Console.Write("출시일    :");
                    Console.WriteLine(data.publishday);
                    Console.Write("책 가격   :");
                    Console.WriteLine(data.price);
                    Console.Write("isbn      :");
                    Console.WriteLine(data.isbn);
                    Console.Write("책 수량   :");
                    Console.WriteLine(data.quantity);
                    Console.WriteLine("=======================================================================");
                    Constants.SEARCH_RESULT_BOOK = Constants.isPassing;
                }
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
            Console.WriteLine("  》로그관리 ");
            Console.WriteLine("  》네이버도서 ");
            Console.WriteLine("  》유저요청");
        }

        public void PrintLogMenu()
        {

            Console.WriteLine("  》로그수정 ");
            Console.WriteLine("  》로그초기화 ");
            Console.WriteLine("  》로그저장 ");
            Console.WriteLine("  》로그파일삭제 ");
            Console.WriteLine("  》로그확인 ");
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
            Console.WriteLine("ISBN :");
        }

        public void PrintReviseLog()
        {
            Console.Write("삭제할 로그의 번호를 입력해주세요 :");
        }

        public void PrintLog()
        {
            foreach (LogVO x in LogData.Get().PrintLog)
            {
                Console.Write("번호   :");
                Console.WriteLine(x.number);
                Console.Write("시간   :");
                Console.WriteLine(x.dateTime);
                Console.Write("사용자 :");
                Console.WriteLine(x.name);
                Console.Write("내역   :");
                Console.WriteLine(x.record);
                Console.Write("로그   :");
                Console.WriteLine(x.log);
                Console.WriteLine("=======================================================================");
            }
        }
        public void PrintReMoveLogAfter()
        {
            Console.Write("로그가 삭제되었습니다.              뒤로가기 : ESC");
        }

        public void PrintRemoveAllData()
        {
            Console.Write("전체 로그데이터를  삭제하시겠습니까?   YES : Enter");
        }
        public void PrintStoreData()
        {
            Console.Write("로그파일을 저장하시겠습니까?           YES : Enter");
        }

        public void PrintStoreAfter()
        {
            Console.Write("로그파일이 저장되었습니다.  뒤로가기 : ESC");
        }
        public void PrintRemoveFile()
        {
            Console.Write("로그파일을 제거하시겠습니까?    YES : Enter        뒤로가기 : ESC ");
        }


        public void PrintNaverBook()
        {
            Console.Write("\n\n");
            foreach (NaverBookVO book in BookData.Get().NaverBook)
            {
                Console.Write("책 제목 :");
                Console.WriteLine(book.title);
                Console.Write("책 저자 :");
                Console.WriteLine(book.author);
                Console.Write("책 가격 :");
                Console.WriteLine(book.price);
                Console.Write("출판사  :");
                Console.WriteLine(book.publisher);
                Console.Write("출시일  :");
                Console.WriteLine(book.publishday);
                Console.Write("isbn    :");
                Console.WriteLine(book.isbn);
                Console.Write("책 설명 :");
                Console.WriteLine(book.description);
                Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            }
        
        }
        public void PrintRequestBook()
        {
            Console.Write("\n\n");
            foreach (NaverBookVO book in BookData.Get().NaverBook)
            {
                Console.Write("책 제목 :");
                Console.WriteLine(book.title);
                Console.Write("책 저자 :");
                Console.WriteLine(book.author);
                Console.Write("책 가격 :");
                Console.WriteLine(book.price);
                Console.Write("출판사  :");
                Console.WriteLine(book.publisher);
                Console.Write("출시일  :");
                Console.WriteLine(book.publishday);
                Console.Write("isbn    :");
                Console.WriteLine(book.isbn);
                Console.Write("책 설명 :");
                Console.WriteLine(book.description);
                Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            }
           
        }

        
        public void PrintRequestBookList()
        {
            Console.Write("\n\n");
            foreach (NaverBookVO book in BookData.Get().UserRequestBook)
            {
               
                Console.Write("책 제목 :");
                Console.WriteLine(book.title);
                Console.Write("책 저자 :");
                Console.WriteLine(book.author);
                Console.Write("책 가격 :");
                Console.WriteLine(book.price);
                Console.Write("출판사  :");
                Console.WriteLine(book.publisher);
                Console.Write("isbn    :");
                Console.WriteLine(book.isbn);
                Console.Write("책 설명 :");
                Console.WriteLine(book.description);
                Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
                
            }
        }
        


        public bool IsGoingBackMenu()
        {
            while (Constants.isPassing) // 메뉴 입장한 후 뒤로가기
            {
                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    PrintMain();
                    PrintAdminMenu();
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.BOOK_NAME_Y);
                    return Constants.isBackMenu;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter) {ClearCurrentLine(Constants.CURRENT_LOCATION); break; }
            }
            return Constants.isPassing;
        }


        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }




    }
}
