using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    public class GameCheck
    {
        static public int winCheck = 0; // 1이 되면 게임 종료
        static public int draw = 0; // 무승부 세는 변수

        public void Check()
        {
            ////////////////////////행이 같을 때
            if (GameBoard.array[0] == GameBoard.array[1] && GameBoard.array[1] == GameBoard.array[2]) winCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.array[3] == GameBoard.array[4] && GameBoard.array[4] == GameBoard.array[5]) winCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.array[6] == GameBoard.array[7] && GameBoard.array[7] == GameBoard.array[8]) winCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            ////////////////////////열이 같을 때
            else if (GameBoard.array[0] == GameBoard.array[3] && GameBoard.array[3] == GameBoard.array[6]) winCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.array[1] == GameBoard.array[4] && GameBoard.array[4] == GameBoard.array[7]) winCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.array[2] == GameBoard.array[5] && GameBoard.array[5] == GameBoard.array[8]) winCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            ////////////////////////대각선이 같을 때
            else if (GameBoard.array[0] == GameBoard.array[4] && GameBoard.array[4] == GameBoard.array[8]) winCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
            else if (GameBoard.array[2] == GameBoard.array[4] && GameBoard.array[4] == GameBoard.array[6]) winCheck = 1; // 공백일 경우에 게임이 끝나는 경우를  != ' '를 통해 제거
        }
    }
}
