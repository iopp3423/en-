using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;
using LibruryDatabase.Utility;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Controls
{
    internal class Admin : User
    {
        Screen Menu = new Screen();
        AdminMenu goingMenu= new AdminMenu();
        

        public void LoginAdmin() // 관리자 로그인
        {
            string id;
            string password;
            bool checkingLogin;

            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();
            id = InputId(); // 아이디 입력
            password = InputPassword(); // 비밀번호 입력
            checkingLogin = UserData.Get().LoginCheck(id, password); // 아이디 비밀번호 확인

            if (checkingLogin == Constants.SUCESS) goingMenu.ChooseMenu(); // 정보 맞으면 메뉴이동

            else if (checkingLogin == Constants.FAIL)
            {
                Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.ERROR_Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("회원정보가 일치하지 않습니다. 재입력 : Enter, 뒤로가기 : ESC");
                Console.ResetColor();
            }

            while (Constants.ENTRANCE) // 관리자 불일치시 재입력 컨트롤러
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Enter: LoginAdmin(); break;
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Menu.PrintMain();
                            Menu.PrintUserOrAdmin();
                            return;
                        }
                    default: continue;
                }
            }
        }

       
    }
}
