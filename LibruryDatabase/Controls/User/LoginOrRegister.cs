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
    class LoginOrRegister
    {
        //Screen Menu = new Screen(); // 뷰 클래스 객체생성
        UserMenu GoUser = new UserMenu();      

        public string id;
        public string password;
        public string passswordCheck;
        string name;
        string age;
        string callNumber;
        string address;
        bool isOverlapCheck;

        public Screen Menu;
        public MessageScreen message;

        public LoginOrRegister() // 왜 안쓰면 터질까
        {
            
        }

        public LoginOrRegister(Screen InputMenu, MessageScreen message)
        {
            this.Menu = InputMenu;
            this.message = message;
            GoUser = new UserMenu(Menu, message);           
        }


        public void RegisterOrLogin() // 회원가입 or 로그인 화면
        {
            BookData.Get().StoreBookData(); // 리스트에 북 데이터 저장

            Console.Clear();
            Menu.PrintMain();
            Menu.RegisterOrLogin();

                
            if (Constants.isBack == IsSelectingMenu()) // 마우스 함수
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserOrAdmin();
                return;
            }
                
        }
        

        public bool IsSelectingMenu()
        {
            int Y = Constants.FIRSTY;
            int goingRegister = Constants.USER_Y;
            int goingLogin = Constants.ADMIN_Y;

            while (Constants.isEntrancing) // 참이면
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
                            if (Y == goingRegister) { Console.Clear(); RegisterMember(); } // 회원가입
                            if (Y == goingLogin) { Console.Clear(); UserLogin(); } // 로그인
                            break;
                        }
                     case ConsoleKey.Escape:
                        {
                            return Constants.isBackMenu;
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
            while (Constants.isEntrancing)
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
        
        public void RegisterMember() // 회원가입
        {
           
            Console.Clear();
            Menu.RegisterPrint();          
            Menu.PrintRegisterMember();        


            id = InputId();
         
            isOverlapCheck = UserData.Get().IsCheckingIdOverlap(id); // 데베에서 id 중복 확인

            if (isOverlapCheck == Constants.isSucess)
            {
                Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.ERROR_Y);
                message.RedColor(message.PrintAlreadyId());

                while (Constants.isEntrancing)
                {
                    Constants.cursor = Console.ReadKey(true);
                    switch (Constants.cursor.Key)
                    {
                        case ConsoleKey.Enter: RegisterMember(); break;
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
                message.RedColor(message.PrintAlreadyPassword());

                while (Constants.isEntrancing)
                {
                    Constants.cursor = Console.ReadKey(true);
                    switch (Constants.cursor.Key)
                    {
                        case ConsoleKey.Enter: RegisterMember(); break;
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
            message.GreenColor(message.PrintDoneRegister());

            name = UserData.Get().Bringname(id);// 해당 id 이름 가져오기
            LogData.Get().StoreLog(name, Constants.LIBRARY, Constants.REGISTER); // 로그에 저장


            while (Constants.isEntrancing)
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
            
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();

            id = InputId();
            password = InputPassword();
          
            isOverlapCheck = UserData.Get().IsCheckingLogin(id, password); //데베에서 회원 유무 확인
            

            if (isOverlapCheck == Constants.isSucess)
            {
                name = UserData.Get().Bringname(id);// 해당 id 이름 가져오기
                LogData.Get().StoreLog(name, Constants.LIBRARY, Constants.LOGIN); // 로그에 기록
                GoUser.StartBookmenu(id, password);
            }

            Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.ERROR_Y);
            message.RedColor(message.PrintErrorUserInformation());

            while (Constants.isEntrancing)
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

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.ID_X, Constants.ID_Y);
                id = Console.ReadLine();
           
                if (Constants.isFail == Regex.IsMatch(id, Utility.Exception.ID_CHECK)) // 정규식에 맞지 않으면
                {

                    Console.SetCursorPosition(Constants.ID_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    message.PrintIdInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;              
            }
          
            Menu.PrintInputMessage();
            return id;
        }

             
        public string InputPassword() // 비밀번호 입력
        {

            while (Constants.isLogin)
            {

                Console.SetCursorPosition(Constants.PW_X, Constants.PW_Y);
                password = ReadPassword();

                if (Constants.isFail == Regex.IsMatch(password, Utility.Exception.PW_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.PW_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    message.PrintPasswordInputMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;
            }
            Menu.PrintInputMessage();
            return password;
        }


        string InputPasswordCheck() // 비밀번호확인 입력
        {

            while (Constants.isLogin)
            {

                Console.SetCursorPosition(Constants.PW_CHECK_X, Constants.PW_CHECK_Y);
                passswordCheck = ReadPassword();

               if (Constants.isFail == Regex.IsMatch(passswordCheck, Utility.Exception.PW_CHECK))
                {
                    Console.SetCursorPosition(Constants.PW_CHECK_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    message.PrintPasswordCheckMessage();
                    Menu.PrintLoginErrorMessage(); continue;               
                }
                break;
            }
            Menu.PrintInputMessage();
            return passswordCheck;
        }


        string ReadPassword() // 비밀번호 *처리
        {
            string passwordChangeStar = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    passwordChangeStar += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(passwordChangeStar))
                    {
                        passwordChangeStar = passwordChangeStar.Substring(Constants.CURRENT_LOCATION, passwordChangeStar.Length - Constants.ONE);
                        int passwordX = Console.CursorLeft;
                        Console.SetCursorPosition(passwordX - Constants.ONE, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(passwordX - Constants.ONE, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return passwordChangeStar;
        }


        string InputName() // 이름입력
        {

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.NAME_X, Constants.NAME_Y);
                name = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(name, Utility.Exception.NAME_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.NAME_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    message.PrintInputNameMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;
            }
            Menu.PrintInputMessage();
            return name;
        }   

        string InputCallNumber() // 전화번호
        {

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.NUMBER_X, Constants.NUMBER_Y);
                callNumber = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(callNumber, Utility.Exception.NUMBER_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.NUMBER_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    message.PrintInutCallNumberMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                break;
            }
            Menu.PrintInputMessage();
            return callNumber;
        }


        string InputAddress() // 주소
        {

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.ADDRESS_X, Constants.ADDRESS_Y);
                address = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(address, Utility.Exception.ADDRESS_CHECK)) // 정규식에 맞지 않으면
                {
                     Console.SetCursorPosition(Constants.ADDRESS_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                     ClearCurrentLine(Constants.CURRENT_LOCATION);


                    message.PrintInputAddressMessage();
                    Menu.PrintLoginErrorMessage(); continue;
                    
                }
                Menu.PrintInputMessage();
                break;
                
            }
           
            return address;
        }

        string InputAge() // 나이입력
        {

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.AGE_X, Constants.AGE_Y);
                age = Console.ReadLine();

                if (Constants.isFail == Regex.IsMatch(age, Utility.Exception.AGE_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.AGE_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    message.PrintInputAgeMessage();
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
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }

    }

}

