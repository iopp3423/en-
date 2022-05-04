using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Utility;
using System.Text.RegularExpressions;
using LibruryDatabase.Models;
using System.IO;



namespace LibruryDatabase.Controls
{
    internal class LogManage
    {

        public Screen Print;
        public MessageScreen Message;

        public LogManage()
        {

        }

        public LogManage(Screen Menu, MessageScreen message)
        {
            this.Print = Menu;
            this.Message = message;
        }


        public void PrintLogMenu() // 로그메뉴 프린트
        {
            LogData.Get().PrintLog.Clear(); // 리스트에 저장된 로그값 재 조회시 수정된 값 적용하기 위해 전체 데이터 삭제 후 저장
            LogData.Get().Storelog(); // 로그 리스트에 저장
            PrintMenu(); // 로그메뉴화면 출력


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
                            if (Y > Constants.VERIFICATION_LOG) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == Constants.SEARCH_BOOK) { ReviseLog();  PrintMenu(); } // 로그수정
                            if (Y == Constants.ADD_BOOK) { ResetLog(); PrintMenu();} // 로그초기화
                            if (Y == Constants.REMOVE_BOOK) { StoreLog(); IsGoingReturnMenu(); PrintMenu(); } // 로그저장
                            if (Y == Constants.RIVISE_USER) { RemoveFile(); IsGoingReturnMenu(); PrintMenu(); } // 로그파일삭제
                            if (Y == Constants.VERIFICATION_LOG) { VerifyLog(); PrintMenu(); } // 로그확인
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


        public void ReviseLog() // 로그삭제
        {
            string number;
            Console.Clear();
            Message.GreenColor(" >> 입력 : Enter                                   뒤로가기 : F5");
            Console.WriteLine();
            Print.PrintLog(); // 로그내역 출력
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);

            while (Constants.isPassing)
            {
                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    return;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter)
                {                   
                    break;
                }
            }

            while (Constants.isPassing)
            {
                number = InputNumber(); // 로그번호 입력
                if (!LogData.Get().VerifyLogExistence(number)) Message.RedColor("없는 로그입니다. 재입력 : Enter 뒤로가기 : ESC");
                else break;

                Constants.cursor = Console.ReadKey(true);
                if (Constants.cursor.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else if (Constants.cursor.Key == ConsoleKey.Enter)
                {
                    continue;
                }
            }

            ClearCurrentLine(Constants.CURRENT_LOCATION);
            LogData.Get().RemoveLog(number); // 로그 삭제
            LogData.Get().PrintLog.Clear(); // 로그 리스트 초기화
            LogData.Get().Storelog(); // 로그 리스트 저장
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Print.PrintReMoveLogAfter(); // 로그 삭제 후 안내메시지
            IsGoingReturnMenu();
        }
        public void ResetLog() // 전체 로그데이터 삭제
        {
            Console.Clear();
            Print.PrintRemoveAllData(); // 로그제거설명
            Print.PrintLog(); // 로그내역 출력          
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);

            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            RemoveListandDatabase();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {                       
                            return;
                        }
                    default: continue;
                }
            }
        }

        public void StoreLog() // 로그저장
        {
            Console.Clear();
            Print.PrintStoreData();
            Print.PrintLog(); // 로그내역 출력             
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);

            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            LogWrite();
                            return;
                        }
                    case ConsoleKey.Escape:
                        {                         
                            return;
                        }
                    default: continue;
                }

            }

        }

        public void RemoveFile() // 로그파일삭제
        {
            Console.Clear();
            Print.PrintRemoveFile();           
            Print.PrintLog(); // 로그내역 출력
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);

            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            RemoveDesktopFile();
                            RemoveListandDatabase(); // 로그 데이터 삭제
                            LogData.Get().PrintLog.Clear(); // 로그 리스트 초기화
                            LogData.Get().Storelog(); // 로그 리스트 저장
                            return;
                        }
                    case ConsoleKey.Escape:
                        {
                            
                            return;
                        }
                    default: continue;
                }

            }            
        }

        public void VerifyLog() // 전체 로그내역 조회
        {
            Console.Clear();
            Message.GreenColor("   >>뒤로가기 : ESC\n\n");
            Print.PrintLog(); // 로그내역 출력
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Constants.CURRENT_LOCATION);

            while (Constants.isEntrancing)
            {
                Constants.cursor = Console.ReadKey(true);
                switch (Constants.cursor.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                    default: continue;
                }

            }


        }


        public string InputNumber()  // 번호입력
        {
            string Number;

            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.CURRENT_LOCATION);
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Print.PrintReviseLog();
            while (Constants.isPassing)
            {
                Number = Console.ReadLine();
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - Constants.BEFORE_INPUT_LOCATION);

                if (Constants.isFail == Regex.IsMatch(Number, Utility.Exception.QUANTITY))
                {
                    ClearCurrentLine(Constants.CURRENT_LOCATION);
                    Message.PrintReEnterMessage(); continue;
                }
                break;
            }
            return Number;
        }

        public void RemoveListandDatabase() // 데베에 저장된 로그 삭제
        {
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Print.PrintReMoveLogAfter();
            LogData.Get().RemoveAllLog(); // 데베 로그 삭제
            LogData.Get().PrintLog.Clear(); // 리스트 로그 삭제
        }

        public void ClearCurrentLine(int number) // 줄 지우기
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, Console.CursorTop - number);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Constants.CURRENT_LOCATION, currentLineCursor);
        }
        

        public void RemoveDesktopFile()//데스크탑 파일 제거
        {
            LogData.Get().RemoveDesktopFile();
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Print.PrintReMoveLogAfter();
        }


        public void LogWrite() //바탕화면에 저장
        {
            LogData.Get().LogWrite();
            ClearCurrentLine(Constants.CURRENT_LOCATION);
            Print.PrintStoreAfter();
        }

        public void PrintMenu()
        {
            Console.Clear();
            Print.PrintMain();
            Print.PrintLogMenu();
        }
    }  
}
