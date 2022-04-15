using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;
using SejongTimeTable.Models;
using System.Text.RegularExpressions;
using System.Linq;

namespace SejongTimeTable.Controls
{
    internal class TimeTable //: Logging
    {
        Printing MenuView = new Printing();
        Regex MenuCheck = new Regex(Constants.MENU);
        Regex GradeCheck = new Regex(Constants.GRADE_CHECK);
        Regex SubjectCheck = new Regex(Constants.SUBJECT_NAME);
        Regex ProfessorCheck = new Regex(Constants.PROFESSOR_NAME);

        List<ClassVO> Search = new List<ClassVO>(); // 검색 값 저장하는 리스트
        //List<ClassVO> DistinctSearch = new List<ClassVO>();

        public ClassVO MyTable; // 엑셀값
        
        public TimeTable()
        {

        }
        public TimeTable(ClassVO MyTable)
        {
            this.MyTable = MyTable;
        }

        string menu;
        int majorJudgment; // 전공
        int diviseJudgment; // 이수구분
        string nameJudgment; // 교과목명
        string professorJudgment; // 교수명 
        int gradeJudgment; // 학년

        public void clearCurrentLine()
        {
            string s = "\r";
            s += new string(' ', Console.CursorLeft);
            s += "\r";
            Console.Write(s);
        }

        //clearCurrentLine();

        public void Menu()
        {
            Console.Clear();
            Constants.Is_CHECK = true; // 초기값으로 변경
            

            MenuView.PrintNumber();
            MenuView.AfterMenu();
            MenuView.Back();

            /*
            foreach (ClassVO list in MyClass.Data)
            {

                Console.WriteLine(list);

            }
            */
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
                            //LoginAfter();//////////////////////////뒤로가기 클래스 수정해야함
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.TIME_TABLE_Y == Constants.TABLE_Y) { Constants.Is_CHECK = false; majorJudgment = Major(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.FAVORITE_Y) { Constants.Is_CHECK = false; diviseJudgment = Divise(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.APPLICATION_Y) { Constants.Is_CHECK = false; nameJudgment = SearchClassName(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.MYCLASS_Y) { Constants.Is_CHECK = false; professorJudgment = SearchProfessorName(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.GRADE_Y) { Constants.Is_CHECK = false; gradeJudgment = SearchGrade(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.REFER_Y) { Constants.Is_CHECK = false; SearchClass(majorJudgment, diviseJudgment, nameJudgment, professorJudgment, gradeJudgment); break; }
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

        public int Major() // 학과 전공
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
            Console.WriteLine(major);
            Console.WriteLine(divise);
            Console.WriteLine(className);
            Console.WriteLine(professor);
            Console.WriteLine(grade);

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


            //if (choiceMajor == null) 
            //if (choiceDivise== null) 
            //if (className == null) 
            //if (professor == null) 
            //if (choiceGrade == null) 

            foreach (ClassVO list in MyTable.Data)
            {
                if (list.mager.Contains(choiceMajor) == true) { Search.Add(list); }
                if (list.seperation.Contains(choiceDivise) == true) Console.Write("H");// { Search.Add(list);  }
                if (list.classname.Contains(className) == true) Console.Write(className);//{ Search.Add(list);  }
                if (list.professor.Contains(professor) == true) Console.Write(professor);//{Search.Add(list);  }
                if (list.grade.Contains(choiceGrade) == true) Console.Write(choiceGrade);//{ Search.Add(list); }
            }

            //DistinctSearch = (List<ClassVO>)Search.Distinct();

            
            foreach (ClassVO list in Search)
            {
                Console.WriteLine(list);
            }
            
            
            
            /*
            foreach (ClassVO list in DistinctSearch)
            {
                Console.Write(list);
            }
            */
            
        }
        

    }
        
    
}
