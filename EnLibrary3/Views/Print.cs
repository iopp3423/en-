using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Views
{
    internal class Print
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
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            Console.WriteLine(string.Format("{0,42}", "  ENTER : 선택                                                   ESC 종료 "));
            Console.Write("\n");
        }
        public void JoinPrint()
        {
            Console.WriteLine(string.Format("{0,41}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                          회   원   가   입                       ★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine();
        }
        public void ChooseJoinLogin()
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
            Console.WriteLine(string.Format("{0,41}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                          ID & PW를 입력해주세요                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★                                                                  ★"));
            Console.WriteLine(string.Format("{0,41}", "★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★"));
            Console.WriteLine(string.Format("{0,40}", "────────────────────────────────────────────────────────────────────────"));
            Console.WriteLine("{0,41}","ID를 입력해주세요 :");
            Console.WriteLine("{0,41}","PW를 입력해주세요 :");
        }

        public void UserOrAdmin()
        {
            LibraryPrint();
            Console.WriteLine(string.Format("{0,36}", "》:회원모드"));
            Console.WriteLine(string.Format("{0,37}", "》:관리자모드"));
        }

        public void BookMenu()
        {
            LibraryPrint();
            Console.WriteLine(string.Format("{0,41}", "도서찾기"));
            Console.WriteLine(string.Format("{0,41}", "도서대여"));
            Console.WriteLine(string.Format("{0,41}", "대여도서확인"));
            Console.WriteLine(string.Format("{0,41}", "회원정보수정"));
        }
    }
}
