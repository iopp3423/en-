using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;
using LibruryDatabase.Exception;
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
            checkingLogin = LoginCheck(id, password); // 아이디 비밀번호 확인

            if (checkingLogin == Constants.SUCESS) goingMenu.ChooseMenu(); // 정보 맞으면 메뉴이동
            else if(checkingLogin == Constants.FAIL) Console.Write("회원정보가 일치하지 않습니다. 재입력 : Enter, 뒤로가기 : ESC 두 번");

            while (Constants.ENTRANCE)
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

        public bool LoginCheck(string id, string password) // 로그인 체크
        {
            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string insertQuery = "SELECT * FROM admin";
                MySqlCommand Command = new MySqlCommand(insertQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id && userData["pw"].ToString() == password) return Constants.SUCESS;
                }
                user.Close();
            }
            return Constants.FAIL;

        }
    }
}
