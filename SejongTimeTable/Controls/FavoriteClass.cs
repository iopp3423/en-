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
        int dayPos;
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
            Console.Clear();
            MenuView.PrintMyTable();
            MenuView.PrintTimeTable();

            foreach (ClassVO list in UserData.Data)
            {
                if (list.day.Contains("월")) { dayPos = Constants.MONDAY; Check(list); }
                else if (list.day.Contains("화")) { dayPos = Constants.TUESDAY; Check(list); }
                else if (list.day.Contains("수")) { dayPos = Constants.WEDNESDAY; Check(list); }
                else if (list.day.Contains("목")) { dayPos = Constants.THURSDAY; Check(list); }
                else if (list.day.Contains("금")) { dayPos = Constants.FRIDAY; Check(list); }
                else { break; } 
            }
        

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



        public void Check(ClassVO list)
        {             
            if (list.day.Contains("09:00") && list.day.Contains("12:00"))
            {
                Console.SetCursorPosition(dayPos, 01);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 02);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 03);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 04);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 05);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 06);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("10:00") && list.day.Contains("13:00"))
            {
                Console.SetCursorPosition(dayPos, 05);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 06);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("11:00") && list.day.Contains("14:00"))
            {
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
            }


            if (list.day.Contains("12:00") && list.day.Contains("15:00"))
            {
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("13:00") && list.day.Contains("16:00"))
            {
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
            }

            if (list.day.Contains("15:00") && list.day.Contains("18:00"))
            {
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 29);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 30);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 31);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 32);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 33);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 34);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 35);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 36);
                Console.WriteLine(list.room);
            }

            if (list.day.Contains("09:30") && list.day.Contains("11:30"))
            {
                Console.SetCursorPosition(dayPos, 03);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 04);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 05);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 06);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("10:30") && list.day.Contains("12:30"))
            {
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("11:30") && list.day.Contains("13:30"))
            {
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("12:30") && list.day.Contains("14:30"))
            {
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("13:30") && list.day.Contains("15:30"))
            {
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("14:30") && list.day.Contains("16:30"))
            {
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 29);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 30);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("15:30") && list.day.Contains("17:30"))
            {
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 29);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 30);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 31);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 32);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 33);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 34);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("16:30") && list.day.Contains("18:30"))
            {
                Console.SetCursorPosition(dayPos, 31);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 32);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 33);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 34);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 35);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 36);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 37);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 38);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("17:30") && list.day.Contains("19:30"))
            {
                Console.SetCursorPosition(dayPos, 35);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 36);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 37);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 38);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 39);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 40);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 41);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 42);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("18:30") && list.day.Contains("20:30"))
            {
                Console.SetCursorPosition(dayPos, 39);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 40);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 41);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 42);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 43);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 44);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 45);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 46);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("09:00") && list.day.Contains("11:00"))
            {
                Console.SetCursorPosition(dayPos, 01);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 02);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 03);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 04);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 05);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 06);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("10:00") && list.day.Contains("12:00"))
            {
                Console.SetCursorPosition(dayPos, 05);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 06);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("11:00") && list.day.Contains("13:00"))
            {
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("12:00") && list.day.Contains("14:00"))
            {
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("13:00") && list.day.Contains("15:00"))
            {
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("14:00") && list.day.Contains("16:00"))
            {
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("15:00") && list.day.Contains("17:00"))
            {
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 29);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 30);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 31);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 32);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("16:00") && list.day.Contains("18:00"))
            {
                Console.SetCursorPosition(dayPos, 29);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 30);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 31);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 32);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 33);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 34);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 35);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 36);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("17:00") && list.day.Contains("19:00"))
            {
                Console.SetCursorPosition(dayPos, 33);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 34);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 35);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 36);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 37);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 38);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 39);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 40);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("18:00") && list.day.Contains("20:00"))
            {
                Console.SetCursorPosition(dayPos, 37);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 38);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 39);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 40);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 41);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 42);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 43);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 44);
                Console.WriteLine(list.room);
            }


            if (list.day.Contains("09:00") && list.day.Contains("10:30"))
            {
                Console.SetCursorPosition(dayPos, 01);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 02);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 03);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 04);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 05);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 06);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("10:00") && list.day.Contains("11:30"))
            {
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("11:00") && list.day.Contains("12:30"))
            {
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("12:00") && list.day.Contains("13:30"))
            {
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("13:00") && list.day.Contains("14:30"))
            {
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 29);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 30);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("14:00") && list.day.Contains("15:30"))
            {
                Console.SetCursorPosition(dayPos, 31);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 32);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 33);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 34);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 35);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 36);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("15:00") && list.day.Contains("16:30"))
            {
                Console.SetCursorPosition(dayPos, 37);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 38);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 39);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 40);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 41);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 42);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("16:00") && list.day.Contains("17:30"))
            {
                Console.SetCursorPosition(dayPos, 43);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 44);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 45);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 46);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 47);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 47);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("17:00") && list.day.Contains("18:30"))
            {
                Console.SetCursorPosition(dayPos, 49);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 50);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 51);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 52);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 53);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 54);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("18:00") && list.day.Contains("19:30"))
            {
                Console.SetCursorPosition(dayPos, 55);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 56);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 57);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 58);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 59);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 60);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("19:00") && list.day.Contains("20:30"))
            {
                Console.SetCursorPosition(dayPos, 61);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 62);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 63);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 65);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 65);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 66);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("09:30") && list.day.Contains("12:00"))
            {
                Console.SetCursorPosition(dayPos, 03);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 04);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 05);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 06);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("10:30") && list.day.Contains("12:00"))
            {
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("11:30") && list.day.Contains("13:00"))
            {
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("12:30") && list.day.Contains("14:00"))
            {
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("13:30") && list.day.Contains("15:00"))
            {
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 29);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 30);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 31);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 32);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("14:30") && list.day.Contains("16:00"))
            {
                Console.SetCursorPosition(dayPos, 33);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 34);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 35);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 36);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 37);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 40);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("15:30") && list.day.Contains("17:00"))
            {
                Console.SetCursorPosition(dayPos, 41);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 42);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 43);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 44);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 45);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 46);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("16:30") && list.day.Contains("18:00"))
            {
                Console.SetCursorPosition(dayPos, 47);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 48);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 49);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 50);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 51);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 52);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("17:30") && list.day.Contains("19:00"))
            {
                Console.SetCursorPosition(dayPos, 53);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 54);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 55);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 56);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 57);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 57);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("18:30") && list.day.Contains("20:00"))
            {
                Console.SetCursorPosition(dayPos, 59);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 60);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 61);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 62);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 63);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 64);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("19:30") && list.day.Contains("21:00"))
            {
                Console.SetCursorPosition(dayPos, 65);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 66);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 67);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 68);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 69);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 70);
                Console.WriteLine(list.room);
            }


            if (list.day.Contains("09:00") && list.day.Contains("10:00"))
            {
                Console.SetCursorPosition(dayPos, 01);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 02);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 03);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 04);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("10:00") && list.day.Contains("11:00"))
            {
                Console.SetCursorPosition(dayPos, 05);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 06);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 07);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 08);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("11:00") && list.day.Contains("12:00"))
            {
                Console.SetCursorPosition(dayPos, 09);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 10);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 11);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 12);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("12:00") && list.day.Contains("13:00"))
            {
                Console.SetCursorPosition(dayPos, 13);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 14);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 15);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 16);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("13:00") && list.day.Contains("14:00"))
            {
                Console.SetCursorPosition(dayPos, 17);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 18);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 19);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 20);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("14:00") && list.day.Contains("15:00"))
            {
                Console.SetCursorPosition(dayPos, 21);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 22);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 23);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 24);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("15:00") && list.day.Contains("16:00"))
            {
                Console.SetCursorPosition(dayPos, 25);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 26);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 27);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 28);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("16:00") && list.day.Contains("17:00"))
            {
                Console.SetCursorPosition(dayPos, 29);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 30);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 31);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 32);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("17:00") && list.day.Contains("18:00"))
            {
                Console.SetCursorPosition(dayPos, 33);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 34);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 35);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 36);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("18:00") && list.day.Contains("19:00"))
            {
                Console.SetCursorPosition(dayPos, 37);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 38);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 39);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 40);
                Console.WriteLine(list.room);
            }
            if (list.day.Contains("19:00") && list.day.Contains("20:00"))
            {
                Console.SetCursorPosition(dayPos, 41);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 42);
                Console.WriteLine(list.room);
                Console.SetCursorPosition(dayPos, 43);
                Console.WriteLine(list.classname);
                Console.SetCursorPosition(dayPos, 44);
                Console.WriteLine(list.room);
            }

                

                

                
        }

    }
   
}
