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
        UserMenu GoUser = new UserMenu();
        private memberDAO memberDao;
        private memberDTO memberDto;
        private LogDAO logDao;
        private LogDTO logDto;
        private Screen Menu;
        private MessageScreen message;
        private string id;
        private string password;
        private string passswordCheck;
        private string name;
        private string age;
        private string callNumber;
        private string address;
        private bool isOverlapCheck;



        public LoginOrRegister() 
        {
            
        }

        public LoginOrRegister(Screen InputMenu, MessageScreen message, memberDAO MemberDao, memberDTO MemberDto, LogDAO LogDao, LogDTO LogDto
                               ,BookDAO BookDao, BookDTO BookDto, BorrowBookDAO BorrowBookDao, BorrowBookDTO BorrowBookDto)
        {
            GoUser = new UserMenu(InputMenu, message, MemberDao, MemberDto, LogDao, LogDto, BookDao, BookDto, BorrowBookDao, BorrowBookDto);

            this.Menu = InputMenu;
            this.message = message;
            this.memberDao = MemberDao;
            this.memberDto = MemberDto;
            this.logDao = LogDao;
            this.logDto = LogDto;
        }


        public void RegisterOrLogin() // 회원가입 or 로그인 화면
        {
           
            Console.Clear();
            Menu.PrintMain();
            Menu.RegisterOrLogin();
          

            if (Constants.isBack == SelectMenu()) // 마우스 함수
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserOrAdmin();
                return;
            }
                
        }
        

        public bool SelectMenu()
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
            memberDao.connection(); // db연결
            logDao.connection(); // db연결 

            Console.Clear();
            Menu.RegisterPrint();          
            Menu.PrintRegisterMember();

            message.GreenColor(message.PrintContinueRequestmessage());

            while (Constants.isPassing) // 입장 후 뒤로가기 or 입력
            {

                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Menu.PrintMain();
                    Menu.PrintUserOrAdmin();
                    return;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter)
                {
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    break;
                }
            }

            memberDto.Id = InputId();
            logDto.Id = memberDto.Id;

            isOverlapCheck = memberDao.IsCheckingIdOverlap(id); // db에 중복 id 있으면 true

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
            memberDto.Password = password;
            memberDto.Name = InputName();
            memberDto.Age = InputAge();
            memberDto.Phone = InputCallNumber();
            memberDto.Address = InputAddress();


            memberDao.StoreUserInformation(memberDto.Id, memberDto.Password, memberDto.Name, memberDto.Phone,memberDto.Age,memberDto.Address); // db에 회원가입정보 저장

            Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.PW_FAIL_Y);
            message.GreenColor(message.PrintDoneRegister());

            logDao.StoreLog(logDto.Id, Constants.LIBRARY, Constants.REGISTER); // db에 로그 내역 저장

            memberDao.close(); // db닫기
            logDao.close(); // db닫기

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
            memberDao.connection(); // db연결
            logDao.connection(); // db연결

            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLogin();

            id = InputId();
            if (id == "#") // 입력도중 뒤로가기 - 바꿔야할듯
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.RegisterOrLogin();
                return;
            }
            password = InputPassword();

            memberDto.Id = id;
            memberDto.Password = password;
            logDto.Id = id;

            isOverlapCheck = memberDao.IsCheckingLogin(memberDto.Id, memberDto.Password); // db에 id, pw 같은 회원 있는지
         
            if (isOverlapCheck == Constants.isSucess)
            {
                logDao.StoreLog(logDto.Id, Constants.LIBRARY, Constants.LOGIN); // db에 로그 내역 저장
                GoUser.StartBookmenu(id, password); // 유저메뉴
            }

            memberDao.close(); // db닫기
            logDao.close(); // db닫기

            Console.SetCursorPosition(Constants.PW_FAIL_X, Constants.ERROR_Y);
            message.RedColor(message.PrintErrorUserInformation()); // 회원불일치 메시지

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


                if (CheckNull(id))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    message.PrintIdInputMessage();
                    Menu.PrintLoginErrorMessage();
                    continue; // 널값이면 건너뛰기
                }
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

                if (CheckNull(password))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    message.PrintIdInputMessage();
                    Menu.PrintLoginErrorMessage();
                    continue; // 널값이면 건너뛰기
                }
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


        public string InputPasswordCheck() // 비밀번호확인 입력
        {

            while (Constants.isLogin)
            {

                Console.SetCursorPosition(Constants.PW_CHECK_X, Constants.PW_CHECK_Y);
                passswordCheck = ReadPassword();

                if (CheckNull(passswordCheck))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    message.PrintPasswordCheckMessage();
                    Menu.PrintLoginErrorMessage();
                    continue; // 널값이면 건너뛰기
                }
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


        public string ReadPassword() // 비밀번호 *처리
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


        public string InputName() // 이름입력
        {

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.NAME_X, Constants.NAME_Y);
                name = Console.ReadLine();

                if (CheckNull(name))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    message.PrintInputNameMessage();
                    Menu.PrintLoginErrorMessage(); 
                    continue;
                }
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

        public string InputCallNumber() // 전화번호
        {

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.NUMBER_X, Constants.NUMBER_Y);
                callNumber = Console.ReadLine();

                if (CheckNull(callNumber))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    message.PrintInutCallNumberMessage();
                    Menu.PrintLoginErrorMessage(); 
                    continue;
                }
                if (Constants.isFail == Regex.IsMatch(callNumber, Utility.Exception.NUMBER_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.NUMBER_X, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);

                    message.PrintInutCallNumberMessage();
                    Menu.PrintLoginErrorMessage(); 
                    continue;
                    
                }
                break;
            }
            Menu.PrintInputMessage();
            return callNumber;
        }


        public string InputAddress() // 주소
        {

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.ADDRESS_X, Constants.ADDRESS_Y);
                address = Console.ReadLine();

                if (CheckNull(address))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    message.PrintInputAddressMessage();
                    Menu.PrintLoginErrorMessage(); 
                    continue;
                }
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

        public string InputAge() // 나이입력
        {

            while (Constants.isLogin)
            {
                Console.SetCursorPosition(Constants.AGE_X, Constants.AGE_Y);
                age = Console.ReadLine();

                if (CheckNull(age))
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    message.PrintInputAgeMessage();
                    Menu.PrintLoginErrorMessage(); 
                    continue;
                }

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

        public bool CheckNull(string checkNull)
        {
            if (string.IsNullOrEmpty(checkNull))
            {
                ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                return Constants.isPassing;
            }
            return Constants.isFail;
        }
    }

}

