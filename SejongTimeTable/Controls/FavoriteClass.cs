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
    internal class FavoriteClass :TimeTable
    {
        Printing MenuView = new Printing();
        List<ClassVO> MySubject = new List<ClassVO>();
        Regex RemoveData = new Regex(Constants.REMOVE_CLASS);

        public ClassVO Favorite; // 엑셀값 저장
        public ClassVO UserData;

        public FavoriteClass()
        {

        }
        public FavoriteClass(ClassVO Favorite, ClassVO UserData)
        {
            this.Favorite = Favorite;
            this.UserData = UserData;
        }
        

        public void Menu()
        {
            Constants.Is_CHECK = true; // 초기화
            Console.Clear();
            MenuView.PrintFavoriteClass();          

                

            while (Constants.Is_CHECK) // 관심과목메뉴
            {
                Console.SetCursorPosition(Constants.FAVORITE_MENU_X, Constants.FAVORITE_MENU_Y);
                Constants.cursur = Console.ReadKey(true);
                switch (Constants.cursur.Key)
                {

                    case ConsoleKey.UpArrow:
                        {
                            Constants.FAVORITE_MENU_Y -= Constants.TWO;
                            if (Constants.FAVORITE_MENU_Y < Constants.FAVORITE_UP_Y) Constants.FAVORITE_MENU_Y += Constants.TWO; // 선택 외의 화면으로 커서 못나감
                            break;
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.FAVORITE_MENU_Y += Constants.TWO;
                            if (Constants.FAVORITE_MENU_Y > Constants.FAVORITE_DOWN_Y) Constants.FAVORITE_MENU_Y -= Constants.TWO; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            //LoginId();  ///////////////////////////얘도 한 번 봐야함
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_SEARCH_Y) { Constants.Is_CHECK = false; Search(); break; }
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_MY_Y) { Constants.Is_CHECK = false; SearchMyClass(); break;}
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_TIME_Y) { Constants.Is_CHECK = false; SearchTable(); break; }
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_REMOVE_Y) { Constants.Is_CHECK = false; Remove(); break;}
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

        public void Search() // 관심과목 검색
        {

            string menu;
            int majorJudgment = Constants.ONE; // 전공 전체로 초기화
            int diviseJudgment = Constants.ONE; // 이수구분 전체로 초기화
            string nameJudgment = "전체"; // 교과목명 
            string professorJudgment = "전체"; // 교수명 
            int gradeJudgment = Constants.ONE; // 학년 전체로 초기화
            Constants.Is_CHECK = true;

            Console.Clear();
            MenuView.PrintFavoriteMenu();

            
            while (Constants.Is_CHECK)
            {
                Console.SetCursorPosition(Constants.CHOOSE_X, Constants.CHOOSE_Y);
                Constants.cursur = Console.ReadKey(true);
                switch (Constants.cursur.Key)
                {

                    case ConsoleKey.UpArrow:
                        {
                            Constants.CHOOSE_Y -= Constants.TWO;
                            if (Constants.CHOOSE_Y < Constants.CHOOSE_UP_Y) Constants.CHOOSE_Y += Constants.TWO; // 선택 외의 화면으로 커서 못나감
                            break; 
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.CHOOSE_Y += Constants.TWO;
                            if (Constants.CHOOSE_Y > Constants.CHOOSE_DOWN_Y) Constants.CHOOSE_Y -= Constants.TWO; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            Menu();  
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.CHOOSE_Y == Constants.MAJOR_Y) { Constants.Is_CHECK = false; SearchMyMajor(SearchMajor()); break; }
                            if (Constants.CHOOSE_Y == Constants.NUMBER_Y) { Constants.Is_CHECK = false; Constants.DIVISE_CURSUR_Y += Constants.ONE; SearchMyDivse(Divise()); break; }
                            if (Constants.CHOOSE_Y == Constants.SUBJECT_Y) { Constants.Is_CHECK = false; Constants.NAME_CURSUR_Y += Constants.TWO; SearchName(SearchClassName()); break; }
                            if (Constants.CHOOSE_Y == Constants.PROFESSOR_Y) { Constants.Is_CHECK = false; Constants.PROFESSOR_CURSUR_Y += Constants.THREE; SearchProfessor(SearchProfessorName()); break; }
                            if (Constants.CHOOSE_Y == Constants.GRADE_MENU_Y) { Constants.Is_CHECK = false; Constants.GRADE_CURSUR_Y += Constants.FOUR; SearchMyGrade(SearchGrade()); break; }
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
                if (Constants.cursur.Key == ConsoleKey.F5) { Menu(); break; }// 뒤로가기
                else continue;
            }
        }


        public void SearchMyMajor(int major) // 전공검색 후 프린트
        {
            string choiceMajor;
            MySubject.Clear();


            switch (major)
            {
                case 1: choiceMajor = "전체"; break;
                case 2: choiceMajor = "컴퓨터공학과"; break;
                case 3: choiceMajor = "소프트웨어학과"; break;
                case 4: choiceMajor = "지능기전공학부"; break;
                case 5: choiceMajor = "기계항공우주공학부"; break;
                default: choiceMajor = null; break;
            }

           

            foreach (ClassVO list in Favorite.Data)
            {
                if (list.mager.Contains(choiceMajor) == true) { MySubject.Add(list); }
            }

            SearchClass();
        }

        public void SearchMyDivse(int divise) // 이수구분 선택 후 프린트
        {
            string choiceDivise;

            Constants.DIVISE_CURSUR_Y -= Constants.ONE;
            MySubject.Clear();

            switch (divise)
            {
                case 1: choiceDivise = "전체"; break;
                case 2: choiceDivise = "교양필수"; break;
                case 3: choiceDivise = "전공필수"; break;
                case 4: choiceDivise = "전공선택"; break;
                default: choiceDivise = null; break;
            }

            foreach (ClassVO list in Favorite.Data)
            {
                if (list.seperation.Contains(choiceDivise) == true) { MySubject.Add(list); }
            }

            SearchClass();
        }

        public void SearchName(string name) // 교과목명 프린트
        {
            MySubject.Clear();

            Constants.NAME_CURSUR_Y -= Constants.TWO;// 초기화

            foreach (ClassVO list in Favorite.Data)
            {
                if (list.classname.Contains(name) == true) { MySubject.Add(list); }
            }

            SearchClass();
        }


       

        public void SearchProfessor(string name) // 교수명 프린트
        {
            MySubject.Clear();

            Constants.PROFESSOR_CURSUR_Y += Constants.THREE;// 초기화

            foreach (ClassVO list in Favorite.Data)
            {
                if (list.professor.Contains(name) == true) { MySubject.Add(list); }
            }

            SearchClass();
        }

        public void SearchMyGrade(int grade) // 학년 프린트
        {
            string choiceGrade;
            MySubject.Clear();

            Constants.GRADE_CURSUR_Y += Constants.FOUR;// 초기화

            switch (grade)
            {
                case 1: choiceGrade = "전체"; break;
                case 2: choiceGrade = "1"; break;
                case 3: choiceGrade = "2"; break;
                case 4: choiceGrade = "3"; break;
                case 5: choiceGrade = "4"; break;
                default: choiceGrade = null; break;
            }

            

            foreach (ClassVO list in Favorite.Data)
            {
                if (list.grade.Contains(choiceGrade) == true) { MySubject.Add(list); }
            }

            SearchClass();
        }



        public void SearchMyClass( ) 
        {
            Console.Clear();
            MenuView.PrintMyClass();
            Constants.Is_CHECK = true;//초기화

            Constants.Y = Constants.FOUR;
            foreach (ClassVO list in UserData.Data)
            {

                Console.Write(list.number.PadRight(8)); //NO        
                Console.Write(list.mager.PadRight(10));//전공
                Console.SetCursorPosition(Constants.NUMBER_X, Constants.Y);
                Console.Write(list.classNumber.PadRight(13)); // 학수번호
                Console.Write(list.group.PadRight(7)); // 분반
                Console.Write(list.classname.PadRight(10)); //교과목명
                Console.SetCursorPosition(Constants.CLASS_X, Constants.Y);
                Console.Write(list.seperation.PadRight(10)); // 이수구분
                Console.SetCursorPosition(Constants.GRADE_X, Constants.Y);
                Console.Write(list.grade.PadRight(5)); // 학년
                Console.Write(list.score.PadRight(10)); //학점
                Console.Write(list.day.PadRight(10)); // 요일
                Console.SetCursorPosition(Constants.ROOM_X, Constants.Y);
                Console.Write(list.room.PadRight(10));//강의실
                Console.Write(list.professor.PadRight(10)); //교수명
                Console.SetCursorPosition(Constants.LANGUAGE_X, Constants.Y++);
                Console.Write(list.language.PadRight(10)); // 언어
                Console.WriteLine();
            }

            while (true)
            {
                Constants.cursur = Console.ReadKey(true);
                if (Constants.cursur.Key == ConsoleKey.F5) { Menu(); break; }// 뒤로가기
                else continue;
            }


        }

        public void SearchTable() // 시간표
        {
            
            int row, col;
            string monday = "월";
            string tuesday = "화";
            string wendsday = "수";
            string thursday = "목";
            string friday = "금";
            Console.Clear();
            MenuView.PrintMyTable();
            MenuView.PrintTimeTable();
            //UserData.Data 나의 관심과목

            foreach (ClassVO list in UserData.Data)
            {
                if(list.day.Contains("월"));
                if(list.day.Contains("화"));
                if(list.day.Contains("수"));
                if(list.day.Contains("목"))
                {
                    if (list.day.Contains("18:00~19:00"))
                    {
                        Console.SetCursorPosition(125, 37);
                        Console.WriteLine(list.classname);
                        Console.SetCursorPosition(125, 38);
                        Console.WriteLine(list.room);
                    }
                    if (list.day.Contains("18:00~19:30"))
                    {
                        Console.SetCursorPosition(125, 37);
                        Console.WriteLine(list.classname);
                        Console.SetCursorPosition(125, 38);
                        Console.WriteLine(list.room);
                    }
                    if (list.day.Contains("18:00~20:00"))
                    {
                        Console.SetCursorPosition(125, 37);
                        Console.WriteLine(list.classname);
                        Console.SetCursorPosition(125, 38);
                        Console.WriteLine(list.room);
                    }
                    if (list.day.Contains("18:00~19:00"))
                    {
                        Console.SetCursorPosition(125, 37);
                        Console.WriteLine(list.classname);
                        Console.SetCursorPosition(125, 38);
                        Console.WriteLine(list.room);
                    }
                }
 
                if(list.day.Contains("금"))
                {
                    if (list.day.Contains("18:00~19:00"))
                    {
                        Console.SetCursorPosition(125, 37);
                        Console.WriteLine(list.classname);
                        Console.SetCursorPosition(125, 38);
                        Console.WriteLine(list.room);
                    }
                    if (list.day.Contains("18:00~19:30"))
                    {
                        Console.SetCursorPosition(125, 39);
                        Console.WriteLine(list.mager);
                        Console.SetCursorPosition(125, 40);
                        Console.WriteLine(list.room);
                    }
                    if (list.day.Contains("18:00~20:00"))
                    {
                        Console.SetCursorPosition(125, 39);
                        Console.WriteLine(list.mager);
                        Console.SetCursorPosition(125, 40);
                        Console.WriteLine(list.room);
                    }
                }

                //if (list.mager.Contains(choiceMajor) == true) { MySubject.Add(list); }
            }

            /*
            while (true)
            {
                if()
                Console.SetCursorPosition(25, 5);
                Console.Write("월");
                Console.SetCursorPosition(50, 7);
                Console.Write("화");
                Console.SetCursorPosition(75, 9);
                Console.Write("수");
                Console.SetCursorPosition(100, 11);
                Console.Write("목");
                Console.SetCursorPosition(125, 13);
                Console.Write("금");
            }
            */



            Constants.cursur = Console.ReadKey(true);
            if (Constants.cursur.Key == ConsoleKey.F5) Menu(); // 뒤로가기



            Constants.Is_CHECK = true;//초기화
        }




        public void Remove() // 관심과목 삭제
        {
            string removeNumber;
            int number;
            int sum = Constants.ZERO;
            int removeCount = Constants.ZERO;
            foreach (ClassVO list in UserData.Data)
            {
                sum += int.Parse(list.score);
            }
            bool check = false;
            Console.Clear();
            Console.SetCursorPosition(Constants.ZERO, Constants.ZERO);
            Console.Write(string.Format("                                                                                                      신청 학점 : {0}  삭제할 과목 NO : ", sum));
            
            MenuView.PrintMyClass();

            Constants.Y = Constants.FOUR;
            foreach (ClassVO list in UserData.Data)
            {

                Console.Write(list.number.PadRight(8)); //NO        
                Console.Write(list.mager.PadRight(10));//전공
                Console.SetCursorPosition(Constants.NUMBER_X, Constants.Y);
                Console.Write(list.classNumber.PadRight(13)); // 학수번호
                Console.Write(list.group.PadRight(7)); // 분반
                Console.Write(list.classname.PadRight(10)); //교과목명
                Console.SetCursorPosition(Constants.CLASS_X, Constants.Y);
                Console.Write(list.seperation.PadRight(10)); // 이수구분
                Console.SetCursorPosition(Constants.GRADE_X, Constants.Y);
                Console.Write(list.grade.PadRight(5)); // 학년
                Console.Write(list.score.PadRight(10)); //학점
                Console.Write(list.day.PadRight(10)); // 요일
                Console.SetCursorPosition(Constants.ROOM_X, Constants.Y);
                Console.Write(list.room.PadRight(10));//강의실
                Console.Write(list.professor.PadRight(10)); //교수명
                Console.SetCursorPosition(Constants.LANGUAGE_X, Constants.Y++);
                Console.Write(list.language.PadRight(10)); // 언어
                Console.WriteLine();
            }


            while (true)
            {
                Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y); //위치 설정
                removeNumber = Console.ReadLine();

                if (false == RemoveData.IsMatch(removeNumber))
                {
                    Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y);
                    Console.Write("다시 입력해주세요"); continue;
                }
                break;
            }

            number = int.Parse(removeNumber);

            foreach (ClassVO list in UserData.Data)
            {

                if (number == int.Parse(list.number))
                {
                    check = true; // 번호가 존재
                    UserData.Data.RemoveAt(removeCount); // 번호 삭제
                    Console.SetCursorPosition(Constants.REMOVE_APPLY_X, Constants.THREE);
                    Console.Write("강의를 지웠습니다. F5를 누르면 돌아갑니다.");
                    removeCount = Constants.ZERO;
                    break;
                }
                removeCount++;
            }

           

            if(check == false) // 존재안하면 다시 
            {
                Console.Write("입력한 번호가 없습니다. Enter : 재입력, F5 : 뒤로가기");
                while (true)
                {
                    Constants.cursur = Console.ReadKey(true);
                    if (Constants.cursur.Key == ConsoleKey.Enter) { Remove(); break; }// 뒤로가기
                    else if (Constants.cursur.Key == ConsoleKey.F5) { GoBack(); break; }// 뒤로가기
                    else continue;
                }
            }

            GoBack();
            Constants.Is_CHECK = true;//초기화

        }
        public void GoBack()
        {
            while (true)
            {
                Console.SetCursorPosition(Constants.REMOVE_X, Constants.REMOVE_Y);
                Constants.cursur = Console.ReadKey(true);
                if (Constants.cursur.Key == ConsoleKey.F5) { Menu(); break; }// 뒤로가기
                else continue;
            }
        }
        public void SearchClass()
        {
            string addNumber;
            int sum = Constants.ZERO;
            bool check = false;

            foreach (ClassVO list in UserData.Data)
            {
                sum += int.Parse(list.score);
            }

            Console.Clear();
            Console.SetCursorPosition(Constants.ZERO, Constants.ZERO);
            Console.WriteLine("등록 가능 학점 : {0}      담은 학점 : {1}          담을 과목 NO :\n\n", Constants.POSSBLE_SCORE - sum, sum);
            MenuView.PrintClass();


            Constants.Y = 7;
            foreach (ClassVO list in MySubject)
            {

                Console.Write(list.number.PadRight(8)); //NO        
                Console.Write(list.mager.PadRight(10));//전공
                Console.SetCursorPosition(Constants.NUMBER_X, Constants.Y);
                Console.Write(list.classNumber.PadRight(13)); // 학수번호
                Console.Write(list.group.PadRight(7)); // 분반
                Console.Write(list.classname.PadRight(10)); //교과목명
                Console.SetCursorPosition(Constants.CLASS_X, Constants.Y);
                Console.Write(list.seperation.PadRight(10)); // 이수구분
                Console.SetCursorPosition(Constants.GRADE_X, Constants.Y);
                Console.Write(list.grade.PadRight(5)); // 학년
                Console.Write(list.score.PadRight(10)); //학점
                Console.Write(list.day.PadRight(10)); // 요일
                Console.SetCursorPosition(Constants.ROOM_X, Constants.Y);
                Console.Write(list.room.PadRight(10));//강의실
                Console.Write(list.professor.PadRight(10)); //교수명
                Console.SetCursorPosition(Constants.LANGUAGE_X, Constants.Y++);
                Console.Write(list.language.PadRight(10)); // 언어
                Console.WriteLine();
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

            foreach (ClassVO list in MySubject)
            {
                if (int.Parse(list.number) == int.Parse(addNumber))
                {
                    sum += int.Parse(list.score);
                    if (Constants.POSSBLE_SCORE < sum)
                    {
                        Console.Write("가능한 점수를 초과하였습니다. 돌아가려면 F5를 눌러주세요");
                        GoBack();
                        break;
                    }

                    check = true; // 번호가 존재
                    UserData.Data.Add(list); // 관심과목에 추가
                    Console.Write("관심과목에 추가하였습니다! 돌아가려면 F5를 눌러주세요");
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
