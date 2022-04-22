using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Exception;

namespace LibruryDatabase.Controls
{
    internal class AdminMenu
    {
        Screen Menu = new Screen();
        public void ChooseMenu()
        {
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintAdminMenu();
            Console.ReadLine();

            if (Constants.BACK == moveMenu()) // 컨트롤러
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintReturnMenu();
                return;
            }
        }

        public bool moveMenu()
        {
            int Y = Constants.FIRSTY;

            while (Constants.ENTRANCE) // 참이면
            {
                Console.SetCursorPosition(Constants.FIRSTX, Y);
                Constants.cursor = Console.ReadKey(true);

                switch (Constants.cursor.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            Y--;
                            if (Y < Constants.SEARCH_BOOK) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.RIVISE_USER) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            return Constants.BACK_MENU;
                        }

                    case ConsoleKey.Escape: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }

                    default: break;

                }
            }
        }
    }
}
