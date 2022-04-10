using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Views
{
    internal class User // 회원가입 로그인 고르는 화면
    {
        Print View = new Print();
        InputKey Input = new InputKey();
        Login DoLogin = new Login();
        Join DoJoin = new Join();
        bool isFinished = true;

        public void Mode()
        {
            View.LibraryPrint();// 맨 위 도서관 프린트
            View.ChooseJoinLoginPrint(); // 로그인, 회원가입 화면 프린트

            ConsoleKeyInfo cursur;
            // Console 창에 보여질 커서의 x 좌표와 y 좌표
            int x = 31, y = 10;
            // 커서의 이동을 표현하는 것이 목적이므로 무한 루프를통해 커서표현을 반복
            while(isFinished)
            {
                // x 와 y 좌표에 커서를 표시하기위한 메서드
                Console.SetCursorPosition(x, y);

                cursur = Console.ReadKey(true);
                // 저장된 키의 정보에 대해 검색

                switch (cursur.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            y--;
                            if (y < 10) y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            y++;
                            if (y > 11) y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (x == 31 && y == 10) { Console.Clear(); DoJoin.JoinLibrary(); isFinished = false;  break; }
                            if (x == 31 && y == 11) { Console.Clear(); DoLogin.LibraryLogin(); isFinished = false; break; }
                            break;
                        }                    
                    case ConsoleKey.Escape: // 종료
                        {
                            return;
                        }
                    

                    default: break;

                }

            }
        }
    }
}
