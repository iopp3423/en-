using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Exception;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Controls
{
    // 이름,id 검색했을 때 없는 유저면 재 검색하라고 안내메시지 나와야함, 삭제 완료메시지 및 뒤로가기 메뉴 나와야함
    internal class RemovalUser
    {

        Screen Menu = new Screen();
        public void moveMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.ENTRANCE)
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
            bool existenceUser;

            Console.Clear();
            Menu.PrintInputUserName();
            Menu.PrintUserData(); //유저목록 출력           
            Console.SetCursorPosition(Constants.INPUT_NAME_X, Constants.INPUT_NAME_Y);

            name = InputName(); // 이름 입력
            existenceUser = CheckExistenceUser(name);
            if (existenceUser == Constants.FAIL) ExistenceUserAfter();



            Console.Clear();
            Menu.PrintSearchUser(name); // 이름맞는 사람 출력
            Console.Write("삭제하실 유저 id를 입력하세요 :");
            id = InputId();
            
           
            //UserData.Get().RemoveUserInformation(id); // 유저 삭제
        }

        public void ExistenceUserAfter()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
            Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
            Console.Write("회원목록에 없습니다.  뒤로가기 : ESC         프로그램 종료 : F5");
            moveMenu();
        }


        string InputName() // 이름입력
        {
            string name;

            while (Constants.LOGIN)
            {
                name = Console.ReadLine();
                if (Constants.CHECK == Regex.IsMatch(name, Utility.Exception.NAME_CHECK))
                {                   
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요 :"); continue;
                }
                break;
            }
            return name;
        }

        public string InputId() // id 입력
        {

            string id;

            while (Constants.LOGIN)
            {
                id = Console.ReadLine();
                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);

                if (Constants.CHECK == Regex.IsMatch(id, Utility.Exception.ID_CHECK))
                {
                    Constants.ClearCurrentLine(Constants.BEFORE_INPUT_LOCATION);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                    Console.Write("id를 다시 입력해주세요 :"); continue;
                }
                break;
            }
            return id;
        }

        public bool CheckExistenceUser(string name) // 회원이 존재하는지 체크
        {
            string getUser = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection user = new MySqlConnection(getUser))
            {
                user.Open();
                string existenceUserQuery = "SELECT * FROM member WHERE name = '" + name + " ';";
                MySqlCommand Command = new MySqlCommand(existenceUserQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["name"].ToString() == name) return Constants.SUCESS;
                }
                user.Close();
            }
            return Constants.FAIL;

        }

    }
}
