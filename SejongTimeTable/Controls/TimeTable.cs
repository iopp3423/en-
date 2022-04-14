using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;
using SejongTimeTable.Models;

namespace SejongTimeTable.Controls
{
    internal class TimeTable //: Logging
    {
        Printing MenuView = new Printing();

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
                            
                            if (Constants.TIME_TABLE_Y == Constants.TABLE_Y) { Constants.Is_CHECK = false; Major(); break; }
                            /*
                            if (Constants.TIME_TABLE_Y == Constants.FAVORITE_Y) { Divise(); Constants.Is_CHECK = false; break; }
                            if (Constants.TIME_TABLE_Y == Constants.APPLICATION_Y) { SearchClassName(); Constants.Is_CHECK = false; break; }
                            if (Constants.TIME_TABLE_Y == Constants.MYCLASS_Y) { SearchProfessorName(); Constants.Is_CHECK = false; break; }
                            if (Constants.TIME_TABLE_Y == Constants.MYCLASS_Y) { SearchGrade(); Constants.Is_CHECK = false; break; }
                            if (Constants.TIME_TABLE_Y == Constants.MYCLASS_Y) { CheckClass(); Constants.Is_CHECK = false; break; }
                            */
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

        public void Major()
        {
            MenuView.ChooseMajor();
            while (true)
            {
                Console.SetCursorPosition(Constants.MAJOR_CURSUR_X, Constants.MAJOR_CURSUR_Y);

                Constants.cursur = Console.ReadKey(true);

                switch (Constants.cursur.Key)
                {

                    case ConsoleKey.RightArrow:
                        {
                            Constants.MAJOR_CURSUR_X+=15;
                            //if (Constants.TIME_TABLE_Y < Constants.TABLE_Y_UPSTRICT) Constants.TIME_TABLE_Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }

                    // 하
                    case ConsoleKey.LeftArrow:
                        {
                            Constants.MAJOR_CURSUR_X--;
                           // if (Constants.TIME_TABLE_Y > Constants.TABLE_Y_DOWNSTRICT) Constants.TIME_TABLE_Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }


                        
                }
            }
        }
        /*
        public string Divise()
        {

        }

        public string SearchClassName()
        {

        }

        public string SearchProfessorName()
        {

        }

        public string SearchGrade()
        {

        }

        public string CheckClass()
        {

        }
        */
    }
}
