using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{

    internal class RemovalUser
    {
        private Screen Menu;
        private MessageScreen Message;
        private LogDAO logDao;
        private LogDTO logDto;
        private memberDAO memberDao;
        private memberDTO memberDto;
        private BorrowBookDTO  borrowBookDto;
        private BorrowBookDAO  borrowBookDao;

        public RemovalUser()
        {
        }

        public RemovalUser(Screen Menu, MessageScreen message)
        {
            this.Menu = Menu;
            this.Message = message;
            logDao = new LogDAO();
            logDto = new LogDTO();
            memberDao = new memberDAO();
            memberDto = new memberDTO();
            borrowBookDto = new BorrowBookDTO();
            borrowBookDao = new BorrowBookDAO();
        }

        public void SelectMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Menu.PrintMain();
                            Menu.PrintAdminMenu();
                            return;
                        }
                    default: continue;
                }

            }
        }
        public void ModifyMember()
        {
            string name;
            string id;
            bool isExistenceUsername;
            bool isExistenceId;

            Console.Clear();
            Menu.PrintInputUserName();

            memberDao.connection(); // db 연결
            logDao.connection(); // db연결
            borrowBookDao.connection(); // db연결

            Menu.PrintUserData(memberDao.StoreUserDataToList()); //유저목록 출력           
            Message.GreenColor(Message.PrintChooseRemoveUserMessage()); // 입장 후 안내메시지

            if (Menu.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴
            Console.SetCursorPosition(Constants.INPUT_NAME_X, Constants.INPUT_NAME_Y);

            name = InputName(); // 이름 입력

            memberDto.Name = name;
            isExistenceUsername = memberDao.IsCheckingExistenceUser(memberDto.Name);//이름 회원목록에 있는지 조사

            if (isExistenceUsername == Constants.isFail) // 회원목록에 없음
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                ClearCurrentLine(Constants.CURRENT_LOCATION);

                Message.RedColor(Message.PrintNoneUserMessage());
                SelectMenu();
                return;
            }
           
            Console.Clear();
            Menu.PrintSearchUser(memberDao.StoreUserDataToList(), memberDto.Name); // 이름맞는 사람 출력
            Message.PrintRemoveUserInputMessage(); // 안내메시지

            id = InputId(); // 아이디 입력

            memberDto.Id = id;
            isExistenceId = memberDao.IsCheckingExistenceId(memberDto.Id); //id 회원목록에 있는지 조사

            if (isExistenceId == Constants.isFail) 
            {
                Message.RedColor(Message.PrintNoneuser());
                SelectMenu(); 
                return; 
            }

            borrowBookDto.Id = id;
            isExistenceUsername = borrowBookDao.IsCheckingBorrowedBook(borrowBookDto.Id); // false면 해당 id  반납안한 책 있음 

            if (isExistenceUsername == Constants.isFail)
            {
                Message.RedColor(Message.PrintNoneReturnBookMessage());
                SelectMenu();
                return;
            }

            else
            {
                Message.GreenColor(Message.PrintRemoveUserMessage());

                logDto.Id = id;
                logDao.StoreLog(Constants.ADMIN, Constants.REMOVE_USER, logDto.Id); // db에 로그 내역 저장
                memberDao.RemoveUserInformation(memberDto.Id);// db 유저 삭제
                borrowBookDao.RemoveBorrowmember(borrowBookDto.Id); // 대여한 id db에서 제거
                SelectMenu();
            }

        }


        public string InputName() // 이름입력
        {
            string name;

            while (Constants.isLogin)
            {
                name = Console.ReadLine();
                if (Constants.isFail == Regex.IsMatch(name, Utility.Exception.NAME_CHECK))
                {                   
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return name;
        }

        public string InputId() // id 입력
        {

            string id;

            while (Constants.isLogin)
            {
                id = Console.ReadLine();
               ClearCurrentLine(Constants.CURRENT_LOCATION);

                if (Constants.isFail == Regex.IsMatch(id, Utility.Exception.ID_CHECK))
                {
                   ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                return id;
            }
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
