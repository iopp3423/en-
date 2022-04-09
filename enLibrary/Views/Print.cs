using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary.Views
{
    class Print
    {
        public void LibraryPrint()
        {
            Console.WriteLine(string.Format("{0,42}", "★          ★★★   ★★★★     ★★★★   ★★★★   ★★★★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★    ★   ★    ★   ★    ★   ★   ★"));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★★★       ★★★★   ★★★★   ★★★★      ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★  ★★     ★   ★    ★    ★   ★   ★       ★ "));
            Console.WriteLine(string.Format("{0,42}", "★            ★     ★    ★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.WriteLine(string.Format("{0,42}", "★★★★★  ★★★   ★★★★     ★    ★   ★    ★   ★     ★     ★ "));
            Console.Write("\n");
        }
        public void MenuPrint()
        {
            Console.WriteLine(string.Format("{0,42}", "회원모드를 시작하려면 0번을 눌러주세요."));
            Console.WriteLine(string.Format("{0,42}", "관리자모드를 시작하려면 1번을 눌러주세요."));
            Console.WriteLine(string.Format("{0,42}", "도서관 프로그램을 종료하려면 2번을 눌러주세요."));
        }

        public void JoinOrLogin()
        {
            Console.WriteLine(string.Format("{0,41}", "회원가입은 0번을 눌러주세요"));
            Console.WriteLine(string.Format("{0,42}", "로그인은 1번을 눌러주세요."));
            Console.WriteLine(string.Format("{0,42}", "도서관 프로그램을 종료하려면 2번을 눌러주세요."));
        }
        public void Join()
        {
            Console.WriteLine(string.Format("{0,41}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "      ★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "      ★                          회   원   가   입                       ★"));
            Console.WriteLine(string.Format("{0,41}", "      ★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine();
        }
        public void JoinUser()
        {
            Console.Clear();
            Join();
            Console.WriteLine("유저 ID(영어, 숫자 포함(8~10자) : ");
            Console.WriteLine("유저 PW(영어, 숫자 포함(4~10자) : ");
            Console.WriteLine("유저 PW확인(영어, 숫자 포함(4~10자) : ");
            Console.WriteLine("유저 이름(2~5자) : ");
            Console.WriteLine("나이 : ");
            Console.WriteLine("핸드폰 번호(01x-xxxx-xxxx):");
            Console.WriteLine("주소 :");
            Console.WriteLine("순서대로 입력해주세요 :");
        }
        public void PrintLogin() // 로그인 화면
        {
            Console.WriteLine(string.Format("{0,41}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "      ★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "      ★                          ID & PW를 입력해주세요                  ★"));
            Console.WriteLine(string.Format("{0,41}", "      ★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine("ID를 입력해주세요 :");
            Console.WriteLine("PW를 입력해주세요 :");
        }
        public void PrintLoginAfter() // 로그인 후 화면
        {
            Console.WriteLine(string.Format("{0,41}", "0. 뒤로가기"));
            Console.WriteLine(string.Format("{0,41}", "1. 도서찾기"));
            Console.WriteLine(string.Format("{0,41}", "2. 도서대여"));
            Console.WriteLine(string.Format("{0,41}", "3. 대여도서확인"));
            Console.WriteLine(string.Format("{0,41}", "4. 회원정보수정"));
            Console.WriteLine(string.Format("{0,41}", "5. 프로그램 종료"));
            Console.Write(string.Format("{0,41}", "원하시는 메뉴의 번호를 눌러주세요. :"));
        }
        public void PrintSearchMenu() // 도서찾기 메뉴 프린트
        {
            Console.WriteLine("0. 제목으로 찾기");
            Console.WriteLine("1. 작가명으로 찾기");
            Console.WriteLine("2. 출판사로 찾기");
            Console.WriteLine("3. 프로그램 종료");
            Console.Write("원하시는 번호를 눌러주세요 :");
        }
        public void PrintBorrowBook() // 도서찾기 메뉴 프린트
        {
            Console.Write("대여할 책 아이디 : ");
        }
        public void PrintCheckBook()
        {
            Console.Write("반납할 책 아이디 : ");
        }
        public void Id()
        {
            Console.Clear();
            Join();
            Console.Write("유저 ID(영어, 숫자 포함(8~10자) : ");
        }
        public void Pw()
        {
            Join();
            Console.Write("유저 PW(영어, 숫자 포함(4~10자) : ");
        }
        public void PwPass()
        {
            Join();
            Console.Write("유저 PW확인 : ");
        }
        public void Name()
        {
            Join();
            Console.Write("유저 이름(2~5자) : ");
        }
        public void Age()
        {
            Join();
            Console.Write("나이 : ");
        }
        public void CallNumber()
        {
            Join();
            Console.Write("핸드폰 번호(01x-xxxx-xxxx):");
        }
        public void Address()
        {
            Join();
            Console.Write("주소 :");
        }
        public void ReviseUserInformation()
        {
            Console.Write("아이디 수정은 1번을 눌러주세요");
            Console.Write("비밀번호 수정은 2번을 눌러주세요:");
            Console.Write("이름 수정은 3번을 눌러주세요:");
            Console.Write("나이 수정은 4번을 눌러주세요:");
            Console.Write("번호 수정은 5번을 눌러주세요:");
            Console.Write("주소 수정은 6번을 눌러주세요:");
        }

        public void PrintSearchingTitle()
        {
            Console.Write("제목을 입력해주세요 :");
        }
        public void PrintSearchingAuthor()
        {
            Console.Write("작가명을 입력해주세요 :");
        }
        public void PrintSearchingPublisher()
        {
            Console.Write("출판사를 입력해주세요 :");
        }

        public void RevisingInformation()
        {
            Console.WriteLine("1. 핸드폰 번호(01x-xxxx-xxxx)");
            Console.Write("\n");
            Console.WriteLine("2. 유저 PW(영어, 숫자 포함(4~10자)");
            Console.Write("\n");
            Console.WriteLine("3. 나이");
            Console.Write("\n");
            Console.Write("원하시는 메뉴의 번호를 눌러주세요 :");
        }
    }
}
