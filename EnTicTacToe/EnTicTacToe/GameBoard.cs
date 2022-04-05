﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    public class GameBoard
    {
        ScoreBoard Score = new ScoreBoard();
        static public char[] array = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        int index;

        
        public void FirstSet(int FirstNumber) // O 입력
        {
            array[FirstNumber - 1] = 'O';
            Console.Clear();
            Overlap();
        }
        
        public void SecondSet(int SecondNumber) // X 입력
        {
            array[SecondNumber - 1] = 'X';
            Console.Clear();
            Overlap();
        }
        public void Overlap()
        {
            Console.Clear();
            Score.Board();
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", array[0], array[1], array[2]);
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", array[3], array[4], array[5]);
            Console.Write("---l---l---\n");
            Console.Write(" {0} l {1} l {2}\n", array[6], array[7], array[8]);
            Console.Write("---l---l---\n");
        }

        public void Set() // 게임이 끝나면 입력했던 값 초기화 하기 위해 설정
        {
            
             

        }
    }
}
