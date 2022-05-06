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
        private memberDAO memberDao;
        private memberDTO memberDto;
        private LogDAO logDao;
        private LogDTO logDto;
        private Screen Print;
        private MessageScreen PrintMessage;

        AdminMenu goingMenu= new AdminMenu();

        public Admin()
        {
           
        }

        public Admin(Screen InputMenu, MessageScreen message, memberDAO MemberDao, memberDTO MemberDto, LogDAO LogDao, LogDTO LogDto, BookDAO BookDao, BookDTO BookDto, BorrowBookDAO BorrowBookDao, BorrowBookDTO BorrowBookDto) 
                        : base(InputMenu, message, MemberDao, MemberDto, LogDao, LogDto, BookDao, BookDto, BorrowBookDao, BorrowBookDto)
        {
            goingMenu = new AdminMenu(InputMenu, message, MemberDao, MemberDto, LogDao, LogDto, BookDao, BookDto, BorrowBookDao, BorrowBookDto);

            this.Print = InputMenu;
            this.PrintMessage = message;
          
            this.memberDao = MemberDao;
            this.memberDto = MemberDto;
            this.logDao = LogDao;
            this.logDto = LogDto;
        }


        public void LoginAdmin() // 관리자 로그인
        {
            string id;
            string password;
            bool isCheckingLogin;

            memberDao.connection(); // db연결
            logDao.connection(); // db연결

            Console.Clear();
            Print.PrintMain();
            Print.PrintLogin();

            id = InputId(); // 아이디 입력
            password = InputPassword(); // 비밀번호 입력
            memberDto.Id = id;
            memberDto.Password = password;

            isCheckingLogin = memberDao.Login(memberDto.Id, memberDto.Password); // db에서 아이디 비밀번호 확인

            if (isCheckingLogin == Constants.isSucess)
            {
                logDao.StoreLog(Constants.ADMIN, Constants.LIBRARY, Constants.LOGIN); // db에 로그 내역 저장
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
