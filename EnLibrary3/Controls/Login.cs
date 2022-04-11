using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Controls
{
    using EnLibrary3.Views;
    using EnLibrary3.Controls;
    internal class Login // 로그인 화면
    {
        Print View = new Print();
        InputKey Input = new InputKey();
        public ListVO List;
        bool isFinished = true;

        public void LibraryLogin() // 로그인 화면
        {
            Console.Clear();
            View.PrintLoginInformation();

            ConsoleKeyInfo cursur;
            // Console 창에 보여질 커서의 x 좌표와 y 좌표
            int x = 48, y = 6;
            while(isFinished)
            {
                // x 와 y 좌표에 커서를 표시하기위한 메서드
                Console.SetCursorPosition(x, y);

                cursur = Console.ReadKey(true);
                // 저장된 키의 정보에 대해 검색
                if (y == 6) { y++; Input.LoginId(); }
                if (y == 7) { y++; Input.LoginPw(); isFinished = false; }
                switch (cursur.Key)
                {
                    // 상
                    case ConsoleKey.UpArrow:
                        {
                            y--;
                            if (y < 6) y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            y++;
                            if (y > 7) y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {

                            break;
                        }
                    case ConsoleKey.Escape: // 종료
                        {
                            return;
                        }


                    default: break;

                }

            }
            foreach (UserVO list in List.UserList)
            {
                Console.WriteLine(list);
                Console.WriteLine("ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            }
        }
    }
}
