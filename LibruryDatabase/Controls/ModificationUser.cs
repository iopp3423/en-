using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Views;
using LibruryDatabase.Exception;
using System.Text.RegularExpressions;

namespace LibruryDatabase.Controls
{
    internal class ModificationUser
    {
        Regex PW = new Regex(Utility.Exception.PW_CHECK);
        Regex NUMBER = new Regex(Utility.Exception.NUMBER_CHECK);
        Regex ADDRESS = new Regex(Utility.Exception.ADDRESS_CHECK);
        Screen Menu = new Screen();
        public void ModifyUserInformation(string id, string password)
        {
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLoginUser(id, password);
            Menu.PrintUserInformation();

            if (Constants.BACK == moveMenu(id)) // 마우스 함수
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserMenu();
                return;
            }
        }
        public bool moveMenu(string id)
        {
            int Y = Constants.GOING_PHONE;

            while (Constants.ENTRANCE) // 참이면
            {
                Console.SetCursorPosition(Constants.FIRSTX, Y);
                Constants.cursor = Console.ReadKey(true);

                switch (Constants.cursor.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            Y--;
                            if (Y < Constants.GOING_PHONE) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.GOING_ADDRESS) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.GOING_PHONE) { ModifyPhoneNumber(id); } 
                            if (Y == Constants.GOING_PASSWORD) {  ModifyPassword(id); } 
                            if (Y == Constants.GOING_ADDRESS) { ModifyAddress(id); }                        
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            return Constants.BACK_MENU;
                        }

                    case ConsoleKey.Escape: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }

                    default: break;

                }
            }
        }
        public void ModifyPhone(string callNumber, string id)// 전화번호 데베에서 변경
        {
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "UPDATE member SET phone ='" + callNumber + "' WHERE id = '" + id +" ';";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                Command.ExecuteNonQuery(); // 
            }
        }
        public void ModifyPhoneInformation(string password, string id) // 비밀번호 데베에서 변경
        {
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "UPDATE member SET pw ='" + password + "' WHERE id = '" + id + " ';";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                Command.ExecuteNonQuery(); // 
            }
        }
        public void ModifyAddressInformation(string address, string id)// 주소 데베에서 변경
        {
            string getBook = "Server=localhost;Database=enbook;Uid=root;Pwd=0000;";

            using (MySqlConnection book = new MySqlConnection(getBook))
            {
                book.Open();
                string insertQuery = "UPDATE member SET address ='" + address + "' WHERE id = '" + id + " ';";
                MySqlCommand Command = new MySqlCommand(insertQuery, book);
                Command.ExecuteNonQuery(); // 
            }
        }

        public void ModifyPhoneNumber(string id)  // 전화번호
        {
            string callNumber;
            Constants.ClearCurrentLine(); // 현재 줄 지우기          
            callNumber = InputCallNumber(); // 입력받기
            ModifyPhone(callNumber, id); // 정보 변경
            Console.SetCursorPosition(Constants.DONE_REVISE_X, Constants.DONE_REVISE_Y);
            Console.Write("정보가 변경되었습니다. 뒤로가기 : ESC, 프로그램 종료 : F5");
        }

        public void ModifyPassword(string id) // 비밀번호
        {
            string password;
            Constants.ClearCurrentLine(); // 현재 줄 지우기   
            password = InputPasswordCheck();// 입력받기
            ModifyPhoneInformation(password, id); // 정보 변경
            Console.SetCursorPosition(Constants.DONE_REVISE_X, Constants.DONE_REVISE_Y);
            Console.Write("정보가 변경되었습니다. 뒤로가기 : ESC, 프로그램 종료 : F5");
        }

        public void ModifyAddress(string id) // 주소
        {
            string address;
            Constants.ClearCurrentLine(); // 현재 줄 지우기 
            address = InputAddress();// 입력받기
            ModifyAddressInformation(address, id); // 정보 변경
            Console.SetCursorPosition(Constants.DONE_REVISE_X, Constants.DONE_REVISE_Y);
            Console.Write("정보가 변경되었습니다. 뒤로가기 : ESC, 프로그램 종료 : F5");
        }


        string InputCallNumber() // 전화번호입력
        {
            string callNumber;

            while (Constants.LOGIN)
            {
                Console.Write("핸드폰 번호(01x - xxxx - xxxx) :");
                callNumber = Console.ReadLine();

                if (Constants.CHECK == NUMBER.IsMatch(callNumber))
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PHONE); //커서 조정
                    Constants.ClearCurrentLine();
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return callNumber;
        }

        string InputPasswordCheck() // 비밀번호 입력
        {
            string password;

            while (Constants.LOGIN)
            {
                Console.Write("유저 PW(영어, 숫자 포함(4~10자) :");
                password = Console.ReadLine();
                Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PASSWORD);

                if (Constants.CHECK == PW.IsMatch(password))
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PASSWORD); //커서 조정
                    Constants.ClearCurrentLine();
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return password;
        }

        string InputAddress() // 주소입력
        {
            string address;
            Console.Write("주소 :");
            while (Constants.LOGIN)
            {            
                address = Console.ReadLine();
                Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_ADDRESS);


                if (Constants.CHECK == ADDRESS.IsMatch(address))
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_ADDRESS);
                    Constants.ClearCurrentLine();
                    Console.Write("다시 입력해주세요:"); continue;
                }

                break;

            }
            return address;
        }
    }
}
