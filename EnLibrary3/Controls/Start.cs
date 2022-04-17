using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnLibrary3.Views;
using EnLibrary3.Models;

namespace EnLibrary3.Controls
{

    class Start
    {
        static void Main(string[] args) // 관리자모드 추가해줘야함
        {           
            ListVO List = new ListVO();
            Console.SetWindowSize(Constants.CONSOLE_SIZE_WIDTH, Constants.CONSOLE_SIZE_HDIGHT); // 콘솔크기 지정
            Print PrintCollection = new Print();
            User User = new User();
            Admin AdminDo = new Admin();
            bool isFinished = true;

            

            PrintCollection.PrintUserOrAdmin(); // 회원가입 or 로그인 화면

            ConsoleKeyInfo cursur;


            
            // Console 창에 보여질 커서의 x 좌표와 y 좌표
            int x = 28, y = 10;
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
                            if (x == 28 && y == 10) { Console.Clear(); User.DoUser(); isFinished = false; break; }
                            if (x == 28 && y == 11) { Console.Clear(); AdminDo.DoAdmin(); isFinished = false; break; }
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
/* 키보드 입력값 확인
cursur = Console.ReadKey();
Console.Write(cursur.Key);
*/