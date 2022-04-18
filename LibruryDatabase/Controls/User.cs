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
        Start StartBack = new Start();
        Showing Menu = new Showing(); // 뷰 클래스 객체생성

        string ReadPassword() // 비밀번호 *
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

        public void JoinMember()
        {
            string id;
            string password;
            string passswordCheck;
            string name;
            string age;
            string callNumber;
        }

        public void JoinOrLogin() // 회원가입 or 로그인 화면
        {
            int Y = Constants.FIRSTY;
            int JoinY = Constants.USER_Y;
            int LoginY = Constants.ADMIN_Y;

            Console.Clear();
            Menu.JoinPrint();
            Menu.JoinOrLogin();

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



        public void UserLogin() // 유저 로그인
        {
            string id;
            string password;
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();

            id = LoginId();
            password = LoginPw();

        }

        public void AdminLogin() // 관리자 로그인
        {
            string id, password;
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();
            Console.SetCursorPosition(Constants.LOGIN_X, Constants.LOGIN_Y);

            id = LoginId();
            password = LoginPw();

        }

        string LoginId() // id 입력
        {

            string id;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.LOGIN_X, Constants.LOGIN_Y);
                id = Console.ReadLine();

                if (Constants.CHECK == ID.IsMatch(id)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.LOGIN_X, Constants.LOGIN_Y);
                    Console.Write("다시 입력해주세요"); continue;
                }
                break;

            }
            return id;

        }
        string LoginPw() // 비밀번호 입력
        {
            string password;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.LOGIN_X, Constants.PASSWORED_Y);
                password = ReadPassword();

                if (Constants.CHECK == PW.IsMatch(password))
                {
                    Console.SetCursorPosition(Constants.LOGIN_X, Constants.PASSWORED_Y);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return password;
        }

    }




}

