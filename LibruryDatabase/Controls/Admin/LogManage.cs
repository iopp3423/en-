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
    internal class LogManage
    {

        public Screen Print;

        public LogManage()
        {

        }

        public LogManage(Screen Menu)
        {
            this.Print = Menu;
        }


        public void PrintLogMenu() // 로그메뉴 프린트
        {
            LogData.Get().Storelog(); // 로그 리스트에 저장
            Console.Clear();
            Print.PrintMain();
            Print.PrintLogMenu();


            if (Constants.isBack == SelectLogMenu()) // 컨트롤러
            {
                Console.Clear();
                Print.PrintMain();
                Print.PrintAdminMenu();
                return;
            }
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
                    case ConsoleKey.F5: // 종료
                        {
                            Environment.Exit(Constants.EXIT);
                            break;
                        }
                    default: continue;
                }
            }
        }


        public bool SelectLogMenu() // 로그메뉴 내 이동
        {
            int Y = Constants.SEARCH_BOOK;

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
                            if (Y < Constants.SEARCH_BOOK) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.REVISE_BOOK) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.SEARCH_BOOK) { ReviseLog(); IsGoingReturnMenu(); return Constants.isFail; } // 로그수정
                            if (Y == Constants.ADD_BOOK) { } // 로그초기화
                            if (Y == Constants.REMOVE_BOOK) { } // 로그저장
                            if (Y == Constants.REVISE_BOOK) { } // 로그삭제
                            //return IsGoingReturnMenu();
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


        public void ReviseLog()
        {
            string number;
            Console.Clear();           
            Print.PrintLog(); // 로그내역 출력
            number = InputNumber(); // 로그번호 입력
            Print.PrintReviseLog(); // 삭제할 로그 설명 프린트
            LogData.Get().RemoveLog(number); // 로그 삭제           
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Print.PrintReMoveLogAfter();
    
        }
        public void ResetLog()
        {

        }
        public void StoreLog()
        {

        }
        public void RemoveLog()
        {

        }

       
        string InputNumber() //
        {
            string Number;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.CURRENT_LOCATION);
            Print.PrintReviseLog();
            while (Constants.isPassing)
            {
                Number = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

                if (Constants.isFail == Regex.IsMatch(Number, Utility.Exception.QUANTITY))
                {
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Console.Write("다시 입력해주세요:"); continue;
                }
                break;
            }
            return Number;
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
