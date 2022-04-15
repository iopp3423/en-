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

        public void PrintNumber()
        {
            Console.WriteLine("\n\n\n원하시는 메뉴 Enter --->  번호 입력 ----> Enter. ");
        }
        public void AfterMenu()
        {
            Console.WriteLine(string.Format("{0,40}", "=========================================================  강의시간표 조회  ========================================================="));
            Console.WriteLine(string.Format("{0,40}", "                                                                                                               "));
            Console.WriteLine(string.Format("{0,40}", " 【 개설 학과 전공 】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【    이수구분    】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【    교과목명    】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【     교수명     】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【      학년      】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", " 【      조회      】                                                                                           "));
            Console.WriteLine(string.Format("{0,40}", "                                                                                                               "));
            Console.WriteLine(string.Format("{0,40}", "=========================================================  강의시간표 조회  ========================================================="));
        }

        public void ChooseMajor()
        {
            Console.WriteLine("【 개설 학과 전공 】    <1번 전체>   <2번 컴퓨터공학과>   <3번 소프트웨어학과>   <4번 지능기전공학부>   <5번 기계항공우주공학부>");
        }

        public void ChooseDivise()
        {
            Console.WriteLine("【    이수구분    】    <1번 전체>      <2번 교양필수>        <3번 전공필수>         <4번 전공선택>");
        }
        public void ChooseClassName()
        {
            Console.WriteLine("【    교과목명    】    교과목명(2~10자) :");
        }
        public void ChooseSearchProfessorName()
        {
            Console.WriteLine("【     교수명     】    교수명 (2~10자) : ");
        }
        public void ChooseCheckClass()
        { 
            Console.WriteLine("【      학년      】    <1번 전체>      <2번 1학년>        <3번 2학년>       <4번 3학년>       <5번 4학년>");
        }
        public void Choose()
        {
            Console.WriteLine("【      조회      】");
        }

        public void PrintFavoriteClass()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(string.Format("{0,40}", "=========================================================  관심 과목 메뉴  =========================================================\n"));
            Console.WriteLine(string.Format("{0,40}", "                                                     【 관심 과목 분야별 검색】                                                    \n"));
            Console.WriteLine(string.Format("{0,40}", "                                                     【  관심 과목 강의 내역 】                                                     \n"));
            Console.WriteLine(string.Format("{0,40}", "                                                     【   관심 과목 시간표   】                                                    \n"));
            Console.WriteLine(string.Format("{0,40}", "                                                     【    관심 과목 삭제    】                                                     \n"));
            Console.WriteLine(string.Format("{0,40}", "=========================================================  관심 과목 메뉴  ========================================================="));
        }

        public void PrintMyTable() // 관심 과목 시간표
        {
            Console.WriteLine("\n");
            Console.WriteLine(string.Format("{0,40}",  "                                                                                                                             F5 : 뒤로가기 "));
            Console.WriteLine(string.Format("{0,40}", "===========================================================  관심 과목 메뉴  ============================================================="));
            Console.WriteLine(string.Format("{0,40}", "                        월                        화                        수                       목                        금"));
        }

        public void PrintMyClass()
        {
            Console.WriteLine(string.Format("{0,40}", "                                                                                                                             F5 : 뒤로가기 "));
            Console.WriteLine(string.Format("{0,40}", "===========================================================  나의 관심 강의  ============================================================="));
            Console.WriteLine(string.Format("{0,40}", "NO    개설학과전공    학수번호    분반    교과목명         이수구분       학년 학점     요일 및 강의시간     강의실      교수명     강의언어"));
            
        }
        public void PrintTimeTable()
        {
            Console.WriteLine("09:00~09:30\n");
            Console.WriteLine("09:30~10:00\n");
            Console.WriteLine("10:00~10:30\n");
            Console.WriteLine("10:30~11:00\n");
            Console.WriteLine("11:30~12:00\n");
            Console.WriteLine("12:30~01:00\n");
            Console.WriteLine("13:00~13:30\n");
            Console.WriteLine("13:30~14:00\n");
            Console.WriteLine("14:00~14:30\n");
            Console.WriteLine("14:30~15:00\n");
            Console.WriteLine("15:00~15:30\n");
            Console.WriteLine("15:30~16:00\n");
            Console.WriteLine("16:00~16:30\n");
            Console.WriteLine("16:30~17:00\n");
            Console.WriteLine("17:00~17:30\n");
            Console.WriteLine("17:30~18:00\n");
            Console.WriteLine("18:00~18:30\n");
            Console.WriteLine("18:30~19:00\n");
            Console.WriteLine("19:00~19:30\n");
            Console.WriteLine("19:00~20:00\n");          
        }

        public void PrintTable()
        {
            Console.WriteLine(string.Format("{0,40}", "NO       개설학과전공      학수번호     분반     교과목명        이수구분      학년 학점      요일 및 강의시간     강의실       교수명     강의언어\n"));
        }
    }
}
