using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SejongTimeTable.Views;

namespace SejongTimeTable.Controls
{
    internal class Logging
    { 
        Printing MenuView = new Printing();
        TimeTable Table = new TimeTable();
        FavoriteClass Favorite = new FavoriteClass();
        ApplicationClass Appliction = new ApplicationClass();
        MyClass Class = new MyClass();

        Regex ID = new Regex(Constants.ID_CHECK);
        Regex PW = new Regex(Constants.PW_CHECK);

        public void LoginId()
        {
            Console.Clear();
            MenuView.PrintLogin();
            while (true)
            {
                string id;
                Console.SetCursorPosition(Constants.ID_X_AXIS, Constants.ID_Y_AXIS);
                id = Console.ReadLine();
                          
                if (Constants.Is_CHECK != ID.IsMatch(id))
                {
                    Console.SetCursorPosition(Constants.ID_X_AXIS, Constants.ID_Y_AXIS);
                    Console.Write("다시 입력해주세요"); continue;
                }
                
                LoginPw(id);
                break;
            }
        }
        
         public void LoginPw(string id)
        {
            string pw;

            while (true)
            { 
                Console.SetCursorPosition(Constants.PW_X_AXIS, Constants.PW_Y_AXIS);
                pw = Console.ReadLine();

                if (Constants.Is_CHECK != PW.IsMatch(pw))
                {
                    Console.SetCursorPosition(Constants.PW_X_AXIS, Constants.PW_Y_AXIS);
                    Console.Write("다시 입력해주세요:"); continue;
                }

                if (id == "17013150" && pw == "99999999") LoginAfter();
                else
                {
                    Console.Write("ID PW가 다릅니다. 재입력 : ENTER, 프로그램 종료 : ESC");
                    Constants.cursur = Console.ReadKey();
                    if (Constants.cursur.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        MenuView.PrintLogin();
                    }
                    else if (Constants.cursur.Key == ConsoleKey.Escape) return;
                    else return;

                    LoginId();
                }
                break;
            }
        }


        public void LoginAfter()
        {
            Console.Clear();
            MenuView.PrintESC();
            MenuView.PrintMenu();
            MenuView.Back();
            Console.SetCursorPosition(Constants.MENU_X, Constants.MENU_Y);          


            while (Constants.Is_CHECK)
            {
                Console.SetCursorPosition(Constants.MENU_X, Constants.MENU_Y);

                Constants.cursur = Console.ReadKey(true);
                switch (Constants.cursur.Key)
                    {                 
                        
                    case ConsoleKey.UpArrow:
                        {
                             Constants.MENU_Y--;
                             if (Constants.MENU_Y < Constants.MENU_Y_UPSTRICT) Constants.MENU_Y++; // 선택 외의 화면으로 커서 못나감
                             break;
                        }
                
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Constants.MENU_Y++;
                            if (Constants.MENU_Y > Constants.MENU_Y_DOWNSTRICT) Constants.MENU_Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                         }
                    case ConsoleKey.F5:
                        {
                            LoginId();
                            break;
                        }
                    case ConsoleKey.Enter:
                        {                      
                            if (Constants.MENU_Y == Constants.TABLE_Y) {Table.Menu(); Constants.Is_CHECK = false; }
                            if (Constants.MENU_Y == Constants.FAVORITE_Y) { Favorite.Menu(); Constants.Is_CHECK = false; }
                            if (Constants.MENU_Y == Constants.APPLICATION_Y) { Appliction.Menu(); Constants.Is_CHECK = false; }
                            if (Constants.MENU_Y == Constants.MYCLASS_Y) { Class.Menu(); Constants.Is_CHECK = false; }
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
