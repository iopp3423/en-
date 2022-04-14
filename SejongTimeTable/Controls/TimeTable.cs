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
        Printing MenuView = new Printing();
        Regex MenuCheck = new Regex(Constants.MENU);
        Regex GradeCheck = new Regex(Constants.GRADE_CHECK);
        public ClassVO MyClass;
        
        public TimeTable()
        {

        }
        public TimeTable(ClassVO MyClass)
        {
            this.MyClass = MyClass;
        }

        string menu;
        int majorJudgment; // 전공
        int diviseJudgment; // 이수구분
        int nameJudgment; // 교과목명
        int professorJudgment; // 교수명 
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
            MyClass.ClassList(); // 리스트에 엑셀값 저장
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

                if (Constants.Is_CHECK != MenuCheck.IsMatch(menu))
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

        public int SearchClassName() // 교과목명
        {
            Constants.Is_CHECK = true;
            MenuView.ChooseClassName();
            Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.NAME_CURSUR_Y);

            while (true)
            {
                menu = Console.ReadLine();

                if (Constants.Is_CHECK != MenuCheck.IsMatch(menu))
                {
                    Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.NAME_CURSUR_Y);
                    continue;
                }
                break;
            }
            return int.Parse(menu);
        }

        public int SearchProfessorName() // 교수명
        {
            Constants.Is_CHECK = true;
            MenuView.ChooseSearchProfessorName();
            Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.PROFESSOR_CURSUR_Y);

            while (true)
            {
                menu = Console.ReadLine();

                if (Constants.Is_CHECK != MenuCheck.IsMatch(menu))
                {
                    Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.PROFESSOR_CURSUR_Y);
                    continue;
                }
                break;
            }
            return int.Parse(menu);
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

        public void SearchClass(int major, int divise, int className, int professor, int grade) // 숫자를 문자로 바꿔줌
        {
            string choiceMajor = null;
            string choiceDivise = null;
            string choiceClassName = null;
            string choiceProfessor = null;
            string choiceGrade = null;

            Console.WriteLine(major);
            
            switch(major)
            {
                case 1: choiceMajor = "전체";break;
                case 2: choiceMajor = "컴퓨터공학과"; break;
                case 3: choiceMajor = "지능기전공학부"; break;
                case 4: choiceMajor = "기계항공우주공학부"; break;
                default: break;
            }
            switch (divise)
            {
                case 1: choiceDivise = "전체"; break;
                case 2: choiceDivise = "교양필수"; break;
                case 3: choiceDivise = "전공필수"; break;
                case 4: choiceDivise = "전공선택"; break;
                default: break;
            }
            switch (className)
            {
                case 1: choiceClassName = "전체"; break;
                case 2: choiceClassName = "신입생세미나"; break;
                case 3: choiceClassName = "C프로그래밍"; break;
                case 4: choiceClassName = "디지털시스템"; break;
                default: break;
            }
            switch (professor)
            {
                case 1: choiceProfessor = "전체"; break;
                case 2: choiceProfessor = "박태순"; break;
                case 3: choiceProfessor = "문현준"; break;
                case 4: choiceProfessor = "공성곤"; break;
                default: break;
            }
            switch (grade)
            {
                case 1: choiceGrade = "전체"; break;
                case 2: choiceGrade = "1학년"; break;
                case 3: choiceGrade = "2학년"; break;
                case 4: choiceGrade = "3학년"; break;
                case 5: choiceGrade = "4학년"; break;
                default: break;
            }
            
            Console.WriteLine(choiceMajor);
            Console.WriteLine(choiceDivise);
            Console.WriteLine(choiceClassName);
            Console.WriteLine(choiceProfessor);
            Console.WriteLine(choiceGrade);
        }
     
    }
        
    
}
