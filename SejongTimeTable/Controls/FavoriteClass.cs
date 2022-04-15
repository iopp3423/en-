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
                            Constants.FAVORITE_MENU_Y -= 2;
                            if (Constants.FAVORITE_MENU_Y < Constants.FAVORITE_UP_Y) Constants.FAVORITE_MENU_Y += 2; // 선택 외의 화면으로 커서 못나감
                            break;
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.FAVORITE_MENU_Y += 2;
                            if (Constants.FAVORITE_MENU_Y > Constants.FAVORITE_DOWN_Y) Constants.FAVORITE_MENU_Y -= 2; // 선택 외의 화면으로 커서 못나감
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
            //Constants.Is_CHECK = true;//초기화
            string menu;
            int majorJudgment = Constants.ONE; // 전공 전체로 초기화
            int diviseJudgment = Constants.ONE; // 이수구분 전체로 초기화
            string nameJudgment = "전체"; // 교과목명 
            string professorJudgment = "전체"; // 교수명 
            int gradeJudgment = Constants.ONE; // 학년 전체로 초기화
            Constants.Is_CHECK = true;

            Console.Clear();
            MenuView.PrintFavoriteMenu();

            Console.SetCursorPosition(Constants.CHOOSE_X, Constants.CHOOSE_Y);
            while (Constants.Is_CHECK)
            {
                
                Constants.cursur = Console.ReadKey(true);
                switch (Constants.cursur.Key)
                {

                    case ConsoleKey.UpArrow:
                        {
                            Constants.CHOOSE_Y -= 2;
                            if (Constants.CHOOSE_Y < Constants.CHOOSE_UP_Y) Constants.CHOOSE_Y += 2; // 선택 외의 화면으로 커서 못나감
                            break; 
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.CHOOSE_Y += 2;
                            if (Constants.CHOOSE_Y > Constants.CHOOSE_DOWN_Y) Constants.CHOOSE_Y -= 2; // 선택 외의 화면으로 커서 못나감
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
                            if (Constants.CHOOSE_Y == Constants.NUMBER_Y) { Constants.Is_CHECK = false; diviseJudgment = Divise(); break; }
                            if (Constants.CHOOSE_Y == Constants.SUBJECT_Y) { Constants.Is_CHECK = false; nameJudgment = SearchClassName(); break; }
                            if (Constants.CHOOSE_Y == Constants.PROFESSOR_Y) { Constants.Is_CHECK = false; professorJudgment = SearchProfessorName(); break; }
                            if (Constants.CHOOSE_Y == Constants.GRADE_MENU_Y) { Constants.Is_CHECK = false; gradeJudgment = SearchGrade(); break; }
                            //if (Constants.CHOOSE_Y == Constants.REFER_Y) { Constants.Is_CHECK = false; SearchClass(majorJudgment, diviseJudgment, nameJudgment, professorJudgment, gradeJudgment); break; }
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


        public void SearchMyMajor(int major) // 전공검색 후 프린트
        {
            string choiceMajor;
            string addNumber;
            int sum = Constants.ZERO;
            int number;
            bool check = false;
            foreach (ClassVO list in UserData.Data)
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
    
            foreach (ClassVO list in Favorite.Data)
            {
                if (list.mager.Contains(choiceMajor) == true) { MySubject.Add(list); }
            }
            Console.Clear();
            Console.Write("\n\n\n\n");
            Console.WriteLine("등록 가능 학점 : {0}      담은 학점 : {1}          담을 과목 NO :\n\n\n", Constants.POSSBLE_SCORE-sum, sum);
            MenuView.PrintClass();

            foreach (ClassVO list in MySubject)
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
            number -= Constants.ONE;


            foreach (ClassVO list in Favorite.Data)
            {
                if (int.Parse(list.number) == int.Parse(addNumber))
                {
                    check = true; // 번호가 존재
                    UserData.Data.Add(list); // 관심과목에 추가
                    Console.Write("관심과목에 추가하였습니다!");
                    break;
                }
            }

            if (check == false) // 존재안하면 다시 
            {
                Console.Write("입력한 번호가 없습니다.");  
            }



            Constants.Is_CHECK = true; // 초기화
            GoBack();
        }



        public void SearchMyClass() 
        {
            Console.Clear();
            MenuView.PrintMyClass();
            Constants.Is_CHECK = true;//초기화
            foreach (ClassVO list in UserData.Data)
            {
                Console.WriteLine(list);
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

            //Console.WriteLine(UserData.Data[0].room);
           
            Console.SetCursorPosition(13, 5);
            //Console.WriteLine(UserData.Data[0].classname);
            //Console.WriteLine(UserData.Data[0]);
            //Console.WriteLine(UserData.Data[1]);
            // 18:00~19:00

            /*
            for (col = 0; col < 20; col++)
                {
                    Console.SetCursorPosition(13, 5+col+col);
                    if (UserData.Data[0].day.Contains("월") && UserData.Data[0].day.Contains(col.ToString())) Console.Write(UserData.Data[0].room);
                    else Console.Write("                            ");
                    if (UserData.Data[0].day.Contains("화")) Console.Write(UserData.Data[0].room);
                    else Console.Write("                            ");
                    if (UserData.Data[0].day.Contains("수")) Console.Write(UserData.Data[0].room);
                    else Console.Write("                            ");
                    if (UserData.Data[0].day.Contains("목")) Console.Write(UserData.Data[0].room);
                    else Console.Write("                            ");
                    if (UserData.Data[0].day.Contains("금") && UserData.Data[0].day.Contains(col) Console.Write(UserData.Data[0].room);
                    else Console.WriteLine();
                    Console.SetCursorPosition(13, 6);

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
            foreach(ClassVO list in UserData.Data)
            {
                sum += int.Parse(list.score);
            }
            bool check = false;
            Console.Clear();
            Console.WriteLine("\n");
            Console.Write(string.Format("                                                                                                      신청 학점 : {0}  삭제할 과목 NO : ", sum));// 이거 고쳐야함
            
            MenuView.PrintMyClass();

            
            foreach (ClassVO list in UserData.Data)
            {
                Console.WriteLine(list);
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
            number -= Constants.ONE;


            foreach (ClassVO list in UserData.Data)
            {
                if (int.Parse(list.number) == int.Parse(removeNumber))
                {
                    check = true; // 번호가 존재
                    UserData.Data.RemoveAt(number); // 번호 삭제
                    Console.Write("강의를 지웠습니다. F5를 누르면 돌아갑니다.");
                    break;
                }
            }

            if(check == false) // 존재안하면 다시 
            {
                Console.Write("입력한 번호가 없습니다.");
                Remove();
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

    }
   
}
