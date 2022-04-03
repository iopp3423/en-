using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class VsUser
    {
        GameBoard Game = new GameBoard();
        public void User()
        {
            int First;
            int Second;
           
            First = int.Parse(Console.ReadLine());// 첫 번째로 입력한 사람
            if (GameBoard.Array[First-1] != ' ') Console.Write("다시 입력해주세요");
            else Game.FirstSet(First);

            Second = int.Parse(Console.ReadLine()); // 두 번째로 입력한 사람
            if (GameBoard.Array[First-1] != ' ') Console.Write("다시 입력해주세요");
            else Game.SecondSet(Second);
            
        }
    }
}
