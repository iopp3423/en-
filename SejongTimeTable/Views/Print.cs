using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejongTimeTable.Views
{
    internal class Print
    {
        public void PrintLogin()
        {
            Console.WriteLine(string.Format("{0,40}", " ============================================== SeJong Time Table ==============================================="));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                               ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                               ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                               ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                               ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                               ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                               ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                               ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                               ㅣ"));
            Console.WriteLine(string.Format("{0,40}", " =============================================== SeJong Time Table ===============================================\n\n\n\n"));
            Console.WriteLine(string.Format("{0,40}", "                                           학번 / 아이디(8자리 숫자) :                                         "));
            Console.WriteLine(string.Format("{0,40}", "                                             비밀번호(4~10자리 숫자) :                                         "));
        }

        public void PrintMenu()
        {
            Console.WriteLine(string.Format("{0,40}", "===============================================강좌조회 & 수강신청==============================================="));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                              ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                            ※ 강의시간표 조회 ※                                             ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                            ※ 관심과목 담기   ※                                             ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                            ※   수강신청      ※                                             ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                            ※ 수강내역 조회   ※                                             ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                                                                                              ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "===============================================강좌조회 & 수강신청==============================================="));

        }

        public void PrintESC()
        {
            Console.WriteLine("\n\n\nESC : 프로그램 종료 ");
        }
        public void Back()
        {
            Console.WriteLine("                                                                                                    F5 : 뒤로가기 ");
        }
    }
}
