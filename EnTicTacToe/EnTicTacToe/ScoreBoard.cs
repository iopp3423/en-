using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class ScoreBoard
    {
        static public int XPlayer=0, YPlayer=0;
        public void Board()
        {
            Console.WriteLine("---------------현재 스코어--------------");
            Console.WriteLine("X PLAYER 점수 : {0}       O PLAYER 점수 : {1}", XPlayer, YPlayer);
            Console.WriteLine("----------------------------------------");
        }
    }
}
