using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;

namespace LibruryDatabase.Controls
{
    internal class ModificationUser
    {
        private string callNumber;
        private string password;
        private string address;
        private LogDAO logDao;
        private LogDTO logDto;
        private memberDAO memberDao;
        private memberDTO memberDto;


        private Screen Menu;
        private MessageScreen Print;

        public ModificationUser()
        {
        }

        public ModificationUser(Screen Menu, MessageScreen message)
        {
            this.Menu = Menu;
            this.Print = message;
            logDao = new LogDAO();
            logDto = new LogDTO();
            memberDao = new memberDAO();
            memberDto = new memberDTO();
        }

        public bool IsGoingReturnMenu() //이전 메뉴로 돌아가기
        {
            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            return Constants.isBackMenu;
                        }
                    default: continue;
                }
            }
        }


        public void ModifyUserInformation(string id, string password)
        {
            memberDao.connection(); // db 연결

            Console.Clear();
            Menu.PrintMain();
            Menu.PrintLoginUser(memberDao.StoreUserDataToList(),id, password); // 로그인한 아이디 비밀번호 screen으로 보내서 출력
            Menu.PrintUserInformation();

            memberDao.close(); // db닫기

            if (Constants.isBack == IsChoosingMenu(id)) // 마우스 함수
            {
                Console.Clear();
                Menu.PrintMain();
                Menu.PrintUserMenu();
                return;
            }
        }

        public bool IsChoosingMenu(string id)
        {
            int Y = Constants.GOING_PHONE;

            while (Constants.isEntrancing) // 참이면
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
                            return IsGoingReturnMenu();
                        }
                     case ConsoleKey.Escape:
                        {
                            return Constants.isBackMenu;
                        }
                    default: break;

                }
            }
        }


        public void ModifyPhoneNumber(string id)  // 전화번호
        {
            memberDao.connection(); // db연결
            logDao.connection(); // db연결

            ClearCurrentLine(Constants.CURRENT_LOCATION); // 현재 줄 지우기
            callNumber = InputCallNumber(); // 입력받기
            memberDto.Phone = callNumber;
            memberDto.Id = id; // 로그인한 아이디
            memberDao.ModifyPhone(memberDto.Phone, memberDto.Id); // db에서 전화번호 변경

            ClearandStore();// 리스트 초기화 후 저장

            logDto.Id = id;
            logDto.Log = callNumber;
            logDao.StoreLog(logDto.Id, "번호변경", logDto.Log);// 로그에 저장

            memberDao.close(); // db닫기
            logDao.close(); // db닫기

            ModifyAfterMessage();// 안내메시지
        }

        public void ModifyPassword(string id) // 비밀번호
        {
            ClearCurrentLine(Constants.CURRENT_LOCATION); // 현재 줄 지우기   
            password = InputPasswordCheck();// 입력받기

            memberDto.Id = id;
            memberDto.Password = password;
            memberDao.ModifyPassword(memberDto.Password, memberDto.Id);

            logDto.Id = id;
            logDto.Log = password;
            logDao.StoreLog(logDto.Id, "비밀번호변경", logDto.Log);// 로그에 저장

            memberDao.close(); // db닫기
            logDao.close(); // db닫기

            ModifyAfterMessage();// 안내메시지
        }

        public void ModifyAddress(string id) // 주소
        {
            
            ClearCurrentLine(Constants.CURRENT_LOCATION); // 현재 줄 지우기 
            address = InputAddress();// 입력받기

            memberDto.Id = id;
            memberDto.Address = address;
            memberDao.ModifyAddress(memberDto.Id, memberDto.Address);
            ClearandStore();// 리스트 초기화 후 저장

            logDto.Id = id;
            logDto.Log = address;
            logDao.StoreLog(logDto.Id, "주소변경", logDto.Log);// 로그에 저장

            memberDao.close(); // db닫기
            logDao.close(); // db닫기

            ModifyAfterMessage();// 안내메시지
        }


        public string InputCallNumber() // 전화번호입력
        {

            while (Constants.isLogin)
            {
                Print.PrintInutCallNumberMessage();
                callNumber = Console.ReadLine();

                if (CheckNull(callNumber))
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PHONE); //커서 조정
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    continue;
                }

                Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PHONE);
                if (Constants.isFail == Regex.IsMatch(callNumber, Utility.Exception.NUMBER_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PHONE); //커서 조정
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Print.PrintReEnterMessage(); continue;
                }
                break;
            }
            return callNumber;
        }

        public string InputPasswordCheck() // 비밀번호 입력
        {

            while (Constants.isLogin)
            {
                Print.PrintPasswordInputMessage();
                password = Console.ReadLine();

                if (CheckNull(password))
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PASSWORD); //커서 조정
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    continue;
                }

                Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PASSWORD);

                if (Constants.isFail == Regex.IsMatch(password, Utility.Exception.PW_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_PASSWORD); //커서 조정
                   ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Print.PrintReEnterMessage(); continue;
                }
                break;
            }
            return password;
        }

        public string InputAddress() // 주소입력
        {

           
            while (Constants.isLogin)
            {
                Print.PrintInputAddressMessage();
                address = Console.ReadLine();

                if (CheckNull(address))
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_ADDRESS);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    continue;
                }
                Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_ADDRESS);

                if (Constants.isFail == Regex.IsMatch(address, Utility.Exception.ADDRESS_CHECK)) // 정규식에 맞지 않으면
                {
                    Console.SetCursorPosition(Constants.FIRSTX, Constants.GOING_ADDRESS);
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Print.PrintReEnterMessage(); continue;
                }

                break;

            }
            return address;
        }

        public void ModifyAfterMessage() // 정보 수정 후 메시지
        {
            Console.SetCursorPosition(Constants.DONE_REVISE_X, Constants.DONE_REVISE_Y);
            Print.GreenColor(Print.PrintReviseInformation());
        }

        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }

        public void ClearandStore()
        {
            memberDao.StoreUserDataToList(); // 저장
        }


        public bool CheckNull(string checkNull) // null값 체크
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
