﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;
using SejongTimeTable.Models;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;




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
        int dayPos;

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
                            if (Constants.APPLY_Y == Constants.APPLY_TABLE_Y) { Check(); }
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
        public void ApplySubject()
        {
            Console.Clear();
            
            MenuView.PrintMySubject();

            foreach (ClassVO list in Application.Data)
            {
                Console.WriteLine(list);
                
            }
            //SaveExcel();
            
            GoBack();
            
            

        }
        public void SaveExcel()
        {

            
                try
                {
                    // Excel Application 객체 생성
                    Excel.Application excelApp = new Excel.Application();

                    // Workbook 객체 생성 및 워크북 추가
                    Excel.Workbook workbook = excelApp.Workbooks.Add();



                    // sheets에 읽어온 엑셀값을 넣기 (한 workbook 내의 모든 sheet 가져옴)
                    Excel.Sheets sheets = workbook.Sheets;

                    // 특정 sheet의 값 가져오기
                    // Excel.Worksheet worksheet = sheets["ensharp"] as Excel.Worksheet;
                    Excel.Worksheet worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;
                    worksheet.Cells[2, 1] = "09:00~09:30";
                    worksheet.Cells[4, 1] = "09:30~10:00";
                    worksheet.Cells[6, 1] = "10:00~10:30";
                    worksheet.Cells[8, 1] = "10:30~11:00";
                    worksheet.Cells[10, 1] = "11:30~12:00";
                    worksheet.Cells[12, 1] = "12:00~12:30";
                    worksheet.Cells[14, 1] = "12~30~13:00";
                    worksheet.Cells[16, 1] = "13:00~13:30";
                    worksheet.Cells[18, 1] = "13:30~14:00";
                    worksheet.Cells[20, 1] = "14:00~14:30";
                    worksheet.Cells[22, 1] = "14:30~15:00";
                    worksheet.Cells[24, 1] = "15:00~15:30";
                    worksheet.Cells[26, 1] = "15:30~16:00";
                    worksheet.Cells[28, 1] = "16:00~16:30";
                    worksheet.Cells[30, 1] = "16:30~17:00";
                    worksheet.Cells[32, 1] = "17:00~17:30";
                    worksheet.Cells[34, 1] = "17:30~18:00";
                    worksheet.Cells[36, 1] = "18:00~18:30";
                    worksheet.Cells[38, 1] = "18:30~19:00";
                    worksheet.Cells[40, 1] = "19:00~19:30";
                    worksheet.Cells[42, 1] = "19:30~20:00";
                    worksheet.Cells[1, 2] = "월요일";
                    worksheet.Cells[1, 4] = "화요일";
                    worksheet.Cells[1, 6] = "수요일";
                    worksheet.Cells[1, 8] = "목요일";
                    worksheet.Cells[1, 10] = "금요일";


                // 모든 워크북 닫기
                excelApp.Workbooks.Close();

                    // application 종료
                    excelApp.Quit();
                }
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                }

            
        }      

        public void RemoveSubject()
        {
            int sum = Constants.ZERO;
            int remove;
            int removeCount = Constants.ZERO;
            bool check = false;
            Console.Clear();

            MenuView.PrintMySubject();

            Constants.Y = Constants.FOUR;
            foreach (ClassVO list in Application.Data)
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
                sum += int.Parse(list.score);
                Console.WriteLine();
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
            Console.WriteLine("신청 가능 학점 : {0}      신청 학점 : {1}          신청할 과목 NO :\n", Constants.APPLY_SCORE - sum, sum);
            MenuView.PrintClass();

            foreach (ClassVO list in Application.Data) // 신청 학점
            {
                sum += int.Parse(list.score);
            }

            Constants.Y = Constants.FOUR;
            foreach (ClassVO list in Information)
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
