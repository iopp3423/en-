using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Views
{
    using EnLibrary3.Modes;
    internal class Join // 회원가입 화면
    {
        Print View = new Print();
        InputKey Input = new InputKey();
        public void JoinLibrary()
        {
            Console.Clear();
            View.JoinPrint();
            View.PrintJoinInformation();

            ConsoleKeyInfo cursur;
            // Console 창에 보여질 커서의 x 좌표와 y 좌표
            int x = 34, y = 6;
            for (; ; )
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
                            if (y < 6) y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            y++;
                            if (y > 13) y--; // 선택 외의 화면으로 커서 못나감
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
        }
    }
}
