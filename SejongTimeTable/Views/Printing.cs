using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SejongTimeTable.Views
{
    internal class Printing
    {
        public void PrintLogin()
        {
            Console.WriteLine(string.Format("{0,60}", " ============================================== SeJong Time Table ================================================"));
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
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                            【 강의시간표 조회 】                                             ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                            【  관심과목 담기  】                                             ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                            【    수강신청     】                                             ㅣ"));
            Console.WriteLine(string.Format("{0,40}", "ㅣ                                            【  수강내역 조회  】                                             ㅣ"));
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

        public void AfterMenu()
        {
            Console.WriteLine(string.Format("{0,40}", "===============================================  강의시간표 조회  ==============================================="));
            Console.WriteLine(string.Format("{0,40}", "                                                                                                               "));
            Console.WriteLine(string.Format("{0,40}", " 【 개설 학과 전공 】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【    이수구분    】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【    교과목명    】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【     교수명     】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【      학년      】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【      조회      】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", "                                                                                                               "));
            Console.WriteLine(string.Format("{0,40}", "===============================================  강의시간표 조회  ==============================================="));
        }

        public void ChooseMajor()
        {
            Console.WriteLine("【 개설 학과 전공 】    <전체>          <컴퓨터공학과>         <지능기전공학부>       <기계항공우주공학부>");
        }
        public void ChooseDivise()
        {
            Console.WriteLine("【    이수구분    】    <전체>            <교양필수>              <전공필수>                <전공선택>");
        }
        public void ChooseClassName()
        {
            Console.WriteLine("【    교과목명    】    <전체>          <신입생세미나>           <C프로그래밍>            <디지털시스템>");
        }
        public void ChooseSearchProfessorName()
        {
            Console.WriteLine("【     교수명     】    <전체>              <1학년>                 <2학년>                    <3학년>           <4학년>");
        }
        public void ChooseCheckClass()
        { 
            Console.WriteLine("【      학년      】     <전체>              <1학년>                 <2학년>                    <3학년>           <4학년>");
        }
        public void Choose()
        {
            Console.WriteLine("【      조회     】");
        }
    }
}
