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

        Screen Menu = new Screen();
        public void ChoiceMenu() //이전 메뉴로 돌아가기
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
                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("회원삭제 : Enter                                          뒤로가기 : ESC");
            Console.ResetColor();
            if (Menu.EntranceAfterReturnMenu() == Constants.isBackMenu) return;// 입장 후 뒤로가기 메뉴

            Console.SetCursorPosition(Constants.INPUT_NAME_X, Constants.INPUT_NAME_Y);

            name = InputName(); // 이름 입력
            isExistenceUsername = UserData.Get().CheckExistenceUser(name); //이름 회원목록에 있는지 조사
            if (isExistenceUsername == Constants.isFail) // 회원목록에 없음
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
               ClearCurrentLine(Constants.CURRENT_LOCATION);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("회원목록에 없습니다.              뒤로가기 : ESC         프로그램 종료 : F5");
                Console.ResetColor();
                ChoiceMenu();
                return;
            }
           
            Console.Clear();
            Menu.PrintSearchUser(name); // 이름맞는 사람 출력
            Console.Write("삭제하실 유저 id를 입력하세요 :");
            id = InputId(); // 아이디 입력

            isExistenceId = UserData.Get().CheckExistenceId(id); //id 회원목록에 있는지 조사
            if (isExistenceId == Constants.isFail) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("회원목록에 없습니다.             뒤로가기 : ESC         프로그램 종료 : F5");
                Console.ResetColor();
                ChoiceMenu(); 
                return; 
            } 

            isExistenceUsername = BookData.Get().CheckUserBorrowedBook(id);// 해당 id 반납하지 않은 책 조사

            if (isExistenceUsername == Constants.isFail)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("반납하지 않은 도서가 있습니다.   뒤로가기 : ESC      프로그램 종료 : F5");
                Console.ResetColor();
                ChoiceMenu();
                return;
            }
               
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("삭제되었습니다.                      뒤로가기 : ESC       프로그램 종료 : F5");
            Console.ResetColor();

            UserData.Get().RemoveUserInformation(id); // 유저 삭제
            ChoiceMenu();
                        
        }


        string InputName() // 이름입력
        {
            string name;

            while (Constants.isLogin)
            {
                name = Console.ReadLine();
                if (Constants.isFail == Regex.IsMatch(name, Utility.Exception.NAME_CHECK))
                {                   
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요 :"); continue;
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
                    Console.Write("id를 다시 입력해주세요 :"); continue;
                }
                return id;
            }
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
