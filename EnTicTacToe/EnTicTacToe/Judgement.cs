using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class Judgement
    {
        GameCheck Win = new GameCheck();
        public void Judge()
        {
            Win.Check(); // 행, 열, 대각선이 완성되는 것을 체크
            if (GameCheck.Draw == 9) // 첫 번째 플레이어면서 무승부 일 때
            {
                Console.Write("무승부\n");
                Console.Write("메뉴로 가려면 0번\n다시 시작하기는 1번을 눌러주세요:");
                VsUser.Winner = false; // VsUser 클래스의 while문 종료
            }
            else if (GameCheck.WinCheck == 1 && GameCheck.Draw % 2 == 0) // 첫 번째 플레이어면서 행, 열, 대각선 중 하나가 완성됐을 때
            {
                Console.Write("O Player 승리\n");
                Console.Write("메뉴로 가려면 0번\n다시 시작하기는 1번을 눌러주세요:");
                VsUser.Winner = false; // VsUser 클래스의 while문 종료
            }

            else if (GameCheck.WinCheck == 1 && GameCheck.Draw % 2 == 1) // 두 번째 플레이어면서 행, 열 대각선 중 하나가 완성됐을 때
            {
                Console.Write("X Player 승리\n");
                Console.Write("메뉴로 가려면 0번\n다시 시작하기는 1번을 눌러주세요:");
                VsUser.Winner = false; // VsUser 클래스의 while문 종료
            }
        }
    }
}
