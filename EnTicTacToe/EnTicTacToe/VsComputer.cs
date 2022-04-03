using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnTicTacToe
{
    class VsComputer
    {
        GameBoard Game = new GameBoard();
        GameCheck Win = new GameCheck();
        Judgement Result = new Judgement();

        static public bool Estimate = true;
        public void Computer()
        {
            int Data;
            int Matrix;


            Console.Clear();
            Console.Write("---l---l---\n");
            Console.Write(" 1 l 2 l 3\n");
            Console.Write("---l---l---\n");
            Console.Write(" 4 l 5 l 6\n");
            Console.Write("---l---l---\n");
            Console.Write(" 7 l 8 l 9\n");
            Console.Write("---l---l---\n");
            Console.Write("번호를 입력하세요:");

            while(Estimate)
            {
                Data = int.Parse(Console.ReadLine());// 플레이어 입력
                if (GameBoard.Array[Data - 1] != ' ')
                {
                    Console.Clear(); // 중복해서 입력했을 때 화면 지우고
                    Game.Overlap(); // 다시 화면출력
                    Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                    continue;
                }

                Game.FirstSet(Data); // 입력값 배열에 넣기
                GameCheck.Draw++; // 입력 횟수
                Result.Judge();

                for (Matrix = 1; Matrix <= 9; Matrix++)
                {
                    if (GameBoard.Array[Matrix-1] == ' ')
                    {
                        Console.Write(Matrix);
                        Game.SecondSet(Matrix);
                        Game.Overlap(); // 다시 화면출력
                        GameCheck.Draw++; // 입력 횟수
                        break;
                    }
                }

            }
        }
    }
}
