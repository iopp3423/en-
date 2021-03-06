using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnLibrary3.Views;
using EnLibrary3.Models;

namespace EnLibrary3.Controls
{

    internal class Join // 회원가입 화면
    {
        Print View = new Print();
        InputKey Input = new InputKey();
        bool isFinished = true;
        ListVO List = new ListVO();
        public Join()
        {
            InputKey Input = new InputKey(List);
        }


        public void JoinLibrary()
        {
            User UserMode = new User();
            Console.Clear();
            View.JoinPrint();
            View.PrintJoinInformation();

            ConsoleKeyInfo cursur;
            // Console 창에 보여질 커서의 x 좌표와 y 좌표
            int x = 34, y = 6;
            while(isFinished)
            {
                // x 와 y 좌표에 커서를 표시하기위한 메서드
                Console.SetCursorPosition(x, y);
              
                // 저장된 키의 정보에 대해 검색

                if (y == 6) { y++; Input.Id(); }
                if (y == 7) { y++; Input.Pw(); }
                if (y == 8) { y++; Input.PwPass(); }
                if (y == 9) { y++; Input.Name(); }
                if (y == 10) { y++; Input.Age(); }
                if (y == 11) { y++; Input.CallNumber(); }
                if (y == 12) { y++; Input.Address(); /*Console.Clear();UserMode.Mode();*/ isFinished = false; }
                cursur = Console.ReadKey(true);

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
                            y++;
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
