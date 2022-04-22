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
using LibruryDatabase.Utility;


namespace LibruryDatabase.Controls
{
    internal class User
    {
        //정규식 고쳐야함
        Regex ID = new Regex(Utility.Exception.ID_CHECK);
        Regex PW = new Regex(Utility.Exception.PW_CHECK);
        Regex NUMBER = new Regex(Utility.Exception.NUMBER_CHECK);
        Regex AGE = new Regex(Utility.Exception.AGE_CHECK);
        Regex NAME = new Regex(Utility.Exception.NAME_CHECK);
        Regex ADDRESS = new Regex(Utility.Exception.ADDRESS_CHECK);
        

        Screen Menu = new Screen(); // 뷰 클래스 객체생성
        UserBook GoUser = new UserBook();


        public void JoinOrLogin() // 회원가입 or 로그인 화면
        {           

            Console.Clear();
            Menu.PrintMain();
            Menu.JoinOrLogin();


            if (Constants.BACK == moveMenu()) // 마우스 함수
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserOrAdmin();
                return;
            }
        }

        public bool moveMenu()
        {
            int Y = Constants.FIRSTY;
            int goingJoin = Constants.USER_Y;
            int goingLogin = Constants.ADMIN_Y;

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
                            if (Y < Constants.START_UP_Y) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.START_DOWN_Y) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == goingJoin) { Console.Clear(); JoinMember(); } // 회원가입
                            if (Y == goingLogin) { Console.Clear(); UserLogin(); } // 로그인
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
        
        public void JoinMember() // 회원가입
        {
           
            Console.Clear();
            Menu.JoinPrint();          
            Menu.PrintJoinMember();
            
            string id;
            string password;
            string passswordCheck;
            string name;
            string age;
            string callNumber;
            string address;

            id = LoginId();
            password = LoginPassword();
            passswordCheck = LoginPasswordCheck();

            if (password != passswordCheck)
            {
                Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.PW_FAIL_Y);
                Console.Write("비밀번호가 일치하지않습니다. 재입력 : Enter, 뒤로가기 : F5 두 번");
                while (Constants.ENTRANCE)
                {
                    Constants.cursor = Console.ReadKey(true);
                    switch (Constants.cursor.Key)
                    {
                        case ConsoleKey.Enter: JoinMember(); break;
                        case ConsoleKey.F5: return;
                        default: continue;
                    }
                }
            }
            name = LoginName();
            age = LoginAge();
            callNumber = LoginCallNumber();
            address = LoginAddress();


            UserData.Get().StoreUserInformation(id, password, name, callNumber, age, address);// 데이터베이스에 정보 추가

            Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.PW_FAIL_Y);
            Console.Write("회원가입이 완료되었습니다. Enter : 로그인 이동, 뒤로가기 : F5 두 번");
            while (Constants.ENTRANCE)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Enter: UserLogin(); break;
                    case ConsoleKey.F5: return;
                    default: continue;
                }
            }
           
        }

        public void UserLogin() // 유저 로그인
        {
            string id;
            string password;
            bool check;
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();

            id = LoginId();
            password = LoginPassword();

            check = CheckLogin(id, password);

            if(check == Constants.SUCESS) GoUser.StartBookmenu(id, password);
            Console.Write("회원정보가 일치하지 않습니다. 재입력 : Enter, 뒤로가기 : F5 두 번");

            while(Constants.ENTRANCE)
            {
                Constants.cursor = Console.ReadKey(true);
                switch(Constants.cursor.Key)
                {
                    case ConsoleKey.Enter: UserLogin(); break;
                    case ConsoleKey.F5: return;
                    default: continue;
                }
            }


        }
        public bool CheckLogin(string id, string password) // 로그인 체크
        {
            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string insertQuery = "SELECT * FROM member";
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


        public string LoginId() // id 입력
        {

            string id;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.ID_X, Constants.ID_Y);
                Constants.ClearCurrentLine();
                Console.Write("유저ID(영어, 숫자 포함(8~10자) :");
                id = Console.ReadLine();
                
                if (Constants.CHECK == ID.IsMatch(id)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.ID_X, Constants.ID_Y);
                    Console.Write("다시 입력해주세요"); continue;
                }
                break;

            }
            return id;
        }
        public string LoginPassword() // 비밀번호 입력
        {
            string password;

            while (Constants.LOGIN)
            {

                Console.SetCursorPosition(Constants.PW_X, Constants.PW_Y);
                password = ReadPassword();

                if (Constants.CHECK == PW.IsMatch(password))
                {
                    Console.SetCursorPosition(Constants.PW_X, Constants.PW_Y);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return password;
        }

        string LoginPasswordCheck() // 비밀번호 입력
        {
            string password;

            while (Constants.LOGIN)
            {

                Console.SetCursorPosition(Constants.PW_CHECK_X, Constants.PW_CHECK_Y);
                password = ReadPassword();

                if (Constants.CHECK == PW.IsMatch(password))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Constants.PW_CHECK_Y);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return password;
        }


        string ReadPassword() // 비밀번호 *처리
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - Constants.ONE);
                        int passwordX = Console.CursorLeft;
                        Console.SetCursorPosition(passwordX - Constants.ONE, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(passwordX - Constants.ONE, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }

        string LoginName() // 이름입력
        {
            string name;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.NAME_X, Constants.NAME_Y);
                name = Console.ReadLine();

                if (Constants.CHECK == NAME.IsMatch(name))
                {
                    Console.SetCursorPosition(Constants.NAME_X, Constants.NAME_Y);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return name;
        }

        string LoginCallNumber() // 전화번호
        {
            string callNumber;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.NUMBER_X, Constants.NUMBER_Y);
                callNumber = Console.ReadLine();

                if (Constants.CHECK == NUMBER.IsMatch(callNumber))
                {
                    Console.SetCursorPosition(Constants.NUMBER_X, Constants.NUMBER_Y);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return callNumber;
        }


        string LoginAddress() // 주소
        {
            string address;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.ADDRESS_X, Constants.ADDRESS_Y);
                address = Console.ReadLine();
                
                if (Constants.CHECK == ADDRESS.IsMatch(address))
                {
                     Console.SetCursorPosition(Constants.ADDRESS_X, Constants.ADDRESS_Y);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                
                break;
                
            }
            return address;
        }

        string LoginAge() // 나이입력
        {
            string age;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.AGE_X, Constants.AGE_Y);
                age = Console.ReadLine();

                if (Constants.CHECK == AGE.IsMatch(age))
                {
                    Console.SetCursorPosition(Constants.AGE_X, Constants.AGE_Y);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return age;
        }

    }

}

