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
                            if (Constants.APPLY_Y == Constants.APPLY_LOG_Y) { Constants.Is_CHECK = false; ApplySubject(); break; }
                            //if (Constants.APPLY_Y == Constants.APPLY_TABLE_Y) ;
                            if (Constants.APPLY_Y == Constants.APPLY_REMOVE_Y) { Constants.Is_CHECK = false; RemoveSubject(); break; }
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

        public void ApplySubject()
        {
            Console.Clear();
            
            MenuView.PrintMySubject();

            foreach (ClassVO list in Application.Data)
            {
                Console.WriteLine(list);
                
            }
            ;
            GoBack();
        }

        public void RemoveSubject()
        {
            int sum = Constants.ZERO;
            int remove;
            int removeCount = Constants.ZERO;
            bool check = false;
            Console.Clear();

            MenuView.PrintMySubject();
            foreach (ClassVO list in Application.Data)
            {
                Console.WriteLine(list);
                sum += int.Parse(list.score);
            }
            Console.SetCursorPosition(Constants.ZERO, Constants.THREE);
            Console.WriteLine("신청 가능 학점 : {0}      신청 학점 : {1}          신청할 과목 NO :\n\n\n", Constants.APPLY_SCORE - sum, sum);
            Console.SetCursorPosition(Constants.REMOVE_APPLY_X, Constants.THREE);

            remove = int.Parse(Console.ReadLine());

            foreach (ClassVO list in Application.Data)
            {

                if (remove == int.Parse(list.number))
                {
                    check = true; // 번호가 존재
                    Application.Data.RemoveAt(removeCount); // 번호 삭제
                    Console.SetCursorPosition(Constants.REMOVE_APPLY_X, Constants.THREE);
                    Console.Write("강의를 지웠습니다. F5를 누르면 돌아갑니다.");
                    removeCount = Constants.ZERO;
                    break;
                }
                removeCount++;
            }


            if (check == false) // 존재안하면 다시 
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("입력한 번호가 없습니다. Enter : 재입력, F5 : 뒤로가기");
                while (true)
                {
                    
                    Constants.cursur = Console.ReadKey(true);                  
                    if (Constants.cursur.Key == ConsoleKey.Enter) { RemoveSubject(); break; }// 뒤로가기
                    else if (Constants.cursur.Key == ConsoleKey.F5) { GoBack(); break; }// 뒤로가기
                    else continue;
                }
            }


            GoBack();
        }
        public void SearchMenu()
        {
            

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
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_DIVISE_Y) { Constants.Is_CHECK = false; Constants.DIVISE_CURSUR_Y += Constants.ONE; OpenDivise(Divise());break; }
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_SUBJECT_Y) { Constants.Is_CHECK = false; Constants.NAME_CURSUR_Y += Constants.TWO; OpenSearch(SearchClassName()); break; }
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_PROFESSOR_Y) { Constants.Is_CHECK = false; Constants.PROFESSOR_CURSUR_Y += Constants.THREE; SearchProfessor(SearchProfessorName()); break; }
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_GRADE_Y) { Constants.Is_CHECK = false; Constants.GRADE_CURSUR_Y += Constants.FOUR;SearchMyGrade(SearchGrade()); break; }
                            if (Constants.APPLY_MAGOR_Y == Constants.APPLY_FAVORITE_Y) { Constants.Is_CHECK = false; ChooseFavorite(); break; }
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

        void OpenMajor(int major) // 전공
        {
            string choiceMajor;
            int sum = Constants.ZERO;
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
            Check();
        }


        void OpenDivise(int divise) // 이수구분
        {
            string choiceDivise;
            Information.Clear();


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
            Check();
        }


        public void OpenSearch(string name) // 교과목명 프린트
        {
            Information.Clear();

            foreach (ClassVO list in AllData.Data)
            {
                if (list.classname.Contains(name) == true) { Information.Add(list); }
            }
            Check();
        }

        public void SearchProfessor(string name) // 교수명 프린트
        {
            Information.Clear();

            foreach (ClassVO list in AllData.Data)
            {
                if (list.professor.Contains(name) == true) { Information.Add(list); }
            }
            Check();
        }



        public void SearchMyGrade(int grade) // 학년 프린트
        {

            string choiceGrade;
            Information.Clear();

            switch (grade)
            {
                case 1: choiceGrade = "전체"; break;
                case 2: choiceGrade = "1"; break;
                case 3: choiceGrade = "2"; break;
                case 4: choiceGrade = "3"; break;
                case 5: choiceGrade = "4"; break;
                default: choiceGrade = null; break;
            }

            foreach (ClassVO list in AllData.Data)
            {
                if (list.grade.Contains(choiceGrade) == true) { Information.Add(list); }
            }


            Check();
        }

        void ChooseFavorite() // 관심과목에서 추가
        {          
            string addNumber;
            int number;
            int sum = Constants.ZERO;
            int addCount = Constants.ZERO;
            foreach (ClassVO list in UserData.Data)
            {
                sum += int.Parse(list.score);
            }
            bool check = false;
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(string.Format("                                                                                                      신청 학점 : {0}  추가할 과목 NO : ", sum));

            MenuView.PrintMyClass();


            foreach (ClassVO list in UserData.Data)
            {
                Console.WriteLine(list);
            }


            while (true)
            {
                Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y); //위치 설정
                addNumber = Console.ReadLine();

                if (false == RemoveData.IsMatch(addNumber))
                {
                    Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y);
                    Console.Write("다시 입력해주세요"); continue;
                }
                break;
            }

            number = int.Parse(addNumber);

            foreach (ClassVO list in UserData.Data)
            {

                if (number == int.Parse(list.number))
                {
                    check = true; // 번호가 존재
                    Application.Data.Add(list);// 번호 삭제
                    Console.SetCursorPosition(Constants.REMOVE_APPLY_X, Constants.THREE);
                    Console.Write("강의를 신청하였습니다. F5를 누르면 돌아갑니다.");
                    addCount = Constants.ZERO;
                    break;
                }
                addCount++;
            }



            if (check == false) // 존재안하면 다시 
            {
                Console.Write("입력한 번호가 없습니다. Enter : 재입력, F5 : 뒤로가기");
                while (true)
                {
                    Constants.cursur = Console.ReadKey(true);
                    if (Constants.cursur.Key == ConsoleKey.Enter) { ChooseFavorite(); break; }// 뒤로가기
                    else if (Constants.cursur.Key == ConsoleKey.F5) { GoBack(); break; }// 뒤로가기
                    else continue;
                }
            }



            GoBack();
            Constants.Is_CHECK = true;//초기화

        }


        public void Check()
        {
            string addNumber;
            int sum = Constants.ZERO;
            bool check = false;

            Console.Clear();
            Console.Write("\n\n\n\n");
            Console.WriteLine("신청 가능 학점 : {0}      신청 학점 : {1}          신청할 과목 NO :\n\n\n", Constants.APPLY_SCORE - sum, sum);
            MenuView.PrintClass();

            foreach (ClassVO list in Application.Data) // 신청 학점
            {
                sum += int.Parse(list.score);
            }

            foreach (ClassVO list in Information) // 유저가 선택한 값 출력
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
