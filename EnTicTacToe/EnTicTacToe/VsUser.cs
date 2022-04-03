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
        GameCheck Win = new GameCheck();
        public void User()
        {
            int First; // 첫 번째로 입력한 사람
            int Second; // 두 번째로 입력한 사람
            bool Winner = true;

            while (Winner) 
            {
                First = int.Parse(Console.ReadLine());// 첫 번째로 입력한 사람
                if (GameBoard.Array[First - 1] != ' ') Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                else Game.FirstSet(First);
                Win.Check();
                if (GameCheck.WinCheck == 1)
                {
                    Console.Write("O Player 승리\n");
                    break;
                }

                Second = int.Parse(Console.ReadLine()); // 두 번째로 입력한 사람
                if (GameBoard.Array[Second - 1] != ' ') Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                else Game.SecondSet(Second);
                Win.Check();
                if (GameCheck.WinCheck == 1)
                {
                    Console.Write("X Player 승리\n");
                    break;
                }
            }
        }
    }
}
