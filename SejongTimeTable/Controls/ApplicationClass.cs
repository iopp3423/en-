using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;
using SejongTimeTable.Models;

namespace SejongTimeTable.Controls
{
    internal class ApplicationClass : TimeTable
    {
        Printing MenuView = new Printing();
        string menu;
        int majorJudgment = Constants.ONE; // 전공 전체로 초기화
        int diviseJudgment = Constants.ONE; // 이수구분 전체로 초기화
        string nameJudgment = "전체"; // 교과목명 
        string professorJudgment = "전체"; // 교수명 
        int gradeJudgment = Constants.ONE; // 학년 전체로 초기화

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
                            if (Constants.APPLY_Y == Constants.APPLY_SEARCH_Y) { Constants.Is_CHECK = false; Search(); break; }
                            //if (Constants.APPLY_Y == Constants.APPLY_LOG_Y) ;
                            //if (Constants.APPLY_Y == Constants.APPLY_TABLE_Y) ;
                            //if (Constants.APPLY_Y == Constants.APPLY_REMOVE_Y) ;
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
        public void Search()
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
                            Console.Write("Hello");
                            Constants.APPLY_MAGOR_Y--;
                            if (Constants.APPLY_MAGOR_Y < Constants.APPLY_MAGOR_UP) Constants.APPLY_MAGOR_Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }

                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Console.Write("Hello2222");
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
    }
}
