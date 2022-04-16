using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SejongTimeTable.Views;
using SejongTimeTable.Models;

namespace SejongTimeTable.Controls
{
    class Logging
    { 
        Printing MenuView = new Printing();
        TimeTable Table = new TimeTable();
        FavoriteClass Favorite = new FavoriteClass();
        ApplicationClass Application = new ApplicationClass();
        MyClass MySubject = new MyClass();

        ClassVO MyData = new ClassVO();
        ClassVO Search = new ClassVO();
        ClassVO User = new ClassVO();
        ClassVO Subject = new ClassVO();


        Regex ID = new Regex(Constants.ID_CHECK);
        Regex PW = new Regex(Constants.PW_CHECK);

        

        public Logging()
        {
            MyData.ClassList(); // 리스트에 엑셀값 저장
            User.Data.Add(MyData.Data[0]);
            User.Data.Add(MyData.Data[14]);
            Table = new TimeTable(MyData);           
            Favorite = new FavoriteClass(MyData, User);
            Application = new ApplicationClass(MyData, User, Subject);
        }

        public void LoginId()
        {
            string id;
            Console.Clear();
            MenuView.PrintLogin();

            while (true)
            {
                Console.SetCursorPosition(Constants.ID_X_AXIS, Constants.ID_Y_AXIS);
                id = Console.ReadLine();

                if (Constants.Is_CHECK != ID.IsMatch(id))
                {
                    Console.SetCursorPosition(Constants.ID_X_AXIS, Constants.ID_Y_AXIS);
                    Console.Write("다시 입력해주세요"); continue;
                }
                LoginPw(id); /////////////////이거 한 번 봐야함
                break;              
            }
            
        }
        
         public void LoginPw(string id)
        {
            string pw;

            while (Constants.IS_TRUE)
            { 
                Console.SetCursorPosition(Constants.PW_X_AXIS, Constants.PW_Y_AXIS);
                pw = Console.ReadLine();

                if (Constants.Is_CHECK != PW.IsMatch(pw))
                {
                    Console.SetCursorPosition(Constants.PW_X_AXIS, Constants.PW_Y_AXIS);
                    Console.Write("다시 입력해주세요:"); continue;
                }

                if (id == "17013150" && pw == "99999999") { Constants.IS_TRUE = false; LoginAfter(); break; }
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
                    

                }
                LoginId(); ////////////////////얘도 한 번 봐야함
                break;
            }
     
        }

        public void LoginAfter()
        {
            Console.Clear();
            MenuView.PrintESC();
            MenuView.PrintMenu();
            MenuView.Back();
            Constants.IS_TRUE = true;  


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
                            LoginId();  ///////////////////////////얘도 한 번 봐야함
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Constants.MENU_Y == Constants.TABLE_Y) { Constants.Is_CHECK = false; Table.Menu(); }
                            if (Constants.MENU_Y == Constants.FAVORITE_Y) { Constants.Is_CHECK = false; Favorite.Menu(); }
                            if (Constants.MENU_Y == Constants.APPLICATION_Y) { Constants.Is_CHECK = false; Application.ApplyMenu();}
                            if (Constants.MENU_Y == Constants.MYCLASS_Y) { Constants.Is_CHECK = false; MySubject.Menu(); }
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
