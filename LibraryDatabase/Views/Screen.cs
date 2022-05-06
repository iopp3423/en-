using LibruryDatabase.Models;
using LibruryDatabase.Utility;
using System;
using System.Collections.Generic;

namespace LibruryDatabase.Views
{
    public class Screen
    {
        private memberDAO memberDao;

        public Screen()
        {
            memberDao = new memberDAO();
        }
        

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

        public void PrintUserData(List<memberDTO> member)  // 유저목록 출력
        {
            foreach (memberDTO data in member)
            {
                Console.Write("아이디 :");
                Console.WriteLine(data.Id);
                Console.Write("비밀번호 :");
                Console.WriteLine(data.Password);
                Console.Write("이름 :");
                Console.WriteLine(data.Name);
                Console.Write("전화번호 :");
                Console.WriteLine(data.Phone);
                Console.Write("나이 :");
                Console.WriteLine(data.Age);
                Console.Write("주소 :");
                Console.WriteLine(data.Address);
                Console.WriteLine("=======================================================================");
            }
        }


        public void PrintBookData(List<BookDTO> book) // 책 데이터 출력
        {

            foreach (BookDTO data in book)
            {
                Console.Write("책 번호   :");
                Console.WriteLine(data.Number);
                Console.Write("책 제목   :");
                Console.WriteLine(data.Title);
                Console.Write("책 저자   :");
                Console.WriteLine(data.Author);
                Console.Write("출판사    :");
                Console.WriteLine(data.Publisher);
                Console.Write("출시일    :");
                Console.WriteLine(data.Publishday);
                Console.Write("책 가격   :");
                Console.WriteLine(data.Price);
                Console.Write("isbn      :");
                Console.WriteLine(data.Isbn);
                Console.Write("책 수량   :");
                Console.WriteLine(data.Quantity);
                Console.WriteLine("=======================================================================");
            }
          
    }


        public void PrintLoginUser(List<memberDTO>member, string id, string password)
        {          
            Console.WriteLine("====================================================================");
            foreach (memberDTO data in member)
            {
                if (data.Id.Contains(id) && data.Password.Contains(password))
                {
                    Console.Write("아이디 :");
                    Console.WriteLine(data.Id);
                    Console.Write("비밀번호 :");
                    Console.WriteLine(data.Password);
                    Console.Write("이름 :");
                    Console.WriteLine(data.Name);
                    Console.Write("전화번호 :");
                    Console.WriteLine(data.Phone);
                    Console.Write("나이 :");
                    Console.WriteLine(data.Age);
                    Console.Write("주소 :");
                    Console.WriteLine(data.Address);
                    Console.WriteLine("====================================================================");
                }
            }
        }


        public void PrintSearchUser(List<memberDTO> member, string name)
        {
            Console.WriteLine("=======================================================================");
            { 
                foreach (memberDTO data in member)
                {
                    if (data.Name.Contains(name))
                    {
                        Console.Write("아이디 :");
                        Console.WriteLine(data.Id);
                        Console.Write("비밀번호 :");
                        Console.WriteLine(data.Password);
                        Console.Write("이름 :");
                        Console.WriteLine(data.Name);
                        Console.Write("전화번호 :");
                        Console.WriteLine(data.Phone);
                        Console.Write("나이 :");
                        Console.WriteLine(data.Age);
                        Console.Write("주소 :");
                        Console.WriteLine(data.Address);
                        Console.WriteLine("=======================================================================");
                    }
                }
            }
        }



