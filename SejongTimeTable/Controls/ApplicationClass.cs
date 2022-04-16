using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;
using SejongTimeTable.Models;
using System.Text.RegularExpressions;

namespace SejongTimeTable.Controls
{
    internal class ApplicationClass : TimeTable
    {
        Printing MenuView = new Printing();
        List<ClassVO> Information = new List<ClassVO>(); // 유저가 선택한 값 임시저장
        Regex RemoveData = new Regex(Constants.REMOVE_CLASS);


        public ClassVO AllData; // 엑셀값 저장
        public ClassVO UserData;
        public ClassVO Application;

        public ApplicationClass()
        {

        }
        public ApplicationClass(ClassVO AllData, ClassVO UserData, ClassVO Application)
        {
            this.AllData = AllData; // 엑셀값 저장
            this.UserData = UserData; // 유저 관심과목 값 저장
            this.Application = Application; // 수강신청 과목 저장리스트
        }

        public void ApplyMenu()
        {
            Console.Clear();
            MenuView.PrintApply();
            Constants.Is_CHECK = true;

            

            while (Constants.Is_CHECK)
            {
                Console.SetCursorPosition(Constants.APPLY_X, Constants.APPLY_Y);
                Constants.cursur = Console.ReadKey(true);
                switch (Constants.cursur.Key)
                {

                    case ConsoleKey.UpArrow:
                        {
                            Constants.APPLY_Y -= 2;
                            if (Constants.APPLY_Y < Constants.APPLY_UP_Y) Constants.APPLY_Y += 2; // 선택 외의 화면으로 커서 못나감
                            break;
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.APPLY_Y += 2;
                            if (Constants.APPLY_Y > Constants.APPLY_DOWN_Y) Constants.APPLY_Y -= 2; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.F5:
                        {

                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.APPLY_Y == Constants.APPLY_SEARCH_Y) { Constants.Is_CHECK = false; SearchMenu(); break; }
                            //if (Constants.APPLY_Y == Constants.APPLY_LOG_Y) ;
                            //if (Constants.APPLY_Y == Constants.APPLY_TABLE_Y) ;
                            //if (Constants.APPLY_Y == Constants.APPLY_REMOVE_Y) ;
                            break;
                        }
                    case ConsoleKey.Escape: // 종료
                        {
                            return;
                        }

                    default: break;
                }
            }


        }
        public void SearchMenu()
        {
            string menu;
            int majorJudgment = Constants.ONE; // 전공 전체로 초기화
            int diviseJudgment = Constants.ONE; // 이수구분 전체로 초기화
            string nameJudgment = "전체"; // 교과목명 
            string professorJudgment = "전체"; // 교수명 
            int gradeJudgment = Constants.ONE; // 학년 전체로 초기화

            Console.Clear();
            MenuView.ApplyMenu();
            Constants.Is_CHECK = true;


            while (Constants.Is_CHECK)
            {
                Console.SetCursorPosition(Constants.APPLY_MAGOR_X, Constants.APPLY_MAGOR_Y);
                Constants.cursur = Console.ReadKey(true);

                switch (Constants.cursur.Key)
                {

                    case ConsoleKey.UpArrow:
                        {
                            Constants.APPLY_MAGOR_Y--;
                            if (Constants.APPLY_MAGOR_Y < Constants.APPLY_MAGOR_UP) Constants.APPLY_MAGOR_Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.APPLY_MAGOR_Y++;
                            if (Constants.APPLY_MAGOR_Y > Constants.APPLY_MAGOR_DOWN) Constants.APPLY_MAGOR_Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.F5:
                        {

                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_MAGOR) { Constants.Is_CHECK = false; OpenMajor(SearchMajor()); break; }
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_DIVISE_Y) { Constants.Is_CHECK = false; OpenDivise(Divise());break; }
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_SUBJECT_Y) { Constants.Is_CHECK = false; nameJudgment = SearchClassName(); break; }
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_PROFESSOR_Y) { Constants.Is_CHECK = false; professorJudgment = SearchProfessorName(); break; }
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_GRADE_Y) { Constants.Is_CHECK = false; gradeJudgment = SearchGrade(); break; }
                            //if (Constants.APPLY_MAGOR_Y == Constants.APPLY_FAVORITE_Y) 
                            break;
                        }
                    case ConsoleKey.Escape: // 종료
                        {
                            return;
                        }

