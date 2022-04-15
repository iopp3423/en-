using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SejongTimeTable.Views;

namespace SejongTimeTable.Controls
{
    internal class FavoriteClass 
    {
        Printing MenuView = new Printing();
        public void Menu()
        {
            Constants.Is_CHECK = true; // 초기화
            Console.Clear();
            MenuView.PrintFavoriteClass();

            while (Constants.Is_CHECK)
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
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_SEARCH_Y) Console.Write("Hello"); break;
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_MY_Y) Console.Write("Hello"); break;
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_TIME_Y) Console.Write("Hello"); break;
                            if (Constants.FAVORITE_MENU_Y == Constants.FAVORITE_REMOVE_Y) Console.Write("Hello"); break;
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
