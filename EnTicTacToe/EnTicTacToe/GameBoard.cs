using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    public class GameBoard
    {
        static public char[] Array = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

        public void FirstSet(int FirstNumber)
        {
            Array[FirstNumber - 1] = 'O';
            Console.Clear();
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[0], Array[1], Array[2]);
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[3], Array[4], Array[5]);
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[6], Array[7], Array[8]);
            Console.Write("---l---l---\n");
        }
        
        public void SecondSet(int SecondNumber)
        {
            Array[SecondNumber - 1] = 'X';
            Console.Clear();
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[0], Array[1], Array[2]);
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[3], Array[4], Array[5]);
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", Array[6], Array[7], Array[8]);
            Console.Write("---l---l---\n");
        }
    }
}
