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
        Judgement Result = new Judgement();
        static public bool Winner = true;
        public void User()
        {
            int First; // 첫 번째로 입력한 사람
            int Second; // 두 번째로 입력한 사람

            while (Winner) 
            {
                First = int.Parse(Console.ReadLine());// 첫 번째로 입력하는 사람
                if (GameBoard.Array[First - 1] != ' ') Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                else Game.FirstSet(First); // 입력값 배열에 넣기
                Result.Judge();
       

                Second = int.Parse(Console.ReadLine()); // 두 번째로 입력하는 사람
                if (GameBoard.Array[Second - 1] != ' ') Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                else Game.SecondSet(Second); // 입력값 배열에 넣기
                Result.Judge();
            }
        }
    }
}