                    default: break;
                }
            }

        }

        public void ReEnter()
        {
            Console.Write("입력한 번호가 없습니다. 돌아가기 : F5");
            while (true)
            {
                Constants.cursur = Console.ReadKey(true);
                if (Constants.cursur.Key == ConsoleKey.F5) { SearchMenu(); break; }// 뒤로가기
                else continue;
            }
        }
        public void GoBack()
        {
            while (true)
            {
                Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y);
                Constants.cursur = Console.ReadKey(true);
                if (Constants.cursur.Key == ConsoleKey.F5) { ApplyMenu(); break; }// 뒤로가기               
                else continue;
            }
        }

        void OpenMajor(int major)
        {
            string choiceMajor;
            string addNumber;
            int sum = Constants.ZERO;
            int number;
            bool check = false;
            Information.Clear();

            foreach (ClassVO list in Application.Data) // 신청 학점
            {
                sum += int.Parse(list.score);
            }

            switch (major)
            {
                case 1: choiceMajor = "전체"; break;
                case 2: choiceMajor = "컴퓨터공학과"; break;
                case 3: choiceMajor = "소프트웨어학과"; break;
                case 4: choiceMajor = "지능기전공학부"; break;
                case 5: choiceMajor = "기계항공우주공학부"; break;
                default: choiceMajor = null; break;
            }

            foreach (ClassVO list in AllData.Data) // 리스트에 유저가 검색한 값 저장
            {
                if (list.mager.Contains(choiceMajor) == true) {Information.Add(list); }
            }

            Console.Clear();
            Console.Write("\n\n\n\n");
            Console.WriteLine("신청 가능 학점 : {0}      신청 학점 : {1}          신청할 과목 NO :\n\n\n", Constants.APPLY_SCORE - sum, sum);
            MenuView.PrintClass();

            foreach (ClassVO list in Information)
            {
                Console.WriteLine(list);
            }

            while (true)
            {
                Console.SetCursorPosition(Constants.SEARCH_AFTER_X, Constants.SEARCH_AFTER_Y); //커서 위치변경
                addNumber = Console.ReadLine();

                if (false == RemoveData.IsMatch(addNumber))
                {
                    Console.SetCursorPosition(Constants.SEARCH_AFTER_X, Constants.SEARCH_AFTER_Y);
                    Console.Write("다시 입력해주세요"); continue;
                }
                break;
            }

            number = int.Parse(addNumber);

            foreach (ClassVO list in Information)
            {
                if (int.Parse(list.number) == int.Parse(addNumber))
                {
                    sum += int.Parse(list.score);
                    if (Constants.APPLY_SCORE < sum)
                    {
                        Console.Write("가능한 점수를 초과하였습니다. 돌아가려면 F5를 눌러주세요");
                        //GoBack();
                        break;
                    }

                    check = true; // 번호가 존재
                    Application.Data.Add(list); // 관심과목에 추가
                    Console.Write("신청되었습니다! 돌아가려면 F5를 눌러주세요");
                    break;
                }
            }

            if (check == false) // 존재안하면 다시 
            {
                ReEnter();
            }

            Constants.Is_CHECK = true; // 초기화
            GoBack();
        }


        void OpenDivise(int divise) // 이수구분
        {
            string choiceDivise;
            string addNumber;
            int sum = Constants.ZERO;
            int number;
            bool check = false;
            Information.Clear();


            foreach (ClassVO list in Application.Data) // 신청 학점
            {
                sum += int.Parse(list.score);
            }


            switch (divise)
            {
                case 1: choiceDivise = "전체"; break;
                case 2: choiceDivise = "교양필수"; break;
                case 3: choiceDivise = "전공필수"; break;
                case 4: choiceDivise = "전공선택"; break;
                default: choiceDivise = null; break;
            }

            foreach (ClassVO list in AllData.Data)
            {
                if (list.seperation.Contains(choiceDivise) == true) { Information.Add(list); }
            }

            Console.Clear();
            Console.Write("\n\n\n\n");
            Console.WriteLine("신청 가능 학점 : {0}      신청 학점 : {1}          신청할 과목 NO :\n\n\n", Constants.APPLY_SCORE - sum, sum);
            MenuView.PrintClass();

            foreach (ClassVO list in Information)
            {
                Console.WriteLine(list);
            }


            while (true)
            {
                Console.SetCursorPosition(Constants.SEARCH_AFTER_X, Constants.SEARCH_AFTER_Y); //커서 위치변경
                addNumber = Console.ReadLine();

                if (false == RemoveData.IsMatch(addNumber))
                {
                    Console.SetCursorPosition(Constants.SEARCH_AFTER_X, Constants.SEARCH_AFTER_Y);
                    Console.Write("다시 입력해주세요"); continue;
                }
                break;
            }


            number = int.Parse(addNumber);
            //number -= Constants.ONE;


            foreach (ClassVO list in Information)
            {
                if (int.Parse(list.number) == int.Parse(addNumber))
                {
                    sum += int.Parse(list.score);
                    if (Constants.APPLY_SCORE < sum)
                    {
                        Console.Write("가능한 점수를 초과하였습니다. 돌아가려면 F5를 눌러주세요");
                        break;
                    }

                    check = true; // 번호가 존재
                    Application.Data.Add(list); // 관심과목에 추가
                    Console.Write("신청되었습니다! 돌아가려면 F5를 눌러주세요");
                    break;
                }
            }

            if (check == false) // 존재안하면 다시 
            {

                ReEnter();
            }



            Constants.Is_CHECK = true; // 초기화
            GoBack();
        }









    }
}
