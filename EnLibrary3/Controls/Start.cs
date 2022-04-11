using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnLibrary3.Controls
{
    using EnLibrary3.Views;
    class Start
    {
        static void Main(string[] args) // 관리자모드 추가해줘야함
        {           
            ListVO List = new ListVO();
            //Constants.constant = new Constants;
            Console.SetWindowSize(Constants.CONSOLE_SIZE_WIDTH, Constants.CONSOLE_SIZE_HDIGHT); // 콘솔크기 지정
            Print PrintCollection = new Print();
            User User = new User();
            Admin AdminDo = new Admin();
            bool isFinished = true;

            

            PrintCollection.PrintUserOrAdmin(); // 회원가입 or 로그인 화면

            // cursur에 입력값을 받으면(방향키) 방향키를 출력해줌 ex) 위 : UpArrow
            ConsoleKeyInfo cursur;
            //cursur = Console.ReadKey(true); // 방향키 아래 누르면 cursur에 DownArrow 들어감, 맨 처음 아무것도 안했을 때 입력값은 System.ConsoleKeyInfo이다.


            
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
                            if (x == 28 && y == 11) { Console.Clear(); AdminDo.Mode(); isFinished = false; break; }
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