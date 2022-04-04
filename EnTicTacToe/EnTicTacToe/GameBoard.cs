using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    public class GameBoard
    {
        ScoreBoard Score = new ScoreBoard();
        static public char[] Array = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        int Index;

        
        public void FirstSet(int FirstNumber)
        {
            Array[FirstNumber - 1] = 'O';
            Console.Clear();
            Overlap();
        }
        
        public void SecondSet(int SecondNumber)
        {
            Array[SecondNumber - 1] = 'X';
            Console.Clear();
            Overlap();
        }
        public void Overlap()
        {
            Console.Clear();
            Score.Board();
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[0], Array[1], Array[2]);
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[3], Array[4], Array[5]);
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[6], Array[7], Array[8]);
            Console.Write("---l---l---\n");
        }

        public void Set() // 게임이 끝나면 입력했던 값 초기화 하기 위해 설정
        {
            for(Index=0;Index<9;Index++)
            {
                Array[Index] = ' ';
            }
        }
    }
}
