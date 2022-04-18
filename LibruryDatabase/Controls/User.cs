using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using System.Text.RegularExpressions;

namespace LibruryDatabase.Controls
{
    internal class User
    {
        Regex ID = new Regex(Constants.ID_CHECK);
        Regex PW = new Regex(Constants.PW_CHECK);
        Regex NUMBER = new Regex(Constants.NUMBER_CHECK);
        Regex AGE = new Regex(Constants.AGE_CHECK);
        Regex NAME = new Regex(Constants.NAME_CHECK);


        Start StartBack = new Start();
        Showing Menu = new Showing(); // 뷰 클래스 객체생성


        public void JoinOrLogin() // 회원가입 or 로그인 화면
        {           

            Console.Clear();
            Menu.PrintMain();
            Menu.JoinOrLogin();


            if (Constants.BACK == cursur()) // 마우스 함수
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserOrAdmin();
                return;
            }
        }

        public bool cursur()
        {
            int Y = Constants.FIRSTY;
            int JoinY = Constants.USER_Y;
            int LoginY = Constants.ADMIN_Y;

            while (Constants.ENTRANCE) // 참이면
            {
                Console.SetCursorPosition(Constants.FIRSTX, Y);
                Constants.cursur = Console.ReadKey(true);

                switch (Constants.cursur.Key)
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
                            if (Y == JoinY) { Console.Clear(); JoinMember(); } // 회원가입
                            if (Y == LoginY) { Console.Clear(); UserLogin(); } // 로그인
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            return Constants.BACK_MENU;
                        }

                    case ConsoleKey.Escape: // 종료
                        {
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
            name = LoginName();
            age = LoginAge();
            callNumber = LoginCallNumber();
            address = LoginAddress();
        }

        public void UserLogin() // 유저 로그인
        {
            string id;
            string password;
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();

            id = LoginId();
            password = LoginPassword();
           
        }

        public void AdminLogin() // 관리자 로그인
        {
            string id, password;
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();
            Console.SetCursorPosition(Constants.LOGIN_X, Constants.LOGIN_Y);

            id = LoginId();
            password = LoginPassword();

        }

        string LoginId() // id 입력
        {

            string id;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.ID_X, Constants.ID_Y);
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
        string LoginPassword() // 비밀번호 입력
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
                /*
                if (Constants.CHECK == ADDRESS.IsMatch(address))
                {
                     Console.SetCursorPosition(Constants.ADDRESS_X, Constants.ADDRESS_Y);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                */
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

