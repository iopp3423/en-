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
    internal class TimeTable //: Logging
    {
        //Printing MenuView = new Printing();
        Regex MenuCheck = new Regex(Constants.MENU);
        Regex GradeCheck = new Regex(Constants.GRADE_CHECK);
        Regex SubjectCheck = new Regex(Constants.SUBJECT_NAME);
        Regex ProfessorCheck = new Regex(Constants.PROFESSOR_NAME);
        //Logging LoginAfter = new Logging();
        List<ClassVO> Search = new List<ClassVO>(); // 검색 값 저장하는 리스트
       //List<ClassVO> DistinctSearch = new List<ClassVO>();

        public ClassVO MyTable; // 엑셀값
        public Printing MenuView;

        
        public TimeTable()
        {

        }
        public TimeTable(ClassVO MyTable, Printing MenuView)
        {
            this.MyTable = MyTable;
            this.MenuView = MenuView;
        }

        string menu;
        int majorJudgment=Constants.ONE; // 전공 전체로 초기화
        int diviseJudgment= Constants.ONE; // 이수구분 전체로 초기화
        string nameJudgment = "전체"; // 교과목명 
        string professorJudgment = "전체"; // 교수명 
        int gradeJudgment=Constants.ONE; // 학년 전체로 초기화

        /*
        public void clearCurrentLine()
        {
            string s = "\r";
            s += new string(' ', Console.CursorLeft);
            s += "\r";
            Console.Write(s);
        }
        */      
        public void Menu()
        {
            Console.Clear();
            Constants.Is_CHECK = true; // 초기값으로 변경
            

            MenuView.PrintNumber();
            MenuView.AfterMenu();





            while (Constants.Is_CHECK)
            {
                Console.SetCursorPosition(Constants.TIME_TABLE_X, Constants.TIME_TABLE_Y);

                Constants.cursur = Console.ReadKey(true);
                switch (Constants.cursur.Key)
                {                  
                    case ConsoleKey.UpArrow:
                        {
                            Constants.TIME_TABLE_Y--;
                            if (Constants.TIME_TABLE_Y < Constants.TABLE_Y_UPSTRICT) Constants.TIME_TABLE_Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.TIME_TABLE_Y++;
                            if (Constants.TIME_TABLE_Y > Constants.TABLE_Y_DOWNSTRICT) Constants.TIME_TABLE_Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            //Login.LoginAfter();//////////////////////////뒤로가기 클래스 수정해야함
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.TIME_TABLE_Y == Constants.TABLE_Y) {  majorJudgment = SearchMajor(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.FAVORITE_Y) {  diviseJudgment = Divise(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.APPLICATION_Y) {  nameJudgment = SearchClassName(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.MYCLASS_Y) {  professorJudgment = SearchProfessorName(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.GRADE_Y) {  gradeJudgment = SearchGrade(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.REFER_Y) { SearchClass(majorJudgment, diviseJudgment, nameJudgment, professorJudgment, gradeJudgment); break; }
                                return;
                        }
                    case ConsoleKey.Escape: // 종료
                        {
                            return;
                        }

                    default: break;
                }

            }
            

        }

        public int SearchMajor() // 학과 전공
        {
            Constants.Is_CHECK = true;
            MenuView.ChooseMajor();
            Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.MAJOR_CURSUR_Y);

            while (true)
            {
             
                menu = Console.ReadLine();

                if (Constants.Is_CHECK != GradeCheck.IsMatch(menu))
                {
                    Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.MAJOR_CURSUR_Y);
                    continue;
                }
                break;
                
            }
            return int.Parse(menu);
        }

        public int Divise() // 이수구분
        {
            Constants.Is_CHECK = true;
            MenuView.ChooseDivise();
            Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.DIVISE_CURSUR_Y);

            while (true)
            {
          
                menu = Console.ReadLine();

                if (Constants.Is_CHECK != MenuCheck.IsMatch(menu))
                {
                    Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.DIVISE_CURSUR_Y);
                    continue;
                }
                break;
            }
            return int.Parse(menu);
        }

        public string SearchClassName() // 교과목명
        {
            Constants.Is_CHECK = true;
            MenuView.ChooseClassName();
            Console.SetCursorPosition(Constants.SUBJECT_X, Constants.NAME_CURSUR_Y);

            while (true)
            {
                menu = Console.ReadLine();

                if (Constants.Is_CHECK != SubjectCheck.IsMatch(menu))
                {
                    Console.SetCursorPosition(Constants.SUBJECT_X, Constants.NAME_CURSUR_Y);
                    continue;
                }
                break;
            }
            return menu;
        }

        public string SearchProfessorName() // 교수명
        {
            Constants.Is_CHECK = true;
            MenuView.ChooseSearchProfessorName();
            Console.SetCursorPosition(Constants.PROFFSOR_X, Constants.PROFESSOR_CURSUR_Y);

            while (true)
            {
                menu = Console.ReadLine();

                if (Constants.Is_CHECK != ProfessorCheck.IsMatch(menu))
                {
                    Console.SetCursorPosition(Constants.PROFFSOR_X, Constants.PROFESSOR_CURSUR_Y);
                    continue;
                }
                break;
            }
            return menu;
        }

        public int SearchGrade() // 학년
        {
            Constants.Is_CHECK = true;
            MenuView.ChooseCheckClass();
            Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.GRADE_CURSUR_Y);

            while (true)
            {
             
                menu = Console.ReadLine();

                if (Constants.Is_CHECK != GradeCheck.IsMatch(menu))
                {
                    Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.GRADE_CURSUR_Y);
                    continue;
                }
                break;
            }
            return int.Parse(menu);
        }
        
        public void SearchClass(int major, int divise, string className, string professor, int grade) // 숫자를 문자로 바꿔줌
        {
            string choiceMajor;
            string choiceDivise;
            string choiceGrade;
            Search.Clear();


            switch (major)
            {
                case 1: choiceMajor = "전체";break;
                case 2: choiceMajor = "컴퓨터공학과"; break;
                case 3: choiceMajor = "소프트웨어학과"; break;
                case 4: choiceMajor = "지능기전공학부"; break;
                case 5: choiceMajor = "기계항공우주공학부"; break;
                default: choiceMajor = null; break;
            }
            switch (divise)
            {
                case 1: choiceDivise = "전체"; break;
                case 2: choiceDivise = "교양필수"; break;
                case 3: choiceDivise = "전공필수"; break;
                case 4: choiceDivise = "전공선택"; break;
                default: choiceDivise = null; break;
            }

            switch (grade)
            {
                case 1: choiceGrade = "전체"; break;
                case 2: choiceGrade = "1"; break;
                case 3: choiceGrade = "2"; break;
                case 4: choiceGrade = "3"; break;
                case 5: choiceGrade = "4"; break;
                default: choiceGrade = null; break;
            }


            foreach (ClassVO list in MyTable.Data)
            {
                if (list.mager.Contains(choiceMajor) == true) { Search.Add(list); }
            }
            foreach (ClassVO list in MyTable.Data)
            {         
                if (list.seperation.Contains(choiceDivise) == true) { Search.Add(list); }
            }
            foreach (ClassVO list in MyTable.Data)
            {
                if (list.classname.Contains(className) == true) { Search.Add(list); }
            }
            foreach (ClassVO list in MyTable.Data)
            {
                if (list.professor.Contains(professor) == true) { Search.Add(list); }
            }
            foreach (ClassVO list in MyTable.Data)
            {
                if(list.grade.Contains(choiceGrade) == true ) { Search.Add(list); }
            }

            Console.Clear();
            Console.SetCursorPosition(Constants.ZERO, Constants.ZERO);
            MenuView.PrintTable();
            
            foreach (ClassVO list in Search)
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


            /*
            foreach (ClassVO list in Search)
            {

                
                String strToPrint = list.classname.ToString();

                int padLen = 10 - Encoding.Default.GetBytes(strToPrint).Length;

                Console.WriteLine("{0}", "".PadLeft(padLen) + strToPrint);
                
            }
            */

            /*
            foreach (ClassVO list in Search)
            {


                String strToPrint = list.classname;

                int padLen = 5-Encoding.Default.GetBytes(strToPrint).Length;

                Console.WriteLine("{0}", "".PadLeft(padLen) + strToPrint);

            }
            */

            Console.Write("재검색 : Enter, 프로그램 종료 : ESC");


            

            while (true)
            {
                Constants.cursur = Console.ReadKey(true);
                if (Constants.cursur.Key == ConsoleKey.Enter) Menu();
                else if (Constants.cursur.Key == ConsoleKey.Escape) return;
                else continue;
            }


        }
        

    }
        
    
}
