using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    public class GameCheck
    {
        static public int WinCheck = 0; // 1이 되면 게임 종료
        static public int Draw = 0; // 무승부 세는 변수

        public void Check()
        {
            ////////////////////////행이 같을 때
            if (GameBoard.Array[0] == GameBoard.Array[1] && GameBoard.Array[1] == GameBoard.Array[2] && GameBoard.Array[0] != ' ') WinCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.Array[3] == GameBoard.Array[4] && GameBoard.Array[4] == GameBoard.Array[5] && GameBoard.Array[3] != ' ') WinCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.Array[6] == GameBoard.Array[7] && GameBoard.Array[7] == GameBoard.Array[8] && GameBoard.Array[6] != ' ') WinCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            ////////////////////////열이 같을 때
            else if (GameBoard.Array[0] == GameBoard.Array[3] && GameBoard.Array[3] == GameBoard.Array[6] && GameBoard.Array[0] != ' ') WinCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.Array[1] == GameBoard.Array[4] && GameBoard.Array[4] == GameBoard.Array[7] && GameBoard.Array[1] != ' ') WinCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.Array[2] == GameBoard.Array[5] && GameBoard.Array[5] == GameBoard.Array[8] && GameBoard.Array[2] != ' ') WinCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            ////////////////////////대각선이 같을 때
            else if (GameBoard.Array[0] == GameBoard.Array[4] && GameBoard.Array[4] == GameBoard.Array[8] && GameBoard.Array[0] != ' ') WinCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.Array[2] == GameBoard.Array[4] && GameBoard.Array[4] == GameBoard.Array[6] && GameBoard.Array[2] != ' ') WinCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
        }
    }
}
