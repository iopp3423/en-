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
        int Input; // 입력값        
        public void User()
        {


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
                Input = int.Parse(Console.ReadLine());// 플레이어 입력
                Console.Write(Input);
                if (GameBoard.Array[Input - 1] != ' ')
                {
                    Console.Clear(); // 중복해서 입력했을 때 지우고
                    Game.Overlap(); // 다시 입력
                    Console.Write("다시 입력해주세요:"); // 입력했던 곳에 다시 입력할 때 재입력 안내
                    continue;
                }

                else if (GameCheck.Draw % 2 == 0)  // 짝수면 첫 번째 플레이어
                {
                    Game.FirstSet(Input); // 입력값 배열에 넣기
                    GameCheck.Draw++; // 입력 횟수
                    Result.Judge();
                   if(Winner == true) Console.Write("X 입력할 차례입니다:");
                }

                else if (GameCheck.Draw % 2 == 1) // 홀수면 두 번째 플레이어
                {
                    Game.SecondSet(Input); // 입력값 배열에 넣기
                    GameCheck.Draw++; // 입력 횟수
                    Result.Judge();
                    if (Winner == true)  Console.Write("O 입력할 차례입니다:");
                }
            }
        }
    }
}