        public void PrintBorrowBookData(List<BorrowBookDTO> member, string id) // 대여한 책 데이터 출력
        {

            foreach (BorrowBookDTO data in member)
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

        public void PrintCurrentBorrowBook(List<BorrowBookDTO> book) // 대여상황
        {           
            foreach (BorrowBookDTO data in book)
            {

                Console.Write("아이디  :");
                Console.WriteLine(data.Id);
                Console.Write("책 번호 :");
                Console.WriteLine(data.Number);
                Console.Write("책 제목 :");
                Console.WriteLine(data.Title);
                Console.Write("책 저자 :");
                Console.WriteLine(data.Author);
                Console.Write("출판사  :");
                Console.WriteLine(data.Publish);
                Console.Write("대여날짜:");
                Console.WriteLine(data.Borrowbook);
                Console.Write("반납날짜:");
                Console.WriteLine(data.Returnbook);
                Console.WriteLine("=======================================================================");              
            }
        }

        public void PrintSearchAuthor(List<BookDTO> book, string name) // 작가로 검색
        {
            foreach (BookDTO data in book)
            {
                if (data.Author.Contains(name) == Constants.isPassing)
                {
                    Console.Write("책 번호   :");
                    Console.WriteLine(data.Number);
                    Console.Write("책 제목   :");
                    Console.WriteLine(data.Title);
                    Console.Write("책 저자   :");
                    Console.WriteLine(data.Author);
                    Console.Write("출판사    :");
                    Console.WriteLine(data.Publisher);
                    Console.Write("출시일    :");
                    Console.WriteLine(data.Publishday);
                    Console.Write("책 가격   :");
                    Console.WriteLine(data.Price);
                    Console.Write("isbn      :");
                    Console.WriteLine(data.Isbn);
                    Console.Write("책 수량   :");
                    Console.WriteLine(data.Quantity);
                    Console.WriteLine("=======================================================================");
                    Constants.SEARCH_RESULT_BOOK = Constants.isPassing;
                }
            }
           
        }

        public void PrintSearchPublish(List<BookDTO> book, string publish) // 출판사로 검색
        {

            foreach (BookDTO data in book)
            {
                if (data.Publisher.Contains(publish) == Constants.isPassing)
                {
                    Console.Write("책 번호   :");
                    Console.WriteLine(data.Number);
                    Console.Write("책 제목   :");
                    Console.WriteLine(data.Title);
                    Console.Write("책 저자   :");
                    Console.WriteLine(data.Author);
                    Console.Write("출판사    :");
                    Console.WriteLine(data.Publisher);
                    Console.Write("출시일    :");
                    Console.WriteLine(data.Publishday);
                    Console.Write("책 가격   :");
                    Console.WriteLine(data.Price);
                    Console.Write("isbn      :");
                    Console.WriteLine(data.Isbn);
                    Console.Write("책 수량   :");
                    Console.WriteLine(data.Quantity);
                    Console.WriteLine("=======================================================================");
                    Constants.SEARCH_RESULT_BOOK = Constants.isPassing;
                }
            }
        }

        public void PrintSearchBookName(List<BookDTO> book, string bookName) // 책 제목으로 검색
        {
            foreach (BookDTO data in book)
            {
                if (data.Title.Contains(bookName) == Constants.isPassing)
                {
                    Console.Write("책 번호   :");
                    Console.WriteLine(data.Number);
                    Console.Write("책 제목   :");
                    Console.WriteLine(data.Title);
                    Console.Write("책 저자   :");
                    Console.WriteLine(data.Author);
                    Console.Write("출판사    :");
                    Console.WriteLine(data.Publisher);
                    Console.Write("출시일    :");
                    Console.WriteLine(data.Publishday);
                    Console.Write("책 가격   :");
                    Console.WriteLine(data.Price);
                    Console.Write("isbn      :");
                    Console.WriteLine(data.Isbn);
                    Console.Write("책 수량   :");
                    Console.WriteLine(data.Quantity);
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

        public void PrintLog(List<LogDTO> log)
        {
            foreach (LogDTO data in log)
            {
                Console.Write("번호   :");
                Console.WriteLine(data.Number);
                Console.Write("시간   :");
                Console.WriteLine(data.DateTime);
                Console.Write("사용자 :");
                Console.WriteLine(data.Id);
                Console.Write("내역   :");
                Console.WriteLine(data.Record);
                Console.Write("로그   :");
                Console.WriteLine(data.Log);
                Console.WriteLine("=======================================================================");
            }
        }
        public void PrintReMoveLogAfter()
        {
            Console.Write("로그가 삭제되었습니다.              뒤로가기 : ESC");
        }

        public void PrintRemoveAllData()
        {
            Console.Write("  》전체 로그데이터를  삭제하시겠습니까?   YES : Enter\n\n");
        }
        public void PrintStoreData()
        {
            Console.Write("  》로그파일을 저장하시겠습니까?           YES : Enter\n\n");
        }

        public void PrintStoreAfter()
        {
            Console.Write("로그파일이 저장되었습니다.  뒤로가기 : ESC");
        }
        public void PrintRemoveFile()
        {
            Console.Write("  》로그파일을 제거하시겠습니까?    YES : Enter        뒤로가기 : ESC \n\n");
        }

        public void PrintRequestBook(List<BookDTO> book)
        {
            Console.Write("\n\n");
            foreach (BookDTO data in book)
            {
                Console.Write("책 번호 :");
                Console.WriteLine(data.Number);
                Console.Write("책 제목 :");
                Console.WriteLine(data.Title);
                Console.Write("책 저자 :");
                Console.WriteLine(data.Author);
                Console.Write("책 가격 :");
                Console.WriteLine(data.Price);
                Console.Write("출판사  :");
                Console.WriteLine(data.Publisher);
                Console.Write("출시일  :");
                Console.WriteLine(data.Publishday);
                Console.Write("isbn    :");
                Console.WriteLine(data.Isbn);
                Console.Write("책 설명 :");
                Console.WriteLine(data.Description);
                Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            }
        }

        public void PrintUserRequest(List<BookDTO> book)
        {
            Console.Write("\n\n");
            foreach (BookDTO data in book)
            {
                Console.Write("책 번호 :");
                Console.WriteLine(data.Number);
                Console.Write("책 제목 :");
                Console.WriteLine(data.Title);
                Console.Write("책 저자 :");
                Console.WriteLine(data.Author);
                Console.Write("책 가격 :");
                Console.WriteLine(data.Price);
                Console.Write("출판사  :");
                Console.WriteLine(data.Publisher);
                Console.Write("출시일  :");
                Console.WriteLine(data.Publishday);
                Console.Write("isbn    :");
                Console.WriteLine(data.Isbn);
                Console.Write("책 설명 :");
                Console.WriteLine(data.Quantity);
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
