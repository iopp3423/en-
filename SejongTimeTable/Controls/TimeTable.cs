using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;

namespace SejongTimeTable.Controls
{
    internal class TimeTable// : Logging
    {
        Printing MenuView = new Printing();
        public void Menu()
        {
            Console.Clear();
            Constants.Is_CHECK = true; // 초기값으로 변경
            MenuView.PrintESC();
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
                           // LoginAfter();
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.TIME_TABLE_Y == Constants.TABLE_Y) { Constants.Is_CHECK = false; Major(); break; }
                            if (Constants.TIME_TABLE_Y == Constants.FAVORITE_Y) { Divise(); Constants.Is_CHECK = false; break; }
                            if (Constants.TIME_TABLE_Y == Constants.APPLICATION_Y) { SearchClassName(); Constants.Is_CHECK = false; break; }
                            if (Constants.TIME_TABLE_Y == Constants.MYCLASS_Y) { SearchProfessorName(); Constants.Is_CHECK = false; break; }
                            if (Constants.TIME_TABLE_Y == Constants.MYCLASS_Y) { SearchGrade(); Constants.Is_CHECK = false; break; }
                            if (Constants.TIME_TABLE_Y == Constants.MYCLASS_Y) { CheckClass(); Constants.Is_CHECK = false; break; }
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
            Console.Write("Hello");
        }
        public void Divise()
        {

        }

        public void SearchClassName()
        {

        }

        public void SearchProfessorName()
        {

        }

        public void SearchGrade()
        {

        }

        public void CheckClass()
        {

        }
    }
}
