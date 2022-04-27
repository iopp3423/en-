using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;
using MySql.Data.MySqlClient;

namespace LibruryDatabase.Controls
{

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
            bool existenceUsername;
            bool existenceId;

            Console.Clear();
            Menu.PrintInputUserName();
            Menu.PrintUserData(); //유저목록 출력           
            Console.SetCursorPosition(Constants.INPUT_NAME_X, Constants.INPUT_NAME_Y);

            name = InputName(); // 이름 입력
            existenceUsername = CheckExistenceUser(name);

            if (existenceUsername == Constants.FAIL) // 회원목록에 없음
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);
                Constants.ClearCurrentLine(Constants.CURRENT_LOCATION);
                Console.Write("회원목록에 없습니다.  뒤로가기 : ESC         프로그램 종료 : F5");
                moveMenu();
            }

            else if (existenceUsername == Constants.PASS) // 이름이 회원목록에 있음
            {
                Console.Clear();
                Menu.PrintSearchUser(name); // 이름맞는 사람 출력

                Console.Write("삭제하실 유저 id를 입력하세요 :");
                id = InputId(); // 아이디 입력

                existenceId = CheckExistenceId(id); //id 회원목록에 있는지 조사
                if (existenceId == Constants.FAIL) { Console.Write("회원목록에 없습니다.  뒤로가기 : ESC         프로그램 종료 : F5"); moveMenu();  return; } // return;안쓰면 밑에 문장 실행됨 

                existenceUsername = CheckUserBorrowedBook(id); // 해당 id 반납하지 않은 책 조사

                if (existenceUsername == Constants.FAIL) Console.Write("반납하지 않은 도서가 있습니다.   뒤로가기 : ESC      프로그램 종료 : F5");
                else if(existenceUsername == Constants.PASS)Console.Write("삭제되었습니다.    뒤로가기 : ESC                 프로그램 종료 : F5");
                UserData.Get().RemoveUserInformation(id); // 유저 삭제
                moveMenu();
            }
           
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
                return id;
            }
        }

        public bool CheckExistenceId(string id) // 아이디 존재유무
        {
            

            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();
                string insertQuery = "SELECT * FROM member";
                MySqlCommand Command = new MySqlCommand(insertQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["id"].ToString() == id) return Constants.PASS;
                }
                user.Close();
            }
            return Constants.FAIL;
        }

        public bool CheckExistenceUser(string name) // 회원이름이 존재하는지 체크
        {
            

            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();
                string existenceUserQuery = "SELECT * FROM member";
                MySqlCommand Command = new MySqlCommand(existenceUserQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기
                
                while (userData.Read())
                {
                    if (userData["name"].ToString().Contains(name)) return Constants.SUCESS;
                }
                user.Close();
            }
            return Constants.FAIL;

        }

        public bool CheckUserBorrowedBook(string id) // 유저가 대여한 책이 있는지 체크
        {
            bool checkingBook = Constants.PASS;

            

            using (MySqlConnection user = new MySqlConnection (Constants.getQuery))
            {
                user.Open();
                string insertQuery = "SELECT * FROM BORROWMEMBER WHERE id = '" + id + " ';";
                MySqlCommand Command = new MySqlCommand(insertQuery, user);
                MySqlDataReader userData = Command.ExecuteReader(); // 데이터 읽기

                while (userData.Read())
                {
                    if (userData["returnbook"].ToString() == " ") checkingBook = Constants.FAIL; // 책을 대여했는데 한 권이라도 반납하지 않는 책이 있는경우
                }
                user.Close();
                return checkingBook;
            }
        }

    }
}
