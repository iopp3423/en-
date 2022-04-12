using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnLibrary3.Models;

namespace EnLibrary3.Views
{
    internal class Print
    {
        ListVO List = new ListVO();
        public void LibraryPrint()
        {
            Console.WriteLine(string.Format("{0,42}", "★          ★★★   ★★★★     ★★★★   ★★★★   ★★★★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★★★       ★★★★   ★★★★   ★★★★      ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★   ★    ★    ★   ★   ★       ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.WriteLine(string.Format("{0,42}", "★★★★★  ★★★   ★★★★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            Console.WriteLine(string.Format("{0,42}", "  ENTER : 선택                                                   ESC 종료 "));
            Console.Write("\n");
        }
        public void JoinPrint()
        {
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                          회   원   가   입                       ★"));
            Console.WriteLine(string.Format("{0,34}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine();
        }
        public void ChooseJoinLoginPrint()
        {
            Console.WriteLine(string.Format("{0,38}", "》회원가입"));
            Console.WriteLine(string.Format("{0,37}", "》로그인"));
        }


        public void PrintJoinInformation()
        {
            Console.WriteLine("유저 ID(영어, 숫자 포함(8~10자) : ");
            Console.WriteLine("유저 PW(영어, 숫자 포함(4~10자) : ");
            Console.WriteLine("유저 PW확인(영어, 숫자 포함(4~10자) : ");
            Console.WriteLine("유저 이름(2~5자) : ");
            Console.WriteLine("나이 : ");
            Console.WriteLine("핸드폰 번호(01x-xxxx-xxxx):");
            Console.WriteLine("주소 :");
        }
        public void PrintLoginInformation()
        {
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                          ID & PW를 입력해주세요                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            Console.WriteLine("{0,41}","ID를 입력해주세요 :");
            Console.WriteLine("{0,41}","PW를 입력해주세요 :");
        }

        public void PrintUserOrAdmin()
        {
            LibraryPrint();
            Console.WriteLine(string.Format("{0,36}", "》:회원모드"));
            Console.WriteLine(string.Format("{0,37}", "》:관리자모드"));
        }

        public void PrintBookMenu()
        {
            LibraryPrint();
            Console.WriteLine(string.Format("{0,39}", "》도서찾기"));
            Console.WriteLine(string.Format("{0,39}", "》도서대여"));
            Console.WriteLine(string.Format("{0,41}", "》대여도서확인"));
            Console.WriteLine(string.Format("{0,41}", "》회원정보수정"));
        }

        public void PrintSearchMenu()
        {
            Console.WriteLine(string.Format("{0,39}", "》제목으로찾기"));
            Console.WriteLine(string.Format("{0,40}", "》작가명으로찾기"));
            Console.WriteLine(string.Format("{0,39}", "》출판사로찾기"));
        }

        public void PrintBookList()
        {
            foreach (BookVO list in List.BookList)
            {
                Console.WriteLine(list);
                Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            }
        }
        public void PrintBookName()
        {
            Console.WriteLine("제목을 입력해주세요:");
            Console.WriteLine("뒤로가기 : F5");
            Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
        }

        public void PrintUserRevise()
        {
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                         회 원 정 보 수 정                        ★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,35}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
        }

        public void PrintUser()
        {
            Console.WriteLine("   아이디 변경 : ");
            Console.WriteLine(" 비밀번호 변경 :");
            Console.WriteLine(" 전화번호 변경 :");
            Console.WriteLine("     주소 변경 :");
        }

        public void PrintAdminMenu()
        {
            LibraryPrint();
            Console.WriteLine(string.Format("{0,39}", "》도서찾기"));
            Console.WriteLine(string.Format("{0,39}", "》도서추가"));
            Console.WriteLine(string.Format("{0,39}", "》도서삭제"));
            Console.WriteLine(string.Format("{0,39}", "》회원관리"));
        }

        public void PrintAddBook()
        {
            Console.WriteLine(string.Format("{0,39}", "【도서추가】\n\n"));
            Console.WriteLine(string.Format("책 제목(영어, 한글포함(1~15자):"));
            Console.WriteLine(string.Format("작가(영어, 한글포함(1~10자) :"));
            Console.WriteLine(string.Format("출판사(영어, 한글포함(1~8자) :"));
            Console.WriteLine(string.Format("수량(1~99):"));
            Console.WriteLine(string.Format("가격(1~99999) :"));
        }
    }
}
