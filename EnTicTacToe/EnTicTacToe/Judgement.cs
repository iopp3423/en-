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
            if (GameCheck.Draw == 9)
            {
                Console.Write("무승부");
                Console.Write("게임을 다시 시작하기 0번을 눌러주세요.");
                VsUser.Winner = false;
            }
            if (GameCheck.WinCheck == 1) // 행, 열 대각선 완성되면 게임종료
            {
                Console.Write("O Player 승리\n");
                Console.Write("게임을 다시 시작하기 0번을 눌러주세요.");
                VsUser.Winner = false;
            }

            Win.Check(); // 행, 열, 대각선이 완성되는 것을 체크
            if (GameCheck.Draw == 9)
            {
                Console.Write("무승부 입니다.");
                Console.Write("게임을 다시 시작하기 0번을 눌러주세요.");
                VsUser.Winner = false;
            }
            if (GameCheck.WinCheck == 1) // 행, 열 대각선 완성되면 게임종료
            {
                Console.Write("X Player 승리\n");
                Console.Write("게임을 다시 시작하기 0번을 눌러주세요.");
                VsUser.Winner = false;
            }
        }
    }
}
