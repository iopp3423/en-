using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibruryDatabase.Views;
using LibruryDatabase.Models;
using LibruryDatabase.Exception;

namespace LibruryDatabase.Controls
{
    internal class StartConnection
    {
        
        Screen Menu = new Screen(); // 뷰 클래스 객체생성
        User UserLibruary = new User();
        Admin AdminLibruary = new Admin();
        

 

        public void StartMenu() // 유저 or 관리자
        {
            Console.SetWindowSize(Constants.CONSOLE_SIZE_WIDTH, Constants.CONSOLE_SIZE_HDIGHT); // 콘솔크기 지정
            //BookVO.Get().Book(); // 책 리스트 저장
            //UserVO.Get().User();
            Console.Clear();
            Menu.PrintMain();
            Menu.PrintUserOrAdmin();
            Console.SetCursorPosition(Constants.FIRSTX, Constants.FIRSTY);// 처음 좌표
            int Y = Constants.FIRSTY;
            int userY = Constants.USER_Y;
            int adminY = Constants.ADMIN_Y;



            // 메인 컨트롤러
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
                            if (Y < Constants.START_UP_Y) Y++; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    // 하
                    case ConsoleKey.DownArrow:
                        {
                            Y++;
                            if (Y > Constants.START_DOWN_Y) Y--; // 선택 외의 화면으로 커서 못나감
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            if (Y == userY) { Console.Clear(); UserLibruary.JoinOrLogin(); }
                            //if (Y == adminY) { Console.Clear(); AdminLibruary.AdminLogin(); }
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
