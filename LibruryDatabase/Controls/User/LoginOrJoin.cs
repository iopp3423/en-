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
    internal class LoginOrJoin
    {

        Screen Menu = new Screen(); // 뷰 클래스 객체생성
        UserMenu GoUser = new UserMenu();


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
                Console.SetCursorPosition(Console.CursorLeft, Y);
                Constants.cursor = Console.ReadKey(true);

                switch (Constants.cursor.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            Y--;
                            if (Y < Constants.USER_Y) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.ADMIN_Y) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == goingJoin) { Console.Clear(); JoinMember(); } // 회원가입
                            if (Y == goingLogin) { Console.Clear(); UserLogin(); } // 로그인
                            break;
                        }
                     case ConsoleKey.Escape:
                        {
                            return Constants.BACK_MENU;
                        }

                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }

                    default: break;

                }
            }
        }
        public void BackMenuOrReEnter()
        {
            while (Constants.ENTRANCE)
                {
                    Constants.cursor = Console.ReadKey(true);
                    switch (Constants.cursor.Key)
                    {
                        case ConsoleKey.Enter: UserLogin(); break;
                        case ConsoleKey.Escape: return;
                        default: continue;
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
            bool overlapCheck;


            id = InputId();
         
            overlapCheck = UserData.Get().CheckIdOverlap(id); // 데베에서 id 중복 확인

            if (overlapCheck == Constants.SUCESS)
            {
                Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.ERROR_Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("이미 존재하는 ID 입니다. 재입력 : Enter, 뒤로가기 : ESC 두 번");
                Console.ResetColor();

                while (Constants.ENTRANCE)
                {
                    Constants.cursor = Console.ReadKey(true);
                    switch (Constants.cursor.Key)
                    {
                        case ConsoleKey.Enter: JoinMember(); break;
                        case ConsoleKey.Escape: return;
                        default: continue;
                    }
                }
            }

            password = InputPassword();
            passswordCheck = InputPasswordCheck();

            if (password != passswordCheck)
            {
                Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.PW_FAIL_Y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("비밀번호가 일치하지않습니다. 재입력 : Enter, 뒤로가기 : ESC 두 번");
                Console.ResetColor();
                while (Constants.ENTRANCE)
                {
                    Constants.cursor = Console.ReadKey(true);
                    switch (Constants.cursor.Key)
                    {
                        case ConsoleKey.Enter: JoinMember(); break;
                         case ConsoleKey.Escape: return;
                        default: continue;
                    }
                }
            }
            name = InputName();
            age = InputAge();
            callNumber = InputCallNumber();
            address = InputAddress();


            UserData.Get().StoreUserInformation(id, password, name, callNumber, age, address);// 데이터베이스에 정보 추가
            Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.PW_FAIL_Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("회원가입이 완료되었습니다. Enter : 로그인 이동, 뒤로가기 : ESC 두 번");
            Console.ResetColor();


            while (Constants.ENTRANCE)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Enter: UserLogin(); break;
                     case ConsoleKey.Escape: return;
                    default: continue;
                }
            }
           
        }

        public void UserLogin() // 로그인
        {
            string id;
            string password;
            bool overlapCheck;
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();

            id = InputId();
            password = InputPassword();

            overlapCheck = UserData.Get().CheckLogin(id, password); //데베에서 회원 유무 확인

            if (overlapCheck == Constants.SUCESS) GoUser.StartBookmenu(id, password);
            Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.ERROR_Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("회원정보가 일치하지 않습니다. 재입력 : Enter, 뒤로가기 : ESC 두 번");
            Console.ResetColor();

            while (Constants.ENTRANCE)
            {
                Constants.cursor = Console.ReadKey(true);
                switch(Constants.cursor.Key)
                {
                    case ConsoleKey.Enter: UserLogin(); break;
                     case ConsoleKey.Escape: return;
                    default: continue;
                }
            }
        }


        public string InputId() // id 입력
        {
            string id;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.ID_X, Constants.ID_Y);
                id = Console.ReadLine();
           
                if (Constants.CHECK == Regex.IsMatch(id, Utility.Exception.ID_CHECK)) // 정규식에 맞지 않으면
                {

                    Console.SetCursorPosition(Constants.ID_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.Write("ID(영어, 숫자 포함(8~10자) :");
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;              
            }
          
            Menu.PrintInputMessage();
            return id;
        }

             
        public string InputPassword() // 비밀번호 입력
        {
            string password;

            while (Constants.LOGIN)
            {

                Console.SetCursorPosition(Constants.PW_X, Constants.PW_Y);
                password = ReadPassword();

                if (Constants.CHECK == Regex.IsMatch(password, Utility.Exception.PW_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.PW_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.Write("PW(영어, 숫자 포함(4~10자) :");
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;
            }
            Menu.PrintInputMessage();
            return password;
        }


        string InputPasswordCheck() // 비밀번호확인 입력
        {
            string password;

            while (Constants.LOGIN)
            {

                Console.SetCursorPosition(Constants.PW_CHECK_X, Constants.PW_CHECK_Y);
                password = ReadPassword();

               if (Constants.CHECK == Regex.IsMatch(password, Utility.Exception.PW_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("PW확인(영어, 숫자 포함(4~10자) :");
                    Menu.PrintLoginErrorMessage(); continue;               
                }
                break;
            }
            Menu.PrintInputMessage();
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
                        password = password.Substring(Constants.CURRENT_LOCATION, password.Length - Constants.ONE);
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


        string InputName() // 이름입력
        {
            string name;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.NAME_X, Constants.NAME_Y);
                name = Console.ReadLine();

                if (Constants.CHECK == Regex.IsMatch(name, Utility.Exception.NAME_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.NAME_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("유저 이름(2~5자) :");
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;
            }
            Menu.PrintInputMessage();
            return name;
        }   

        string InputCallNumber() // 전화번호
        {
            string callNumber;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.NUMBER_X, Constants.NUMBER_Y);
                callNumber = Console.ReadLine();

                if (Constants.CHECK == Regex.IsMatch(callNumber, Utility.Exception.NUMBER_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.NUMBER_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    
                    Console.WriteLine("핸드폰 번호(01x-xxxx-xxxx) :");
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;
            }
            Menu.PrintInputMessage();
            return callNumber;
        }


        string InputAddress() // 주소
        {
            string address;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.ADDRESS_X, Constants.ADDRESS_Y);
                address = Console.ReadLine();

                if (Constants.CHECK == Regex.IsMatch(address, Utility.Exception.ADDRESS_CHECK)) // 정규식에 맞지 않으면
                {
                     Console.SetCursorPosition(Constants.ADDRESS_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);


                    Console.WriteLine("주소 :");
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                Menu.PrintInputMessage();
                break;
                
            }
           
            return address;
        }

        string InputAge() // 나이입력
        {
            string age;

            while (Constants.LOGIN)
            {
                Console.SetCursorPosition(Constants.AGE_X, Constants.AGE_Y);
                age = Console.ReadLine();

                if (Constants.CHECK == Regex.IsMatch(age, Utility.Exception.AGE_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.AGE_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    Console.WriteLine("나이 :");
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;
            }
            Menu.PrintInputMessage();
            return age;
        }

        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }

    }

}

