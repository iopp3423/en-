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
            int Input; // 입력값
            //int Second; // 두 번째로 입력한 사람

            Console.Clear();
            Console.Write("---l---l---\n");
            Console.Write(" 1 l 2 l 3\n");
            Console.Write("---l---l---\n");
            Console.Write(" 4 l 5 l 6\n");
            Console.Write("---l---l---\n");
            Console.Write(" 7 l 8 l 9\n");
            Console.Write("---l---l---\n");
            Console.Write("번호를 입력하세요:");

            while (Winner) 
            {
                Input = int.Parse(Console.ReadLine());// 첫 번째로 입력하는 사람
                Console.Write("{0}", Input);
                if (GameBoard.Array[Input - 1] != ' ')
                {
                    Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                    GameCheck.Draw--;
                }
                else if (GameCheck.Draw % 2 == 0)
                {
                    Game.FirstSet(Input); // 입력값 배열에 넣기
                    GameCheck.Draw++;
                }
                else if (GameCheck.Draw % 2 == 1)
                {
                    Game.SecondSet(Input);
                    GameCheck.Draw++;
                }
                Result.Judge();
            }
        }
    }
}
