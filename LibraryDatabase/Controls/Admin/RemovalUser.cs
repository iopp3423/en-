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
        public Screen Menu;
        public MessageScreen Message;

        public RemovalUser()
        {
        }

        public RemovalUser(Screen Menu, MessageScreen message)
        {
            this.Menu = Menu;
            this.Message = message;
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
            Menu.PrintUserData(); //유저목록 출력           

            Message.GreenColor(Message.PrintChooseRemoveUserMessage());

            if (Menu.IsGoingBackMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.INPUT_NAME_X, Constants.INPUT_NAME_Y);

            name = InputName(); // 이름 입력
            isExistenceUsername = UserData.Get().IsCheckingExistenceUser(name); //이름 회원목록에 있는지 조사
            if (isExistenceUsername == Constants.isFail) // 회원목록에 없음
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                ClearCurrentLine(Constants.CURRENT_LOCATION);

                Message.RedColor(Message.PrintNoneUserMessage());
                SelectMenu();
                return;
            }
           
            Console.Clear();
            Menu.PrintSearchUser(name); // 이름맞는 사람 출력
            Message.PrintRemoveUserInputMessage();
            id = InputId(); // 아이디 입력

            isExistenceId = UserData.Get().IsCheckingExistenceId(id); //id 회원목록에 있는지 조사
            if (isExistenceId == Constants.isFail) 
            {
                Message.RedColor(Message.PrintNoneuser());
                SelectMenu(); 
                return; 
            } 

            isExistenceUsername = BookData.Get().IsCheckingUserBorrowedBook(id);// 해당 id 반납하지 않은 책 조사

            if (isExistenceUsername == Constants.isFail)
            {
                Message.RedColor(Message.PrintNoneReturnBookMessage());
                SelectMenu();
                return;
            }

            Message.GreenColor(Message.PrintRemoveUserMessage());

            LogData.Get().StoreLog(Constants.ADMIN, Constants.REMOVE_USER , id); // 로그에 저장
            UserData.Get().RemoveUserInformation(id); // 유저 삭제
            UserData.Get().userData.Clear(); // 리스트 초기화
            UserData.Get().StoreUserData(); // 리스트에 북 데이터 저장
            SelectMenu();
                        
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
