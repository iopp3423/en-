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
    internal class Admin : LoginOrRegister
    {

        AdminMenu goingMenu= new AdminMenu();
     
        public Screen Print;
        public MessageScreen PrintMessage;

        public Admin()
        {

        }

        public Admin(Screen Menu, MessageScreen message) : base(Menu, message)
        {
            this.Print = Menu;
            this.PrintMessage = message;
            goingMenu = new AdminMenu(Print, PrintMessage);
        }
        


        public void LoginAdmin() // 관리자 로그인
        {
            string id;
            string password;
            bool isCheckingLogin;

            Console.Clear();
            Print.PrintMain();
            Print.PrintLogin();
            id = InputId(); // 아이디 입력
            password = InputPassword(); // 비밀번호 입력
            isCheckingLogin = UserData.Get().IsLoginCheck(id, password); // 아이디 비밀번호 확인

            if (isCheckingLogin == Constants.isSucess)
            {

                LogData.Get().StoreLog(Constants.ADMIN, Constants.LIBRARY,Constants.LOGIN); // 로그에 저장
                goingMenu.ChooseMenu(); // 정보 맞으면 메뉴이동
            }

            else if (isCheckingLogin == Constants.isFail)
            {
                Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.ERROR_Y);
                PrintMessage.RedColor(PrintMessage.PrintErrorUserInformation());
            }

            while (Constants.isEntrancing) // 관리자 불일치시 재입력 컨트롤러
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Enter: LoginAdmin(); break;
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Print.PrintMain();
                            Print.PrintUserOrAdmin();
                            return;
                        }
                    default: continue;
                }
            }
        }

       
    }
}
